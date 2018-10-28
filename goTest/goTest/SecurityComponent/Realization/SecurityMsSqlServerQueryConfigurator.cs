using goTest.SecurityComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class SecurityMsSqlServerQueryConfigurator : SecurityQueryConfigurator
    {
        public string getSult(string login)
        {
            return "SELECT Sult FROM UST WHERE Login='" + login +
                "'";
        }

        public string addNewUser(string login, string password, string sult)
        {
            return "INSERT INTO UST VALUES('" + login + "', '" + password +
                "', '" + sult + "' ,0)";
        }

        public string changePassword(string login, string newPassword)
        {
            return "UPDATE UST SET Password='" + newPassword +
                "' WHERE Login='" + login + "';";
        }

        public string checkUser(string login, string password)
        {
            return "SELECT COUNT(*) FROM UST WHERE Login='" + login +
                "' AND Password='" + password + "'";
        }

        public string checkUserStatus(string login)
        {
            return "SELECT Status FROM UST WHERE Login='" + login + "'";
        }
    }
}
