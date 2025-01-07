using Alkonost.Core.Models;

namespace Alkonost.Core.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Settings> GetSettings();
    }
}