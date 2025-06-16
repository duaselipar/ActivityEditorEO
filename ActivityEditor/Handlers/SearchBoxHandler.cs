using System.Windows.Forms;

namespace ActivityEditor.Handlers
{
    public static class SearchBoxHandler
    {
        // Pegang lastSearchIndex dalam form
        public static void HandleTextChanged(ActivityForm form)
        {
            string keyword = form.txtSearch.Text.Trim().ToLower();
            form.lastSearchIndex = -1;
            if (string.IsNullOrEmpty(keyword))
            {
                form.dgvEvents.ClearSelection();
                return;
            }
            for (int i = 0; i < form.dgvEvents.Rows.Count; i++)
            {
                var row = form.dgvEvents.Rows[i];
                if (!row.IsNewRow)
                {
                    string id = row.Cells[0].Value?.ToString()?.ToLower() ?? "";
                    string name = row.Cells[1].Value?.ToString()?.ToLower() ?? "";
                    string trig = row.Cells[2].Value?.ToString()?.ToLower() ?? "";
                    if (id.Contains(keyword) || name.Contains(keyword) || trig.Contains(keyword))
                    {
                        form.dgvEvents.ClearSelection();
                        row.Selected = true;
                        form.dgvEvents.FirstDisplayedScrollingRowIndex = i;
                        form.lastSearchIndex = i;
                        return;
                    }
                }
            }
            form.dgvEvents.ClearSelection();
        }

        public static void HandleKeyDown(ActivityForm form, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = form.txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(keyword) || form.dgvEvents.Rows.Count == 0)
                    return;

                int startIdx = form.lastSearchIndex + 1;
                bool found = false;

                for (int i = startIdx; i < form.dgvEvents.Rows.Count; i++)
                {
                    var row = form.dgvEvents.Rows[i];
                    if (!row.IsNewRow)
                    {
                        string id = row.Cells[0].Value?.ToString()?.ToLower() ?? "";
                        string name = row.Cells[1].Value?.ToString()?.ToLower() ?? "";
                        string trig = row.Cells[2].Value?.ToString()?.ToLower() ?? "";
                        if (id.Contains(keyword) || name.Contains(keyword) || trig.Contains(keyword))
                        {
                            form.dgvEvents.ClearSelection();
                            row.Selected = true;
                            form.dgvEvents.FirstDisplayedScrollingRowIndex = i;
                            form.lastSearchIndex = i;
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    for (int i = 0; i <= form.lastSearchIndex; i++)
                    {
                        var row = form.dgvEvents.Rows[i];
                        if (!row.IsNewRow)
                        {
                            string id = row.Cells[0].Value?.ToString()?.ToLower() ?? "";
                            string name = row.Cells[1].Value?.ToString()?.ToLower() ?? "";
                            string trig = row.Cells[2].Value?.ToString()?.ToLower() ?? "";
                            if (id.Contains(keyword) || name.Contains(keyword) || trig.Contains(keyword))
                            {
                                form.dgvEvents.ClearSelection();
                                row.Selected = true;
                                form.dgvEvents.FirstDisplayedScrollingRowIndex = i;
                                form.lastSearchIndex = i;
                                break;
                            }
                        }
                    }
                }
                e.Handled = true;
            }
        }
    }
}
