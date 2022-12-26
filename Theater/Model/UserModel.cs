using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theater.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public string PhoneNumber { get; set; }

        /* 
             string login = LoginBox.Text;
            string password = PasswordnBox.Password;
            string fio = FioBox.Text;
            string address = AddresBox.Text;
            string phone = PhoneBox.Text;
            DateTime? birthday = DateBox.SelectedDate;
            bool? isAdmin = AdminBox.IsChecked;
         */
    }
}
