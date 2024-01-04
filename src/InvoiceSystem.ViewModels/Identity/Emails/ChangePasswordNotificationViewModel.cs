using InvoiceSystem.Entities.Identity;

namespace InvoiceSystem.ViewModels.Identity.Emails
{
    public class ChangePasswordNotificationViewModel : EmailsBase
    {
        public User User { set; get; }
    }
}