using System.Collections.Generic;

namespace EscapeMines.Services
{
    public interface ISettingsReaderService
    {
        List<string> GetAllLines();
    }
}