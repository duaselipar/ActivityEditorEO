using ActivityEditor.Models;
using ActivityEditor.Helpers;
using ActivityEditor.Services;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace ActivityEditor.Handlers
{
    public static class ConnectButton
    {
        public static void Handle(ActivityForm form)
        {
            if (!form.IsConnected)
            {
                // Validate MySQL fields
                if (string.IsNullOrWhiteSpace(form.txthost.Text) ||
                    string.IsNullOrWhiteSpace(form.txtport.Text) ||
                    string.IsNullOrWhiteSpace(form.txtuser.Text) ||
                    string.IsNullOrWhiteSpace(form.txtdb.Text) ||
                    string.IsNullOrWhiteSpace(form.txtClientFolder.Text))
                {
                    MessageBox.Show("Please fill in all MySQL fields and select EO client folder.", "Input Missing");
                    return;
                }

                // Detect both INI files
                string acn = form.ActivityCalendarNewPath;
                string pe = form.PlayExplainPath;
                if (string.IsNullOrWhiteSpace(acn) || !File.Exists(acn) ||
                    string.IsNullOrWhiteSpace(pe) || !File.Exists(pe))
                {
                    MessageBox.Show("activitycalendarnew.ini or playexplain.ini not found in selected EO client folder!", "File Missing");
                    return;
                }

                string connStr = $"server={form.txthost.Text};port={form.txtport.Text};user={form.txtuser.Text};password={form.txtpass.Text};database={form.txtdb.Text};";
                try
                {
                    form.Conn = new MySqlConnection(connStr);
                    form.Conn.Open();

                    form.AllEvents = EventLoader.LoadEvents(pe, form.Conn);

                    form.dgvEvents.Rows.Clear();
                    foreach (var evt in form.AllEvents)
                        form.dgvEvents.Rows.Add(evt.EventID, evt.TaskName, evt.TriggerScript);

                    form.SaveSettings();

                    form.txthost.Enabled = form.txtport.Enabled = form.txtuser.Enabled = form.txtpass.Enabled = form.txtdb.Enabled = false;
                    form.txtClientFolder.Enabled = form.btnBrowseClient.Enabled = false;

                    form.btnConnect.Text = "Disconnect";
                    form.IsConnected = true;

                    // === Tukar tab selepas connect ===
                    form.tabControl1.SelectedTab = form.tbmain;
                    // (atau guna index: form.tabControl1.SelectedIndex = 1;)

                    MessageBox.Show("MySQL Connected! Events loaded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message, "MySQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.Conn?.Dispose();
                    form.Conn = null;
                    form.IsConnected = false;
                }
            }
            else
            {
                // Disconnect
                try
                {
                    form.Conn?.Close();
                    form.Conn?.Dispose();
                }
                catch { }
                form.Conn = null;

                form.txthost.Enabled = form.txtport.Enabled = form.txtuser.Enabled = form.txtpass.Enabled = form.txtdb.Enabled = true;
                form.txtClientFolder.Enabled = form.btnBrowseClient.Enabled = true;

                form.btnConnect.Text = "Load and Connect";
                form.IsConnected = false;
                form.dgvEvents.Rows.Clear();
            }
        }
    }
}
