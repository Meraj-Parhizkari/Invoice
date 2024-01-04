using InvoiceSystem.Entities.Identity;
using System.Collections.Generic;

namespace InvoiceSystem.ViewModels.Identity
{
    public class TodayBirthDaysViewModel
    {
        public List<User> Users { set; get; }

        public AgeStatViewModel AgeStat { set; get; }
    }
}