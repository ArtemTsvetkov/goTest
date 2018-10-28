using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class InsufficientPermissionsException : Exception, ConcreteException
    {
        public InsufficientPermissionsException() : base() { }

        public InsufficientPermissionsException(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "У данного пользователя недостаточно прав для выполнения заданной операции");
            view.setConfig(config);
            view.show();
        }
    }
}
