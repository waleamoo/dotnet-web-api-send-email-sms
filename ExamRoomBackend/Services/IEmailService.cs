using ExamRoomBackend.Models;

namespace ExamRoomBackend.Services
{
    public interface IEmailService
    {
        Task SendVerificationEmail(UserEmailOptions userEmailOptions);
        string GenerateVerificationCode();
        Task SendVerificationSMS(string phoneNumber, string verificationCode, string clientName);
    }
}