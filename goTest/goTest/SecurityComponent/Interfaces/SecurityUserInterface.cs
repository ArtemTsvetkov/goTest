using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface SecurityUserInterface
    {
        string getPassword();
        string getLogin();
        bool isEnterIntoSystem();
        void setEnterIntoSystem(bool isEnter);
        SecurityUserInterface copy();
        void setPassword(string password);
        void setAdmin(bool isAdmin);
        bool isAdmin();
    }
}
