using goTest.SecurityComponent.Interfaces;
using goTest.Testing.Types;
using goTest.Testing.Types.BasicDBObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class SecurityMsSqlServerQueryConfigurator : SecurityQueryConfigurator
    {
        public string getSult(int userId)
        {
            return "SELECT value FROM Parameters WHERE object_id=" +
                userId + " AND attr_id=(SELECT id FROM Attributes WHERE Name='Sult')";
        }

        public string setSult(int userId, string sult)
        {
            return "INSERT INTO Parameters VALUES(" +
                userId + ",(SELECT id FROM Attributes WHERE Name='Sult'),'" + sult + "')";
        }

        public string setPassword(int userId, string password)
        {
            return "INSERT INTO Parameters VALUES(" +
                userId + ",(SELECT id FROM Attributes WHERE Name='Password'),'" + password + "')";
        }

        public string getUserId(string login)
        {
            return "SELECT id FROM Objects WHERE name='" + login + 
                "' and type=(SELECT id FROM Types WHERE name='User')";
        }

        public string changePassword(string login, string newPassword)
        {
            return "UPDATE Parameters SET value='" + newPassword +
                "' WHERE object_id=" + login + " AND attr_id=(SELECT id " + 
                "FROM Attributes WHERE Name='Password')";
        }

        public string checkUser(string login, string password)
        {
            return "SELECT COUNT(*) FROM Objects WHERE name='" + login +
                "' AND type=(SELECT id FROM Types WHERE name='User') " +
                "AND (SELECT value FROM Parameters WHERE object_id=(" + getUserId(login) +
                ") AND attr_id=(SELECT id FROM Attributes WHERE Name='Password'))='" +
                password + "'";
        }

        public string checkDbTables()
        {
            return "SELECT name FROM sqlite_master WHERE type IN ('table','view') "+
                "AND name NOT LIKE 'sqlite_%' ORDER BY 1";
        }

        public string checkExistAdmin()
        {
            return "SELECT COUNT(*) FROM Parameters WHERE object_id=" +
                "(SELECT id FROM Objects WHERE name='Admin' AND type=(" +
                "SELECT id FROM Types WHERE name='User'))AND attr_id=(" + 
                "SELECT id FROM Attributes WHERE Name='Password')";
        }

        public string[] clearDataBase()
        {
            string[] result = new string[6];
            result[0] = "drop table Types";
            result[1] = "drop table Objects";
            result[2] = "drop table Attributes";
            result[3] = "drop table Schemas";
            result[4] = "drop table Parameters";
            result[5] = "drop table Objects_references";

            return result;
        }

        public string[] createDataBase()
        {
            string[] result = new string[42];
            result[0] = "CREATE TABLE Types(id integer PRIMARY KEY AUTOINCREMENT" +
                " NOT NULL, name text UNIQUE NOT NULL)";
            result[1] = "CREATE TABLE Objects(id integer PRIMARY KEY AUTOINCREMENT " +
                "NOT NULL, parent_id integer, name text NOT NULL, type integer NOT" +
                " NULL, FOREIGN KEY (type) REFERENCES Types(id), FOREIGN KEY (par" +
                "ent_id) REFERENCES Objects(id))";
            result[2] = "CREATE TABLE Attributes(id integer PRIMARY KEY AUTOINCREMENT" +
                " NOT NULL, name text UNIQUE NOT NULL, description text)";
            result[3] = "CREATE TABLE Schemas(id integer NOT NULL, type_id integer N" +
                "OT NULL, attr_id integer NOT NULL, FOREIGN KEY (id) REFERENCES Ob" +
                "jects(id), FOREIGN KEY (type_id) REFERENCES Types(id), FOREIGN KEY (" +
                "attr_id) REFERENCES Attributes(id))";
            result[4] = "CREATE TABLE Parameters(object_id integer NOT NULL, attr_i" +
                "d integer NOT NULL, value text NOT NULL, FOREIGN KEY (object_id) REF" +
                "ERENCES Objects(id), FOREIGN KEY (attr_id) REFERENCES Attributes(id))";
            result[5] = "CREATE TABLE Objects_references(object_id integer NOT NULL, r" +
                "eference integer NOT NULL, attr_id integer NOT NULL, FOREIGN KEY (o" +
                "bject_id) REFERENCES Objects(id), FOREIGN KEY (reference) REFERENCES " +
                "Objects(id), FOREIGN KEY (attr_id) REFERENCES Attributes(id))";
            result[6] = "INSERT INTO Types VALUES(null, 'Subject');";
            result[7] = "INSERT INTO Types VALUES(null, 'Test');";
            result[8] = "INSERT INTO Types VALUES(null, 'Question');";
            result[9] = "INSERT INTO Types VALUES(null, 'Unswer');";
            result[10] = "INSERT INTO Types VALUES(null, 'Schema');";
            result[11] = "INSERT INTO Types VALUES(null, 'Question type');";
            result[12] = "INSERT INTO Types VALUES(null, 'Unswer type');";
            result[13] = "INSERT INTO Types VALUES(null,'Develop status');";
            result[14] = "INSERT INTO Objects VALUES(null, null, 'Main Schema', " + 
                "(SELECT id FROM Types WHERE Name='Schema'));";
            result[15] = "INSERT INTO Attributes VALUES(null, 'Questions count', 'Q" + 
                "uestions count for concrete test');";
            result[16] = "INSERT INTO Attributes VALUES(null, 'Required questions', '" + 
                "Required questions for concrete test');";
            result[17] = "INSERT INTO Attributes VALUES(null, 'Questions type', 'Ques" + 
                "tions type, determine in reference table');";
            result[18] = "INSERT INTO Attributes VALUES(null, 'Content', 'Conctere obje" + 
                "cts content, example: questions text, unswers test');";
            result[19] = "INSERT INTO Attributes VALUES(null, 'Unswers type', 'Unswer" + 
                "s type, determine in reference table');";
            result[20] = "INSERT INTO Attributes VALUES(null, 'Develop status', 'System" +
                " attrbute, wich show object status, if equals approve, then object r" +
                "eady to use, if this attr not set for concrete object, but objects type u" + 
                "se this attr, then object not ready to use');";
            result[21] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name='" +
                "Main Schema'), (SELECT id FROM Types WHERE Name='Test'), (SELECT id FROM " + 
                "Attributes WHERE Name='Questions count'));";
            result[22] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Test'), (SELECT id FROM" + 
                " Attributes WHERE Name='Required questions'));";
            result[23] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Question'), (SELECT id " + 
                "FROM Attributes WHERE Name='Questions type'));";
            result[24] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name='" +
                "Main Schema'), (SELECT id FROM Types WHERE Name='Question'), (SELECT id F" + 
                "ROM Attributes WHERE Name='Content'));";
            result[25] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name='" +
                "Main Schema'), (SELECT id FROM Types WHERE Name='Unswer'), (SELECT id F" + 
                "ROM Attributes WHERE Name='Content'));";
            result[26] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Unswer'), (SELECT id" + 
                " FROM Attributes WHERE Name='Unswers type'));";
            result[27] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Subject'), (SELECT id " + 
                "FROM Attributes WHERE Name='Develop status'));";
            result[28] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Test'), (SELECT id FRO" + 
                "M Attributes WHERE Name='Develop status'));";
            result[29] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Question'), (SELECT id " + 
                "FROM Attributes WHERE Name='Develop status'));";
            result[30] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE Name=" +
                "'Main Schema'), (SELECT id FROM Types WHERE Name='Unswer'), (SELECT id FRO" + 
                "M Attributes WHERE Name='Develop status'));";
            result[31] = "INSERT INTO Objects VALUES(null, null, 'Single unswer question'" + 
                ", (SELECT id FROM Types WHERE Name='Question type'));";
            result[32] = "INSERT INTO Objects VALUES(null, null, 'Multiply unswer questio" + 
                "n', (SELECT id FROM Types WHERE Name='Question type'));";
            result[33] = "INSERT INTO Objects VALUES(null, null, 'Right unswer', (SELECT id" + 
                " FROM Types WHERE Name='Unswer type'));";
            result[34] = "INSERT INTO Objects VALUES(null, null, 'Unswer', (SELECT id FROM" + 
                " Types WHERE Name='Unswer type'));";
            result[35] = "INSERT INTO Objects VALUES(null, null, 'In approve status', (SE" + 
                "LECT id FROM Types WHERE Name='Develop status'));";
            result[36] = "INSERT INTO Types VALUES(null,'User');";
            result[37] = "INSERT INTO Objects VALUES(null, null, 'Admin'," + " (SELECT id FROM Types WHERE Name='User'));";
            result[38] = "INSERT INTO Attributes VALUES(null, 'Sult', 'Sult');";
            result[39] = "INSERT INTO Attributes VALUES(null, 'Password', 'Password');";
            result[40] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE" +
                " Name='Main Schema'), (SELECT id FROM Types WHERE Name='User'), (" + 
                "SELECT id FROM Attributes WHERE Name='Sult'));";
            result[41] = "INSERT INTO Schemas VALUES((SELECT id FROM Objects WHERE " +
                "Name='Main Schema'), (SELECT id FROM Types WHERE Name='User'), (SELE" + 
                "CT id FROM Attributes WHERE Name='Password'));";

            return result;
        }
    }
}
