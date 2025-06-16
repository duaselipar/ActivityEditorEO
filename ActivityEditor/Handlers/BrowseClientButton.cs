using System.IO;
using System.Windows.Forms;

namespace ActivityEditor.Handlers
{
    public static class BrowseClientButton
    {
        public static void Handle(ActivityForm form)
        {
            using var dlg = new FolderBrowserDialog();
            dlg.Description = "Select EO client folder (root folder)";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                form.txtClientFolder.Text = dlg.SelectedPath;
                form.SaveSettings();
                DetectIniFilesAndSetPaths(form, dlg.SelectedPath);
            }
        }

        // Make this public for reuse
        public static void DetectIniFilesAndSetPaths(ActivityForm form, string folder)
        {
            string acn = Path.Combine(folder, "ini", "activitycalendarnew.ini");
            string pe = Path.Combine(folder, "ini", "playexplain.ini");

            if (File.Exists(acn) && File.Exists(pe))
            {
                form.ActivityCalendarNewPath = acn;
                form.PlayExplainPath = pe;
            }
            else
            {
                form.ActivityCalendarNewPath = null;
                form.PlayExplainPath = null;
                MessageBox.Show("activitycalendarnew.ini or playexplain.ini not found in selected folder.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
