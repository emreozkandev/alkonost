using Alkonost.Core.Models;

namespace Alkonost.Core.Interfaces
{
  public interface IPaymentRepository
  {
    Task<IEnumerable<Payment>> GetDailyPayments();
  }
}