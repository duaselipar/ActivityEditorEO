using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ActivityEditor.Models;
using ActivityEditor.Helpers;
using ActivityEditor.Services;
using MySql.Data.MySqlClient;

namespace ActivityEditor
{
    public partial class ActivityForm : Form
    {
        // === Fields & Properties ===
        private readonly string iniFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.ini");
        internal SettingsManager settings; // internal: boleh access dalam handler
        private MySqlConnection? _conn;
        private List<EventItem> _allEvents = new();

        private bool _isConnected = false;

        // Path properties, handler update these on folder select
        public string? ActivityCalendarNewPath { get; set; }
        public string? PlayExplainPath { get; set; }

        public bool IsConnected { get => _isConnected; set => _isConnected = value; }
        public MySqlConnection? Conn { get => _conn; set => _conn = value; }
        public List<EventItem> AllEvents { get => _allEvents; set => _allEvents = value; }
        public int lastSearchIndex = -1;

        public ActivityForm()
        {
            InitializeComponent();
            settings = new SettingsManager(iniFile);

            // Assign all handlers
            linkLabel1.LinkClicked += (s, e) => OpenUrl("https://github.com/duaselipar/ActivityEditorEO");
            linkLabel2.LinkClicked += (s, e) => OpenUrl("https://www.facebook.com/profile.php?id=61554036273018");
            btnConnect.Click += (s, e) => ActivityEditor.Handlers.ConnectButton.Handle(this);
            btnBrowseClient.Click += (s, e) => ActivityEditor.Handlers.BrowseClientButton.Handle(this);
            btnsv.Click += (s, e) => ActivityEditor.Handlers.SaveButton.Handle(this);
            txtSearch.TextChanged += (s, e) => ActivityEditor.Handlers.SearchBoxHandler.HandleTextChanged(this);
            txtSearch.KeyDown += (s, e) => ActivityEditor.Handlers.SearchBoxHandler.HandleKeyDown(this, e);
            dgvEvents.SelectionChanged += dgvEvents_SelectionChanged;

            // Auto-load settings + auto-detect INI in folder (if exists)
            LoadSettings();
        }

        // Open external URL
        private void OpenUrl(string url)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        // === Ini Settings Loader (Form only) ===
        public void LoadSettings()
        {
            try
            {
                settings.Load();
                txthost.Text = settings.IniData.GetValueOrDefault("hostname", "");
                txtport.Text = settings.IniData.GetValueOrDefault("port", "3306");
                txtuser.Text = settings.IniData.GetValueOrDefault("user", "");
                txtpass.Text = settings.IniData.GetValueOrDefault("password", "");
                txtdb.Text = settings.IniData.GetValueOrDefault("database", "");
                txtClientFolder.Text = settings.IniData.GetValueOrDefault("client_folder", "");

                // Auto detect INI on load
                if (!string.IsNullOrWhiteSpace(txtClientFolder.Text) && Directory.Exists(txtClientFolder.Text))
                    ActivityEditor.Handlers.BrowseClientButton.DetectIniFilesAndSetPaths(this, txtClientFolder.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message);
            }
        }

        // === Settings Saver (called from handler, must be public) ===
        public void SaveSettings()
        {
            var iniData = new Dictionary<string, string>
            {
                { "hostname", txthost.Text },
                { "port", txtport.Text },
                { "user", txtuser.Text },
                { "password", txtpass.Text },
                { "database", txtdb.Text },
                { "client_folder", txtClientFolder.Text }
            };
            settings.Save(iniData);
        }

        // === Event details loader ===
        public void dgvEvents_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0) return;
            string? eventId = dgvEvents.SelectedRows[0].Cells[0].Value?.ToString();
            if (string.IsNullOrWhiteSpace(eventId)) { MessageBox.Show("EventID is null or empty."); return; }
            LoadPlayexplainSection(eventId);
            LoadActivityCalendarNewSection(eventId);
            try
            {
                string connStr = $"server={txthost.Text};port={txtport.Text};user={txtuser.Text};password={txtpass.Text};database={txtdb.Text};";
                using var tempConn = DatabaseHelper.Connect(connStr);
                txtts.Text = DatabaseHelper.GetTriggerScript(tempConn, eventId);
            }
            catch { txtts.Text = ""; }
        }

        // === Load details from playexplain.ini ===
        public void LoadPlayexplainSection(string eventId)
        {
            if (string.IsNullOrEmpty(PlayExplainPath) || !File.Exists(PlayExplainPath)) return;
            var lines = File.ReadAllLines(PlayExplainPath, Encoding.GetEncoding("GB2312"));
            bool inSection = false;
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]")) inSection = l.Trim('[', ']') == eventId;
                else if (inSection && l.Contains('=')) { int idx = l.IndexOf('='); string key = l[..idx].Trim(); string val = l[(idx + 1)..].Trim(); dict[key] = val; }
                else if (inSection && l.StartsWith("[") && l.EndsWith("]")) break;
            }
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

        // === Load details from activitycalendarnew.ini ===
        public void LoadActivityCalendarNewSection(string eventId)
        {
            if (string.IsNullOrEmpty(ActivityCalendarNewPath) || !File.Exists(ActivityCalendarNewPath)) return;
            var lines = File.ReadAllLines(ActivityCalendarNewPath, Encoding.GetEncoding("GB2312"));
            bool inSection = false;
            var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]")) inSection = l.Trim('[', ']') == eventId;
                else if (inSection && l.Contains('=')) { int idx = l.IndexOf('='); string key = l[..idx].Trim(); string val = l[(idx + 1)..].Trim(); dict[key] = val; }
                else if (inSection && l.StartsWith("[") && l.EndsWith("]")) break;
            }
            void SetBox(TextBoxBase box, string key)
            {
                if (dict.ContainsKey(key)) { box.Text = dict[key]; box.Enabled = true; }
                else { box.Text = ""; box.Enabled = false; }
            }
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
    }
}
