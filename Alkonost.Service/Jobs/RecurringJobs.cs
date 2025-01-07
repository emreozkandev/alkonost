using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using Alkonost.Core.Interfaces;
using Alkonost.Core.Models;

namespace Alkonost.Service.Jobs
{
  public class RecurringJobs
  {
    private readonly IEmailService _emailService;
    private readonly ITravelerRepository _travelerRepository;
    private readonly ISettingsRepository _settingsRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<RecurringJobs> _logger;

    public RecurringJobs(
        IEmailService emailService,
        ITravelerRepository travelerRepository,
        ISettingsRepository settingsRepository,
        IPaymentRepository paymentRepository,
        ILogger<RecurringJobs> logger)
    {
      _emailService = emailService;
      _travelerRepository = travelerRepository;
      _settingsRepository = settingsRepository;
      _paymentRepository = paymentRepository;
      _logger = logger;
    }

    public async Task SendBirthdayGreetings()
    {
      try
      {
        var todaysBirthdays = await _travelerRepository.GetTodaysBirthdays();
        foreach (var traveler in todaysBirthdays)
        {
          await _emailService.SendBirthdayGreeting(traveler);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error sending birthday greetings");
        throw;
      }
    }

    public async Task SendDailyPaymentSummary()
    {
      try
      {
        var settings = await _settingsRepository.GetSettings();
        var dailyPayments = await _paymentRepository.GetDailyPayments();

        if (settings.PaymentSummaryEmail != null)
        {
          await _emailService.SendPaymentSummary(settings.PaymentSummaryEmail, dailyPayments);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error sending daily payment summary");
        throw;
      }
    }
  }
}