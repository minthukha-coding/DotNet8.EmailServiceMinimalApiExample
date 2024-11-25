using DotNet8.EmailServiceMinimalApiExample.Models;
using FluentEmail.Core;


namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.EmailService;

public class EmailServiceRepository
{
    public async Task<string> Send(
        EmailRequestModel emailRequestModel,
        IFluentEmail fluentEmail)
    {
        var email = await fluentEmail
            .To(emailRequestModel.MailTo)
            .Subject(emailRequestModel.Subject)
            .Body(emailRequestModel.Body)
            .SendAsync();

        if (email.Successful)
        {
            return "Success";
        }

        return "Fail";
    }
}