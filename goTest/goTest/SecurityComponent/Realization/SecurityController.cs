using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.SecurityComponent.Exceptions;
using goTest.SecurityComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class SecurityController : SecurityControllerInterface
    {
        private SecurityModel model;

        public SecurityController(SecurityModel model)
        {
            this.model = model;
        }

        public void addNewUser(string login, string password)
        {
            try
            {
                SecurityUserInterface user = new SecurityUser(login, password);

                model.addNewUser(user);
                Navigator.Navigator.getInstance().navigateToPreviousView();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void changeUserPassword(string oldPassword, string newPassword)
        {
            try
            {
                model.changeUserPassword(oldPassword, newPassword);
                Navigator.Navigator.getInstance().navigateToPreviousView();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void checkDataBase()
        {
            model.loadStore();
        }

        public void setConfig(string login, string password)
        {
            SecurityUserInterface user = new SecurityUser(login, password);
            user.setAdmin(false);
            model.setConfig(user);
        }

        public void signIn()
        {
            try
            {
                if (model.checkUser())
                {
                    model.signIn();
                }
                else
                {
                    throw new IncorrectUserData("Invalid login or password");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void signInAsStudent()
        {
            try
            {
                model.signInAsStudent();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void signOut()
        {
            model.signOut();
        }
    }
}
