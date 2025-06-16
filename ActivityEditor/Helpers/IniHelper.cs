using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ActivityEditor.Helpers
{
    public static class IniHelper
    {
        public static void UpdateIniSection(string iniPath, string section, Dictionary<string, string> fieldValues)
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
                        foreach (var kv in fieldValues)
                            if (!string.IsNullOrWhiteSpace(kv.Value))
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
                    if (fieldValues.ContainsKey(key))
                    {
                        if (!string.IsNullOrWhiteSpace(fieldValues[key]))
                            result.Add($"{key}={fieldValues[key]}");
                        fieldValues.Remove(key);
                    }
                }
                else
                {
                    result.Add(line);
                }
            }

            if (inSection && !sectionWritten)
            {
                foreach (var kv in fieldValues)
                    if (!string.IsNullOrWhiteSpace(kv.Value))
                        result.Add($"{kv.Key}={kv.Value}");
            }

            File.WriteAllLines(iniPath, result, Encoding.GetEncoding("GB2312"));
        }

        public static void SaveSortedIni(string iniPath)
        {
            var lines = File.ReadAllLines(iniPath, Encoding.GetEncoding("GB2312"));
            var sectionDict = new SortedDictionary<int, List<string>>();
            int? currentSection = null;
            var sectionLines = new List<string>();

            foreach (var line in lines)
            {
                string l = line.Trim();
                if (l.StartsWith("[") && l.EndsWith("]"))
                {
                    if (currentSection != null)
                        sectionDict[currentSection.Value] = new List<string>(sectionLines);

                    sectionLines.Clear();
                    if (int.TryParse(l.Trim('[', ']'), out int sectionId))
                        currentSection = sectionId;
                    else
                        currentSection = null;
                    sectionLines.Add(line);
                }
                else
                {
                    if (currentSection != null)
                        sectionLines.Add(line);
                }
            }
            if (currentSection != null)
                sectionDict[currentSection.Value] = new List<string>(sectionLines);

            var result = new List<string>();
            foreach (var sec in sectionDict)
                result.AddRange(sec.Value);
            File.WriteAllLines(iniPath, result, Encoding.GetEncoding("GB2312"));
        }
    }
}
