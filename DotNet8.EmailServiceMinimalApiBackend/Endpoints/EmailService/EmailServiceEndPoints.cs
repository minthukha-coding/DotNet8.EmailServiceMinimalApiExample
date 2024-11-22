using DotNet8.EmailServiceMinimalApiBackend.Modules.Features.EmailService;
using DotNet8.EmailServiceMinimalApiExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.EmailServiceMinimalApiBackend.Endpoints.EmailService;

public class EmailServiceEndPoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/class/list",
            async (EmailRequestModel reqModel,
            [FromServices] EmailService _service) =>
            {
                return await ClassList(reqModel, _service);
            });
    }

    public async Task<string> Send(EmailRequestModel reqModel, EmailService _service)
    {

    }

}
