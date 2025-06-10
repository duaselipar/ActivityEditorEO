using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ActivityEditor
{
    public partial class ActivityForm : Form
    {
        public string AcnFilePath => txtacn.Text;
        public string PeFilePath => txtpe.Text;
        public string MySqlConnString { get; private set; } = string.Empty;
        public MySqlConnection MySqlConn { get; private set; }

        // Path ke setting.ini (same folder dengan .exe)
        private readonly string iniFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.ini");
        private Dictionary<string, string> iniData = new();

        // DataGridView untuk event
        private System.Data.DataTable eventsTable; // <-- LETAK SINI, BAWAH VARIABLE LAIN

        public ActivityForm()
        {
            InitializeComponent();

            dgvEvents.SelectionChanged += dgvEvents_SelectionChanged;

            // Tambahan designer DataGridView (kalau belum ada di Designer)
            if (dgvEvents == null)
            {
                dgvEvents = new DataGridView();
                dgvEvents.Location = new System.Drawing.Point(10, 10);
                dgvEvents.Name = "dgvEvents";
                dgvEvents.Size = new System.Drawing.Size(760, 390);
                dgvEvents.TabIndex = 0;
                dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEvents.ReadOnly = true;
                dgvEvents.AllowUserToAddRows = false;
                dgvEvents.AllowUserToDeleteRows = false;
                dgvEvents.MultiSelect = false;
                if (tbmain != null) tbmain.Controls.Add(dgvEvents);

                // Setup columns (clear first for reload)
                dgvEvents.Columns.Clear();
                dgvEvents.Columns.Add("EventID", "Event ID");
                dgvEvents.Columns.Add("TaskName", "Task Name");
                dgvEvents.Columns.Add("TriggerScript", "Trigger Scripts");
            }

            // Auto-load setting
            LoadSettings();
        }

        // Simple base64 "encryption" - boleh tukar ke AES kalau perlu lebih selamat
        private string Encrypt(string plain) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(plain ?? ""));

        private string Decrypt(string cipher)
        {
            try { return Encoding.UTF8.GetString(Convert.FromBase64String(cipher ?? "")); }
            catch { return cipher ?? ""; } // fallback kalau plaintext
        }

        private void LoadSettings()
        {
            if (!File.Exists(iniFile))
            {
                // Auto-create default INI kalau tak ada
                File.WriteAllText(iniFile,
@"[database]
hostname=localhost
port=3306
user=root
password=
database=
activitycaledarnew=
playexplain=
");
            }

            iniData.Clear();
            string? section = null;
            foreach (var line in File.ReadAllLines(iniFile))
            {
                var l = line.Trim();
                if (string.IsNullOrEmpty(l) || l.StartsWith(";") || l.StartsWith("#")) continue;
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    section = l.Trim('[', ']');
                    continue;
                }
                if (section == "database" && l.Contains('='))
                {
                    var idx = l.IndexOf('=');
                    var key = l.Substring(0, idx).Trim();
                    var val = l[(idx + 1)..].Trim();
                    iniData[key.ToLower()] = val;
                }
            }

            txthost.Text = iniData.GetValueOrDefault("hostname", "");
            txtport.Text = iniData.GetValueOrDefault("port", "3306");
            txtuser.Text = iniData.GetValueOrDefault("user", "");
            txtpass.Text = Decrypt(iniData.GetValueOrDefault("password", ""));
            txtdb.Text = iniData.GetValueOrDefault("database", "");
            txtacn.Text = iniData.GetValueOrDefault("activitycaledarnew", "");
            txtpe.Text = iniData.GetValueOrDefault("playexplain", "");
        }

        private void SaveSettings()
        {
            iniData["hostname"] = txthost.Text;
            iniData["port"] = txtport.Text;
            iniData["user"] = txtuser.Text;
            iniData["password"] = Encrypt(txtpass.Text);
            iniData["database"] = txtdb.Text;
            iniData["activitycaledarnew"] = txtacn.Text;
            iniData["playexplain"] = txtpe.Text;

            using (var sw = new StreamWriter(iniFile, false))
            {
                sw.WriteLine("[database]");
                sw.WriteLine($"hostname={iniData["hostname"]}");
                sw.WriteLine($"port={iniData["port"]}");
                sw.WriteLine($"user={iniData["user"]}");
                sw.WriteLine($"password={iniData["password"]}");
                sw.WriteLine($"database={iniData["database"]}");
                sw.WriteLine($"activitycaledarnew={iniData["activitycaledarnew"]}");
                sw.WriteLine($"playexplain={iniData["playexplain"]}");
            }
        }

        private void btnacn_Click(object? sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "activitycalendarnew.ini|activitycalendarnew.ini";
                dlg.Title = "Select activitycalendarnew.ini";
                dlg.FileName = "activitycalendarnew.ini"; // auto highlight kalau ada
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtacn.Text = dlg.FileName;
            }
        }

        private void btnpe_Click(object? sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "playexplain.ini|playexplain.ini";
                dlg.Title = "Select playexplain.ini";
                dlg.FileName = "playexplain.ini";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtpe.Text = dlg.FileName;
            }
        }

        private bool isConnected = false;

        private void button1_Click(object? sender, EventArgs e)
        {
            if (!isConnected)
            {
                // Basic validation (seperti biasa)
                if (string.IsNullOrWhiteSpace(txthost.Text) ||
                    string.IsNullOrWhiteSpace(txtport.Text) ||
                    string.IsNullOrWhiteSpace(txtuser.Text) ||
                    string.IsNullOrWhiteSpace(txtdb.Text) ||
                    string.IsNullOrWhiteSpace(txtacn.Text) ||
                    string.IsNullOrWhiteSpace(txtpe.Text))
                {
                    MessageBox.Show("Please fill in all MySQL fields and select both INI files.", "Input Missing");
                    return;
                }
                if (!File.Exists(txtacn.Text))
                {
                    MessageBox.Show("activitycalendarnew.ini not found at specified path!");
                    return;
                }
                if (!File.Exists(txtpe.Text))
                {
                    MessageBox.Show("playexplain.ini not found at specified path!");
                    return;
                }

                MySqlConnString = $"server={txthost.Text};port={txtport.Text};user={txtuser.Text};password={txtpass.Text};database={txtdb.Text};";
                try
                {
                    MySqlConn = new MySqlConnection(MySqlConnString);
                    MySqlConn.Open();

                    SaveSettings();

                    MessageBox.Show("MySQL Connected! Settings saved. Files loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Lock field supaya user tak ubah (optional)
                    txthost.Enabled = txtport.Enabled = txtuser.Enabled = txtpass.Enabled = txtdb.Enabled = false;
                    txtacn.Enabled = txtpe.Enabled = btnacn.Enabled = btnpe.Enabled = false;

                    // Tukar button text dan status
                    button1.Text = "Disconnect";
                    isConnected = true;

                    // Switch tab
                    tabControl1.SelectedTab = tbmain;

                    // --- Load Event Data ke DataGridView ---
                    LoadEventsToGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message, "MySQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MySqlConn?.Dispose();
                    MySqlConn = null;
                    isConnected = false;
                }
            }
            else
            {
                // Disconnect
                try
                {
                    MySqlConn?.Close();
                    MySqlConn?.Dispose();
                    MySqlConn = null;
                }
                catch { }

                // Unlock semua input
                txthost.Enabled = txtport.Enabled = txtuser.Enabled = txtpass.Enabled = txtdb.Enabled = true;
                txtacn.Enabled = txtpe.Enabled = btnacn.Enabled = btnpe.Enabled = true;

                // Reset button dan status
                button1.Text = "Load and Connect";
                isConnected = false;

                // (Optional) balik ke tab config
                tabControl1.SelectedTab = tbcfg;
            }
        }

        // -------------------------------
        // CODE TO LOAD EVENTS TO DATAGRID
        // -------------------------------
        private void LoadEventsToGrid()
        {
            if (dgvEvents.InvokeRequired)
            {
                dgvEvents.Invoke(new Action(() => LoadEventsToGrid()));
                return;
            }

            var events = new List<(string EventID, string TaskName, string TriggerScript)>();

            allEvents = events; // Simpan untuk filter semula bila search

            // 1. Baca playexplain.ini untuk EventID & Task Name
            var playLines = File.ReadAllLines(txtpe.Text, Encoding.GetEncoding("GB2312"));
            string? currentSection = null;
            string? taskName = null;
            foreach (var line in playLines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    // Kalau ada event sebelum ni, masukkan dulu
                    if (currentSection != null)
                        events.Add((currentSection, taskName ?? "", "")); // kosongkan kalau tiada ActivityName

                    currentSection = l.Trim('[', ']');
                    taskName = null;
                }
                else if (currentSection != null && l.StartsWith("ActivityName=", StringComparison.OrdinalIgnoreCase))
                {
                    taskName = l.Substring("ActivityName=".Length).Trim();
                }
            }
            // Masukkan event terakhir
            if (currentSection != null)
                events.Add((currentSection, taskName ?? "", ""));

            // 2. Query trigger script dari DB (MySQL)
            if (MySqlConn != null)
            {
                if (MySqlConn.State == System.Data.ConnectionState.Closed)
                    MySqlConn.Open();

                for (int i = 0; i < events.Count; i++)
                {
                    string eventId = events[i].EventID;
                    string triggerScript = "0";
                    using (var cmd = new MySqlCommand($"SELECT beginscript FROM cq_newtaskconfig WHERE id = @id", MySqlConn))
                    {
                        cmd.Parameters.AddWithValue("@id", eventId);
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            triggerScript = result.ToString();
                    }
                    events[i] = (events[i].EventID, events[i].TaskName, triggerScript);
                }
                MySqlConn.Close();
            }

            // 3. Masukkan data ke DataGridView
            // 5. Masukkan data ke DataGridView
            dgvEvents.Rows.Clear();
            foreach (var evt in events)
            {
                dgvEvents.Rows.Add(
                    int.TryParse(evt.EventID, out int eid) ? eid : 0,
                    evt.TaskName,
                    int.TryParse(evt.TriggerScript, out int ts) ? ts : 0
                );
            }

        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Simpan semua event di memory untuk search semula
        private List<(string EventID, string TaskName, string TriggerScript)> allEvents = new();




        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            dgvEvents.Rows.Clear();
            foreach (var evt in allEvents)
            {
                if (string.IsNullOrWhiteSpace(keyword) ||
                    evt.EventID.ToLower().Contains(keyword) ||
                    evt.TaskName.ToLower().Contains(keyword) ||
                    evt.TriggerScript.ToLower().Contains(keyword))
                {
                    dgvEvents.Rows.Add(
                        int.TryParse(evt.EventID, out int eid) ? eid : 0,
                        evt.TaskName,
                        int.TryParse(evt.TriggerScript, out int ts) ? ts : 0
                    );
                }
            }
        }

        private void dgvEvents_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0) return;

            var row = dgvEvents.SelectedRows[0];
            string eventId = row.Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(eventId)) return;

            // Untuk tab playexplain:
            LoadPlayexplainSection(eventId);
            // Untuk tab activitycalendarnew:
            LoadActivityCalendarNewSection(eventId);

            LoadTriggerScript(eventId);

        }


        private void LoadPlayexplainSection(string eventId)
        {
            // Cari section dalam playexplain.ini (boleh guna GB2312/UTF8 ikut file asal)
            var lines = File.ReadAllLines(txtpe.Text, Encoding.GetEncoding("GB2312"));
            bool inSection = false;
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    inSection = l.Trim('[', ']') == eventId;
                }
                else if (inSection && l.Contains('='))
                {
                    int idx = l.IndexOf('=');
                    string key = l.Substring(0, idx).Trim();
                    string val = l.Substring(idx + 1).Trim();
                    dict[key] = val;
                }
                else if (inSection && l.StartsWith("[") && l.EndsWith("]"))
                {
                    // Jumpa section baru, keluar loop
                    break;
                }
            }

            // Assign ke box2 kau (guna ?. supaya tak crash kalau field tak wujud)
            txtpestatus.Text = dict.GetValueOrDefault("Status", "");
            txtpeweb.Text = dict.GetValueOrDefault("Website", "");
            txtpescript.Text = dict.GetValueOrDefault("Action", "");
            txtpeactivityname.Text = dict.GetValueOrDefault("ActivityName", "");
            txtpert.Text = dict.GetValueOrDefault("RewardTitle", "");
            txtper.Text = dict.GetValueOrDefault("Reward1", "");
            txtpedt1.Text = dict.GetValueOrDefault("DesName1", "");
            rtxtped1.Text = dict.GetValueOrDefault("Des1", "").Replace(@"\n", Environment.NewLine);
            txtpedt2.Text = dict.GetValueOrDefault("DesName2", "");
            rtxtped2.Text = dict.GetValueOrDefault("Des2", "").Replace(@"\n", Environment.NewLine);
            txtpedt3.Text = dict.GetValueOrDefault("DesName3", "");
            rtxtped3.Text = dict.GetValueOrDefault("Des3", "").Replace(@"\n", Environment.NewLine);
            txtpeuld.Text = dict.GetValueOrDefault("UseLocalDes", "");
        }


        private void LoadActivityCalendarNewSection(string eventId)
        {
            var lines = File.ReadAllLines(txtacn.Text, Encoding.GetEncoding("GB2312"));
            bool inSection = false;
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    inSection = l.Trim('[', ']') == eventId;
                }
                else if (inSection && l.Contains('='))
                {
                    int idx = l.IndexOf('=');
                    string key = l.Substring(0, idx).Trim();
                    string val = l.Substring(idx + 1).Trim();
                    dict[key] = val;
                }
                else if (inSection && l.StartsWith("[") && l.EndsWith("]"))
                {
                    break;
                }
            }

            // Helper untuk setiap field
            void SetBox(TextBoxBase box, string key)
            {
                if (dict.ContainsKey(key))
                {
                    box.Text = dict[key];
                    box.Enabled = true;
                }
                else
                {
                    box.Text = "";
                    box.Enabled = false;
                }
            }

            // Isi & enable/disable ikut wujud/tak
            SetBox(txtacnp, "Priority");
            SetBox(txtacni, "Important");
            SetBox(txtacnbd, "BeginDate");
            SetBox(txtacned, "EndDate");
            SetBox(txtacnw, "Week");
            SetBox(txtacnbt, "BeginTime");
            SetBox(txtacnet, "EndTime");
            SetBox(txtacnct, "CompleteTimes");
            SetBox(txtacnlt, "LimitTimes");
            SetBox(txtacnpi, "PictureID");
            SetBox(txtacnat, "ActivityType");
            SetBox(txtacnai, "ActivityIcon");
            SetBox(txtacnm, "Monthly");
            SetBox(txtacnmi, "MonthlyIcon");
            SetBox(txtacnb, "Banner");
            SetBox(txtacnmb, "MonthlyButton");
            SetBox(txtacnmn, "Month");
            SetBox(txtacnt, "Time");
            SetBox(txtacnar, "Auto_remind");
            SetBox(txtacntal, "TaskActyLabel");
            SetBox(txtacntstr, "TimeStr");
            SetBox(txtacntstrht, "TimeStr_ht");
            SetBox(txtacnvb, "VersionBit");
            SetBox(txtacnfp, "ForcePriority");
            SetBox(txtacnci, "CheckIn");
            SetBox(txtacnbb, "BubbleBG");
            SetBox(txtacnits, "InterfaceToShow");
            SetBox(txtacntd, "TimeDelete");
            SetBox(txtacnhn, "HideNormal");
            SetBox(txtacnd, "Desc");
            SetBox(txtacnmet, "MaxEnterTime");
            SetBox(txtacntt, "TipTime");
        }

        private void btnsv_Click(object? sender, EventArgs e)
        {
            // 1. Dapatkan EventID
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih event dulu.");
                return;
            }
            string eventId = dgvEvents.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(eventId))
            {
                MessageBox.Show("EventID kosong!");
                return;
            }

            // 2. Update playexplain.ini
            UpdateIniSection(
                txtpe.Text,
                eventId,
                new Dictionary<string, string>
                {
            { "Status", txtpestatus.Text },
            { "Website", txtpeweb.Text },
            { "Action", txtpescript.Text },
            { "ActivityName", txtpeactivityname.Text },
            { "RewardTitle", txtpert.Text },
            { "Reward1", txtper.Text },
            { "DesName1", txtpedt1.Text },
            { "Des1", rtxtped1.Text.Replace(Environment.NewLine, @"\n") },
            { "DesName2", txtpedt2.Text },
            { "Des2", rtxtped2.Text.Replace(Environment.NewLine, @"\n") },
            { "DesName3", txtpedt3.Text },
            { "Des3", rtxtped3.Text.Replace(Environment.NewLine, @"\n") },
            { "UseLocalDes", txtpeuld.Text }
                });

            // 3. Update activitycalendarnew.ini
            UpdateIniSection(
                txtacn.Text,
                eventId,
                new Dictionary<string, string>
                {
            { "Priority", txtacnp.Text },
            { "Important", txtacni.Text },
            { "BeginDate", txtacnbd.Text },
            { "EndDate", txtacned.Text },
            { "Week", txtacnw.Text },
            { "BeginTime", txtacnbt.Text },
            { "EndTime", txtacnet.Text },
            { "CompleteTimes", txtacnct.Text },
            { "LimitTimes", txtacnlt.Text },
            { "PictureID", txtacnpi.Text },
            { "ActivityType", txtacnat.Text },
            { "ActivityIcon", txtacnai.Text },
            { "Monthly", txtacnm.Text },
            { "MonthlyIcon", txtacnmi.Text },
            { "Banner", txtacnb.Text },
            { "MonthlyButton", txtacnmb.Text },
            { "Month", txtacnmn.Text },
            { "Time", txtacnt.Text },
            { "Auto_remind", txtacnar.Text },
            { "TaskActyLabel", txtacntal.Text },
            { "TimeStr", txtacntstr.Text },
            { "TimeStr_ht", txtacntstrht.Text },
            { "VersionBit", txtacnvb.Text },
            { "ForcePriority", txtacnfp.Text },
            { "CheckIn", txtacnci.Text },
            { "BubbleBG", txtacnbb.Text },
            { "InterfaceToShow", txtacnits.Text },
            { "TimeDelete", txtacntd.Text },
            { "HideNormal", txtacnhn.Text },
            { "Desc", txtacnd.Text },
            { "MaxEnterTime", txtacnmet.Text },
            { "TipTime", txtacntt.Text }
                });

            // 4. Update DB trigger script
            try
            {
                if (MySqlConn.State == System.Data.ConnectionState.Closed)
                    MySqlConn.Open();

                // Check dulu ID tu wujud ke tak
                bool exists = false;
                using (var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM cq_newtaskconfig WHERE id=@id", MySqlConn))
                {
                    checkCmd.Parameters.AddWithValue("@id", eventId);
                    var count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    exists = count > 0;
                }

                if (exists)
                {
                    // Update kalau dah ada
                    using (var cmd = new MySqlCommand("UPDATE cq_newtaskconfig SET beginscript=@script WHERE id=@id", MySqlConn))
                    {
                        cmd.Parameters.AddWithValue("@script", txtts.Text);
                        cmd.Parameters.AddWithValue("@id", eventId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Insert kalau tak ada — **pastikan isi column wajib lain**
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO cq_newtaskconfig (id, beginscript) VALUES (@id, @script)", MySqlConn))
                    {
                        cmd.Parameters.AddWithValue("@id", eventId);
                        cmd.Parameters.AddWithValue("@script", txtts.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MySqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Update/Insert Error: " + ex.Message);
            }

            SaveSortedIni(txtpe.Text);   // playexplain.ini
            SaveSortedIni(txtacn.Text);  // activitycalendarnew.ini

            MessageBox.Show("Saved!");
        }

        private void UpdateIniSection(string iniPath, string section, Dictionary<string, string> fieldValues)
        {
            var lines = new List<string>(File.ReadAllLines(iniPath, Encoding.GetEncoding("GB2312")));
            var result = new List<string>();
            bool inSection = false;
            bool sectionWritten = false;

            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    if (inSection && !sectionWritten)
                    {
                        // Tulis semua key dalam dictionary (yang ada value)
                        foreach (var kv in fieldValues)
                            if (!string.IsNullOrWhiteSpace(kv.Value)) // Hanya save field yang diisi
                                result.Add($"{kv.Key}={kv.Value}");
                        sectionWritten = true;
                    }

                    inSection = l.Trim('[', ']') == section;
                    result.Add(line);
                    continue;
                }

                if (inSection && l.Contains('='))
                {
                    var key = l.Split('=')[0].Trim();
                    // Hanya tambah field yang belum tulis
                    if (fieldValues.ContainsKey(key))
                    {
                        if (!string.IsNullOrWhiteSpace(fieldValues[key]))
                            result.Add($"{key}={fieldValues[key]}");
                        fieldValues.Remove(key);
                    }
                    // else: skip (akan tambah di bawah kalau belum wujud)
                }
                else
                {
                    result.Add(line);
                }
            }

            // If section at the end, add fields if not yet written
            if (inSection && !sectionWritten)
            {
                foreach (var kv in fieldValues)
                    if (!string.IsNullOrWhiteSpace(kv.Value))
                        result.Add($"{kv.Key}={kv.Value}");
            }

            File.WriteAllLines(iniPath, result, Encoding.GetEncoding("GB2312"));
        }


        private void LoadTriggerScript(string eventId)
        {
            try
            {
                if (MySqlConn.State == System.Data.ConnectionState.Closed)
                    MySqlConn.Open();

                using (var cmd = new MySqlCommand("SELECT beginscript FROM cq_newtaskconfig WHERE id = @id", MySqlConn))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    var result = cmd.ExecuteScalar();
                    txtts.Text = result != null ? result.ToString() : "";
                }
                MySqlConn.Close();
            }
            catch
            {
                txtts.Text = "";
            }
        }


        private void SaveSortedIni(string iniPath)
        {
            var lines = File.ReadAllLines(iniPath, Encoding.GetEncoding("GB2312"));

            // Kumpul semua section
            var sectionDict = new SortedDictionary<int, List<string>>();
            int? currentSection = null;
            var sectionLines = new List<string>();

            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    // Simpan section sebelum ni
                    if (currentSection != null)
                        sectionDict[currentSection.Value] = new List<string>(sectionLines);

                    // Start section baru
                    sectionLines.Clear();
                    int sectionId;
                    if (int.TryParse(l.Trim('[', ']'), out sectionId))
                        currentSection = sectionId;
                    else
                        currentSection = null; // skip section bukan nombor

                    sectionLines.Add(line);
                }
                else
                {
                    if (currentSection != null)
                        sectionLines.Add(line);
                }
            }
            // Simpan section terakhir
            if (currentSection != null)
                sectionDict[currentSection.Value] = new List<string>(sectionLines);

            // Tulis semula ikut order
            var result = new List<string>();
            foreach (var sec in sectionDict)
            {
                result.AddRange(sec.Value);
            }
            File.WriteAllLines(iniPath, result, Encoding.GetEncoding("GB2312"));
        }


    }



}
