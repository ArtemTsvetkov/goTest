using goTest.CommonComponents.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.InitialyzerComponent.ReadConfig
{
    class ConfigReader
    {
        private static ConfigReader reader;
        private string dbPath;

        private ConfigReader()
        {

        }

        public static ConfigReader getInstance()
        {
            if (reader == null)
            {
                reader = new ConfigReader();
            }

            return reader;
        }

        public void read()
        {
            string path = Directory.GetCurrentDirectory() + "\\goTest.db";
            if (testExistFile(path))
            {
                dbPath = path;
            }
            else
            {
                throw new NoConfigurationSpecified("No database file found: go Test.db.");
            }
        }

        //проверка, существует ли файл или можно ли его открыть
        private static bool testExistFile(string filePath)
        {
            try
            {
                FileStream file1 = new FileStream(filePath, FileMode.Open);
                file1.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string getDbPath()
        {
            return reader.dbPath;
        }
    }
}
