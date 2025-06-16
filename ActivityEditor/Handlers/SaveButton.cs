using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ActivityEditor.Helpers;

namespace ActivityEditor.Handlers
{
    public static class SaveButton
    {
        public static void Handle(ActivityForm form)
        {
            // 1. Check selection
            if (form.dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select event first.");
                return;
            }
            string eventId = form.dgvEvents.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(eventId))
            {
                MessageBox.Show("EventID Empty!");
                return;
            }

            // 2. Get ini file path
            string acnPath = form.ActivityCalendarNewPath;
            string pePath = form.PlayExplainPath;
            if (string.IsNullOrWhiteSpace(acnPath) || !System.IO.File.Exists(acnPath) ||
                string.IsNullOrWhiteSpace(pePath) || !System.IO.File.Exists(pePath))
            {
                MessageBox.Show("activitycalendarnew.ini or playexplain.ini not found in selected EO client folder!", "File Missing");
                return;
            }

            // 3. Update playexplain.ini
            IniHelper.UpdateIniSection(
                pePath, eventId,
                new Dictionary<string, string>
                {
                    { "Status", form.txtpestatus.Text },
                    { "Website", form.txtpeweb.Text },
                    { "Action", form.txtpescript.Text },
                    { "ActivityName", form.txtpeactivityname.Text },
                    { "RewardTitle", form.txtpert.Text },
                    { "Reward1", form.txtper.Text },
                    { "DesName1", form.txtpedt1.Text },
                    { "Des1", form.rtxtped1.Text.Replace("\r\n", "\n").Replace("\n", "\\n") },
                    { "DesName2", form.txtpedt2.Text },
                    { "Des2", form.rtxtped2.Text.Replace("\r\n", "\n").Replace("\n", "\\n") },
                    { "DesName3", form.txtpedt3.Text },
                    { "Des3", form.rtxtped3.Text.Replace("\r\n", "\n").Replace("\n", "\\n") },
                    { "UseLocalDes", form.txtpeuld.Text }
                });

            // 4. Update activitycalendarnew.ini
            IniHelper.UpdateIniSection(
                acnPath, eventId,
                new Dictionary<string, string>
                {
                    { "Priority", form.txtacnp.Text },
                    { "Important", form.txtacni.Text },
                    { "BeginDate", form.txtacnbd.Text },
                    { "EndDate", form.txtacned.Text },
                    { "Week", form.txtacnw.Text },
                    { "BeginTime", form.txtacnbt.Text },
                    { "EndTime", form.txtacnet.Text },
                    { "CompleteTimes", form.txtacnct.Text },
                    { "LimitTimes", form.txtacnlt.Text },
                    { "PictureID", form.txtacnpi.Text },
                    { "ActivityType", form.txtacnat.Text },
                    { "ActivityIcon", form.txtacnai.Text },
                    { "Monthly", form.txtacnm.Text },
                    { "MonthlyIcon", form.txtacnmi.Text },
                    { "Banner", form.txtacnb.Text },
                    { "MonthlyButton", form.txtacnmb.Text },
                    { "Month", form.txtacnmn.Text },
                    { "Time", form.txtacnt.Text },
                    { "Auto_remind", form.txtacnar.Text },
                    { "TaskActyLabel", form.txtacntal.Text },
                    { "TimeStr", form.txtacntstr.Text },
                    { "TimeStr_ht", form.txtacntstrht.Text },
                    { "VersionBit", form.txtacnvb.Text },
                    { "ForcePriority", form.txtacnfp.Text },
                    { "CheckIn", form.txtacnci.Text },
                    { "BubbleBG", form.txtacnbb.Text },
                    { "InterfaceToShow", form.txtacnits.Text },
                    { "TimeDelete", form.txtacntd.Text },
                    { "HideNormal", form.txtacnhn.Text },
                    { "Desc", form.txtacnd.Text },
                    { "MaxEnterTime", form.txtacnmet.Text },
                    { "TipTime", form.txtacntt.Text }
                });

            // 5. Update DB trigger script
            try
            {
                string connStr = $"server={form.txthost.Text};port={form.txtport.Text};user={form.txtuser.Text};password={form.txtpass.Text};database={form.txtdb.Text};";
                using var tempConn = ActivityEditor.Helpers.DatabaseHelper.Connect(connStr);
                ActivityEditor.Helpers.DatabaseHelper.SaveTriggerScript(tempConn, eventId, form.txtts.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Update/Insert Error: " + ex.Message);
            }

            IniHelper.SaveSortedIni(pePath);
            IniHelper.SaveSortedIni(acnPath);

            MessageBox.Show("Saved!");
        }
    }
}
