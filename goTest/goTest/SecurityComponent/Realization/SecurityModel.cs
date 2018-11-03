using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using goTest.CommonComponents.WorkWithData;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
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
        private DataSetConverter dataSetConverter = new DataSetConverter();
        private SecurityQueryConfigurator queryConfigurator;
        private SecurityUserInterface currentUser;
        private HashWorkerInterface<HashConfig> hashWorker;

        public SecurityModel()
        {
            queryConfigurator = new SecurityMsSqlServerQueryConfigurator();
            hashWorker = new HashWorker();
            HashConfig hc = new HashConfig();
            hc.numberOfHashing = 100000;
            hc.sultLength = 20;
            hashWorker.setConfig(hc);
        }

        public void addNewUser(SecurityUserInterface user)
        {
            if (currentUser.isEnterIntoSystem())
            {
                string sult = hashWorker.getSult(user);
                //Проверка, есть ли уже такой пользователь
                if (dataSetConverter.fromDsToSingle.toString.convert(
                        configDataWorkerForWorkWithBDAndExecute(queryConfigurator.getSult(
                        currentUser.getLogin()))) == null)
                {

                    configDataWorkerForWorkWithBDAndExecute(queryConfigurator.addNewUser(
                        user.getLogin(), hashWorker.getHash(user.getPassword(), sult),
                        sult));
                    InformationPopupWindow view = new InformationPopupWindow();
                    InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                        "Пользователь: " + user.getLogin() + " успешно добавлен!");
                    view.setConfig(config);
                    view.show();
                }
                else
                {
                    InformationPopupWindow view = new InformationPopupWindow();
                    InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                        "Логин: " + user.getLogin() + " был ранее добавлен в систему, " +
                        "пожалуйста, придумайте другой");
                    view.setConfig(config);
                    view.show();
                }
            }
            else
            {
                throw new InsufficientPermissionsException("This user does not"
                   + "have sufficient rights to perform the specified operation");
            }
        }

        public void changeUserPassword(string oldPassword, string newPassword)
        {
            if (currentUser.isEnterIntoSystem())
            {
                string currentPassword = hashWorker.getHash(oldPassword, getSultForCurrentUser());

                if (dataSetConverter.fromDsToSingle.toInt.convert(
                        configDataWorkerForWorkWithBDAndExecute(queryConfigurator.checkUser(
                        currentUser.getLogin(), currentPassword))) == 1)
                {
                    configDataWorkerForWorkWithBDAndExecute(
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
            string currentSult = dataSetConverter.fromDsToSingle.toString.convert(
                configDataWorkerForWorkWithBDAndExecute(queryConfigurator.getSult(
                currentUser.getLogin())));

            return currentSult;
        }

        public override SecurityUserInterface getResult()
        {
            return currentUser.copy();
        }

        public override void loadStore()
        {
            throw new NotImplementedException();
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

        private DataSet configDataWorkerForWorkWithBDAndExecute(string query)
        {
            DataWorker<SqlLiteStateFields, DataSet> dataWorker = new SqlLiteDataWorker();
            SqlLiteStateFields configProxy =
                new SqlLiteStateFields(query);
            dataWorker.setConfig(configProxy);
            dataWorker.execute();
            return dataWorker.getResult();
        }

        public bool checkUser()
        {
            if (currentUser.isEnterIntoSystem())
            {
                return true;
            }
            else
            {
                if (dataSetConverter.fromDsToSingle.toString.convert(
                        configDataWorkerForWorkWithBDAndExecute(queryConfigurator.getSult(
                        currentUser.getLogin()))) == null)
                {
                    return false;
                }

                string currentPassword = hashWorker.getHash(currentUser.getPassword(),
                    getSultForCurrentUser());


                if (dataSetConverter.fromDsToSingle.toInt.convert(
                        configDataWorkerForWorkWithBDAndExecute(queryConfigurator.checkUser(
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
    }
}
