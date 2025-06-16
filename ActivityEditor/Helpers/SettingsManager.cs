using System.Collections.Generic;
using System.IO;

namespace ActivityEditor.Helpers
{
    public class SettingsManager
    {
        private readonly string iniFile;
        public Dictionary<string, string> IniData { get; private set; } = new();

        public SettingsManager(string filePath)
        {
            iniFile = filePath;
        }

        public void Load()
        {
            IniData.Clear();
            if (!File.Exists(iniFile))
                throw new FileNotFoundException(iniFile);

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
                    var key = l.Substring(0, idx).Trim().ToLower();
                    var val = l[(idx + 1)..].Trim();
                    IniData[key] = val;
                }
            }
        }

        public void Save(Dictionary<string, string> data)
        {
            using var sw = new StreamWriter(iniFile, false);
            sw.WriteLine("[database]");
            foreach (var (key, val) in data)
                sw.WriteLine($"{key}={val}");
        }
    }
}
