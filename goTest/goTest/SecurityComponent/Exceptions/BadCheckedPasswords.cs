using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class BadCheckedPasswords : Exception, ConcreteException
    {
        public BadCheckedPasswords() : base() { }

        public BadCheckedPasswords(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Указаныe (новые) пароли должны совпадать и быть не пустыми!");
            view.setConfig(config);
            view.show();
        }
    }
}
