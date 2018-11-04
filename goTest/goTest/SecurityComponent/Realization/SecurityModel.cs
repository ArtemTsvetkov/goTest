using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using goTest.CommonComponents.InitialyzerComponent.ReadConfig;
using goTest.CommonComponents.WorkWithData;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Configs;
using goTest.SecurityComponent.Exceptions;
using goTest.SecurityComponent.Hashing;
using goTest.SecurityComponent.Hashing.Realization;
using goTest.SecurityComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class SecurityModel : BasicModel<SecurityUserInterface, SecurityUserInterface>,
        SecurityModelInterface<SecurityUserInterface>
    {
        private SecurityQueryConfigurator queryConfigurator;
        private SecurityUserInterface currentUser;
        private HashWorkerInterface<HashConfig> hashWorker;
        private DataBaseChecker<SqlLiteCheckerConfig> dbCheker;

        public SecurityModel()
        {
            queryConfigurator = new SecurityMsSqlServerQueryConfigurator();
            hashWorker = new HashWorker();
            HashConfig hc = new HashConfig();
            hc.numberOfHashing = 100000;
            hc.sultLength = 20;
            hashWorker.setConfig(hc);
            dbCheker = new SqlLiteDbChecker(queryConfigurator);
        }

        public void addNewUser(SecurityUserInterface user)
        {
            string sult = hashWorker.getSult(user);

            SqlLiteSimpleExecute.execute(queryConfigurator.addNewUser(
                user.getLogin(), hashWorker.getHash(user.getPassword(), sult),
                sult));
            InformationPopupWindow view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                "Пользователь: " + user.getLogin() + " успешно добавлен!");
            view.setConfig(config);
            view.show();
        }

        public void changeUserPassword(string oldPassword, string newPassword)
        {
            if (currentUser.isEnterIntoSystem())
            {
                string currentPassword = hashWorker.getHash(oldPassword, getSultForCurrentUser());

                if (DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(queryConfigurator.checkUser(
                        currentUser.getLogin(), currentPassword))) == 1)
                {
                    SqlLiteSimpleExecute.execute(
                        queryConfigurator.changePassword(currentUser.getLogin(),
                        hashWorker.getHash(newPassword, getSultForCurrentUser())));

                    currentUser.setPassword(newPassword);

                    InformationPopupWindow view = new InformationPopupWindow();
                    InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                        "Пароль успешно изменен");
                    view.setConfig(config);
                    view.show();
                }
                else
                {
                    throw new IncorrectOldPassword("Exception: old password is not a right");
                }
            }
            else
            {
                throw new InsufficientPermissionsException("This user does not"
                   + "have sufficient rights to perform the specified operation");
            }
        }

        private string getSultForCurrentUser()
        {
            string currentSult = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.getSult(
                currentUser.getLogin())));

            return currentSult;
        }

        public override SecurityUserInterface getResult()
        {
            return currentUser.copy();
        }

        public override void loadStore()
        {
            SqlLiteCheckerConfig config = new SqlLiteCheckerConfig();
            config.dbPath = ConfigReader.getInstance().getDbPath();
            try
            {
                dbCheker.check(config);
            }
            catch(NotEnoughTablesExeption ex)
            {
                ExceptionHandler.getInstance().processing(ex);
                createTables();
                loadStore();
            }
            catch(AdminIsNotExist ex)
            {
                Navigator.Navigator.getInstance().navigateTo("CreateAdminView");
            }
        }

        public override void setConfig(SecurityUserInterface configData)
        {
            currentUser = configData.copy();
        }

        public void signIn()
        {
            currentUser.setEnterIntoSystem(true);

            notifyObservers();
        } 

        public bool checkUser()
        {
            if (currentUser.isEnterIntoSystem())
            {
                return true;
            }
            else
            {
                if (DataSetConverter.fromDsToSingle.toString.convert(
                        SqlLiteSimpleExecute.execute(queryConfigurator.getSult(
                        currentUser.getLogin()))) == null)
                {
                    return false;
                }

                string currentPassword = hashWorker.getHash(currentUser.getPassword(),
                    getSultForCurrentUser());


                if (DataSetConverter.fromDsToSingle.toInt.convert(
                        SqlLiteSimpleExecute.execute(queryConfigurator.checkUser(
                        currentUser.getLogin(), currentPassword))) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void signOut()
        {
            currentUser.setEnterIntoSystem(false);
            currentUser.setPassword("");

            notifyObservers();
        }

        public void createTables()
        {
            //Previous delete all tables
            string[] querys = queryConfigurator.clearDataBase();
            for (int i = 0; i < querys.Count(); i++)
            {
                try
                {
                    SqlLiteSimpleExecute.execute(querys[i]);
                }
                catch(Exception ex)
                {
                    if(!ex.Message.Contains("SQL logic error\r\nno such table"))
                    {
                        ExceptionHandler.getInstance().processing(ex);
                    }
                }
            }
            //Create tables
            querys = queryConfigurator.createDataBase();
            for (int i = 0; i < querys.Count(); i++)
            {
                try
                {
                    SqlLiteSimpleExecute.execute(querys[i]);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
        }
    }
}
