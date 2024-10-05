namespace DotNet8.EmailServiceMinimalApiExample.Models;

public class EmailRequestModel
{
    public string MailTo { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}

public static class MessageResponseModel
{
    public static readonly object Ok = new { Message = "Email sent successfully" };
    public static readonly object Fail = new { Message = "Failed to send email" };
}

public class SmtpSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string User { get; set; }
    public string Pass { get; set; }
    public bool EnableSsl { get; set; }
}