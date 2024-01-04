using InvoiceSystem.Entities.Identity;

namespace InvoiceSystem.ViewModels.Identity.Emails
{
    public class UserProfileUpdateNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}