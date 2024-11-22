using DotNet8.EmailServiceMinimalApiExample.Models;
using FluentEmail.Core;

namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.EmailService;

public class EmailService
{
    private EmailServiceRepository _repository;
    private readonly IFluentEmail _fluentEmail;

    public EmailService(EmailServiceRepository repository, IFluentEmail fluentEmail)
    {
        _repository = repository;
        _fluentEmail = fluentEmail;
    }

    public async Task<string> Send(EmailRequestModel requestModel)
    {
        return await _repository.Send(requestModel, _fluentEmail);
    }
}