using System.Collections.Generic;
using System.IO;
using System.Text;
using ActivityEditor.Models;
using MySql.Data.MySqlClient;
using ActivityEditor.Helpers;

namespace ActivityEditor.Services
{
    public class EventLoader
    {
        public static List<EventItem> LoadEvents(string playExplainPath, MySqlConnection conn)
        {
            var events = new List<EventItem>();
            var playLines = File.ReadAllLines(playExplainPath, Encoding.GetEncoding("GB2312"));
            string? currentSection = null;
            string? taskName = null;
            foreach (var line in playLines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    if (currentSection != null)
                        events.Add(new EventItem { EventID = currentSection, TaskName = taskName ?? "", TriggerScript = "" });
                    currentSection = l.Trim('[', ']');
                    taskName = null;
                }
                else if (currentSection != null && l.StartsWith("ActivityName=", System.StringComparison.OrdinalIgnoreCase))
                {
                    taskName = l.Substring("ActivityName=".Length).Trim();
                }
            }
            if (currentSection != null)
                events.Add(new EventItem { EventID = currentSection, TaskName = taskName ?? "", TriggerScript = "" });

            foreach (var evt in events)
            {
                evt.TriggerScript = DatabaseHelper.GetTriggerScript(conn, evt.EventID);
            }
            return events;
        }
    }
}
