using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class IncorrectUserData : Exception, ConcreteException
    {
        public IncorrectUserData() : base() { }

        public IncorrectUserData(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Указаны неверные логин или пароль");
            view.setConfig(config);
            view.show();
        }
    }
}
