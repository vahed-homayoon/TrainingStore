using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Email;

namespace TrainingStore.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
	private readonly MailSettingOptions _mailSettingOptions;

	public EmailService(IOptions<MailSettingOptions> mailSettingOptions)
	{
		_mailSettingOptions = mailSettingOptions.Value;
	}

	public async Task SendWelcomeEmailAsync(string fullName, string email, CancellationToken cancellationToken)
	{
		var body = $"""
				<html>

				<body
				  style="font-family: Tahoma, Arial, sans-serif;width: 600px;margin: 0 auto;margin-top: 50px;border: 1px solid #ddd;text-align: right;">
				  <div>
				    <div style="background-color: #f0f0f0;padding: 20px;">
				      <div>
				        آموزشگاه
				      </div>
				    </div>
				  </div>
				  <div>
				    <div style="padding: 10px;">
				      <h4 dir="rtl"><span>{fullName}</span>, <span>عزیز</span></h4>
				      <h4><span>سلام</span>, <span>عزیز</span></h4>
				      <p>به آموزشگاه خوش آمدید! ما خیلی خوشحالیم که شما به جمع ما پیوستید</p>
				      <p>امیدواریم از عضویت در آموزشگاه لذت ببرید</p>
				      <p>با احترام</p>
				      <p>تیم آموزشگاه</p>
				    </div>
				  </div>
				  <div class="footer" style="background-color: #f0f0f0;padding: 10px;text-align: center;">
				    <p>&copy; آموزشگاه 2024 - 1403</p>
				  </div>
				</body>

				</html>
				""";
		string subject = "خوشامدگویی اموزشگاه";

		await SendEmailAsync(fullName, subject, body, cancellationToken);
	}

	private async Task SendEmailAsync(string recipient, string subject, string body, CancellationToken cancellationToken = default)
	{
		try
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress(_mailSettingOptions.SenderName, _mailSettingOptions.SenderEmail));
			message.To.Add(new MailboxAddress(recipient, "vahed.homayoon67@gmail.com"));
			message.Subject = subject;
			message.Body = new TextPart("html")
			{
				Text = body
			};

			using var client = new SmtpClient();
			client.Connect(_mailSettingOptions.Server, _mailSettingOptions.Port, SecureSocketOptions.StartTls, cancellationToken);
			client.Authenticate(_mailSettingOptions.UserName, _mailSettingOptions.Password, cancellationToken);

			await client.SendAsync(message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error sending email: " + ex.Message);
		}
	}
}