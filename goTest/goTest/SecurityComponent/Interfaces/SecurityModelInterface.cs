using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface SecurityModelInterface<TTypeOfResult>
    {
        //Sign in as admin
        void signIn();
        //Sign in as student, this is user only use go test function
        void signInAsStudent();
        void signOut();
        void addNewUser(SecurityUserInterface user);
        void changeUserPassword(string oldPassword, string newPassword);
        bool checkUser();
    }
}
