using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EscapeMines.Services
{
    public class SettingsReaderService : ISettingsReaderService
    {
        public List<string> GetAllLines()
        {
            return File.ReadAllLines(@"C:\GameSettings\GameSettings.txt").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
    }
}
