using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class IncorrectOldPassword : Exception, ConcreteException
    {
        public IncorrectOldPassword() : base() { }

        public IncorrectOldPassword(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Ошибка: старый пароль введен неверно");
            view.setConfig(config);
            view.show();
        }
    }
}
