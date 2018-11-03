using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface SecurityModelInterface<TTypeOfResult>
    {
        void signIn();
        void signOut();
        void addNewUser(SecurityUserInterface user);
        void changeUserPassword(string oldPassword, string newPassword);
        bool checkUser();
    }
}
