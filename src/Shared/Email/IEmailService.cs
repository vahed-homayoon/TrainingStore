namespace Shared.Email;

public interface IEmailService
{
	public Task SendWelcomeEmailAsync(string fullName, string email, CancellationToken cancellationToken = default);
}
