using MySql.Data.MySqlClient;
using System;

namespace ActivityEditor.Helpers
{
    public static class DatabaseHelper
    {
        public static MySqlConnection Connect(string connStr)
        {
            var conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public static string GetTriggerScript(MySqlConnection conn, string eventId)
        {
            using var cmd = new MySqlCommand("SELECT beginscript FROM cq_newtaskconfig WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", eventId);
            var result = cmd.ExecuteScalar();
            return result?.ToString() ?? "0";
        }

        public static void SaveTriggerScript(MySqlConnection conn, string eventId, string script)
        {
            // Check exist
            using var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM cq_newtaskconfig WHERE id=@id", conn);
            checkCmd.Parameters.AddWithValue("@id", eventId);
            var count = Convert.ToInt32(checkCmd.ExecuteScalar());
            if (count > 0)
            {
                // Update
                using var updateCmd = new MySqlCommand("UPDATE cq_newtaskconfig SET beginscript=@script WHERE id=@id", conn);
                updateCmd.Parameters.AddWithValue("@script", script);
                updateCmd.Parameters.AddWithValue("@id", eventId);
                updateCmd.ExecuteNonQuery();
            }
            else
            {
                // Insert
                using var insertCmd = new MySqlCommand("INSERT INTO cq_newtaskconfig (id, beginscript) VALUES (@id, @script)", conn);
                insertCmd.Parameters.AddWithValue("@id", eventId);
                insertCmd.Parameters.AddWithValue("@script", script);
                insertCmd.ExecuteNonQuery();
            }
        }
    }
}
