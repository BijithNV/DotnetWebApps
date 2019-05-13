using TwitterClone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.PageModels
{
    public class AccountSettingsPageModel
    {
        public string SuccessMessage { get; private set; }

        public TwitterCloneUserViewModel UserVM { get; set; }

        public void SetMessage(string a_actionTaken)
        {
            if (a_actionTaken == "PasswordChanged")
            {
                SuccessMessage = "You successfully changed your password.";
            }
        }
    }
}
