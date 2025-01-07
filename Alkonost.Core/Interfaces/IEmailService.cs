using Alkonost.Core.Models;

namespace Alkonost.Core.Interfaces
{
  public interface IEmailService
  {
    Task SendBirthdayGreeting(Traveler traveler);
    Task SendPaymentSummary(string email, IEnumerable<Payment> payments);
  }
}