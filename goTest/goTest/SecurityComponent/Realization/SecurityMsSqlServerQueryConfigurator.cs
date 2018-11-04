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
            return "SELECT sult FROM Users WHERE login='" + login +
                "'";
        }

        public string addNewUser(string login, string password, string sult)
        {
            return "INSERT INTO Users VALUES(NULL, '" + login + "', '" + password +
                "', '" + sult + "')";
        }

        public string changePassword(string login, string newPassword)
        {
            return "UPDATE Users SET password='" + newPassword +
                "' WHERE login='" + login + "'";
        }

        public string checkUser(string login, string password)
        {
            return "SELECT COUNT(*) FROM Users WHERE login='" + login +
                "' AND password='" + password + "'";
        }

        public string checkDbTables()
        {
            return "SELECT name FROM sqlite_master WHERE type IN ('table','view') "+
                "AND name NOT LIKE 'sqlite_%' ORDER BY 1";
        }

        public string checkExistAdmin()
        {
            return "SELECT COUNT(*) FROM Users Where login='Admin'";
        }

        public string[] clearDataBase()
        {
            string[] result = new string[7];
            result[0] = "drop table Users";
            result[1] = "drop table Disciplines";
            result[2] = "drop table Tests";
            result[3] = "drop table Questions";
            result[4] = "drop table Parameters_types";
            result[5] = "drop table Parameters";
            result[6] = "drop table Unswers";

            return result;
        }

        public string[] createDataBase()
        {
            string[] result = new string[7];
            result[0] = "create table Users(id integer PRIMARY KEY AUTOINCREMENT NOT " + 
                "NULL,login text NOT NULL, password text NOT NULL, sult text NOT NULL)";
            result[1] = "create table Disciplines(id integer PRIMARY KEY AUTOINCREMENT " + 
                "NOT NULL, name text NOT NULL)";
            result[2] = "create table Tests(id integer PRIMARY KEY AUTOINCREMENT " +
                "NOT NULL, disciplines_id integer NOT NULL, name text NOT NULL, " +
                "questions_count integer, required_questions_count integer, " + 
                "FOREIGN KEY (disciplines_id) REFERENCES Disciplines(id))";
            result[3] = "create table Questions(id integer PRIMARY KEY " +
                "AUTOINCREMENT NOT NULL, disciplines_id integer NOT NULL, " +
                "content text NOT NULL, FOREIGN KEY (disciplines_id) REFERENCES " + 
                "Disciplines(id))";
            result[4] = "create table Parameters_types(id integer PRIMARY KEY " + 
                "AUTOINCREMENT NOT NULL, name text NOT NULL)";
            result[5] = "create table Parameters(id integer PRIMARY KEY " +
                "AUTOINCREMENT NOT NULL, questions_id integer NOT NULL, " +
                "parameters_type_id integer NOT NULL, value text NOT NULL, " +
                "FOREIGN KEY (questions_id) REFERENCES Questions(id), " + 
                "FOREIGN KEY (parameters_type_id) REFERENCES Parameters_types(id))";
            result[6] = "create table Unswers(id integer PRIMARY KEY " +
                "AUTOINCREMENT NOT NULL, parameters_id integer NOT NULL, " + 
                "FOREIGN KEY (parameters_id ) REFERENCES Parameters(id))";

            return result;
        }
    }
}
