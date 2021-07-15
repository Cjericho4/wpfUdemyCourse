using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone_.Model;

namespace EvernoteClone.ViewModel
{
    public class LoginVM {
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommandop { get; set; }
        public LoginVM()
        {
            RegisterCommandop = new(this);
            LoginCommand = new(this);
        }
    }
}
