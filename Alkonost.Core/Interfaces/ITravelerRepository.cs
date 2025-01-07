using Alkonost.Core.Models;

namespace Alkonost.Core.Interfaces
{
  public interface ITravelerRepository
  {
    Task<IEnumerable<Traveler>> GetTodaysBirthdays();
  }
}