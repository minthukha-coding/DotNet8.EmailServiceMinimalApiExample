using DotNet8.EmailServiceMinimalApiExample.Models;
using FluentEmail.Core;

namespace DotNet8.EmailServiceMinimalApiBackend.Modules.Features.EmailService;

public class EmailService
{

    private readonly EmailServiceRepository _serviceRepository;
    private readonly IFluentEmail _fluentEmail;

    public EmailService(EmailServiceRepository serviceRepository, IFluentEmail fluentEmail)
    {
        _serviceRepository = serviceRepository;
        _fluentEmail = fluentEmail;
    }

    public async Task<string> Send(EmailRequestModel emailRequestModel)
    {
        return await _serviceRepository.Send(emailRequestModel,_fluentEmail);
    }
    
}