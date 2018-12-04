using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface SecurityControllerInterface
    {
        void signIn();
        //this user only use go test function
        void signInAsStudent();
        void signOut();
        void changeUserPassword(string oldPassword, string newPassword);
        void addNewUser(string login, string password);
        void setConfig(string login, string password);
        void checkDataBase();
    }
}
