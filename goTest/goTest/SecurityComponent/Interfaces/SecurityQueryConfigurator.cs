using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface SecurityQueryConfigurator
    {
        string getSult(int userId);
        string setSult(int userId, string sult);
        string setPassword(int userId, string password);
        string getUserId(string login);
        string changePassword(string login, string newPassword);
        string checkUser(string login, string password);
        string checkDbTables();
        string checkExistAdmin();
        string[] clearDataBase();
        string[] createDataBase();
    }
}
