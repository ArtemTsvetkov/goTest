using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class GoTestObjectNotFound : Exception, ConcreteException
    {
        public GoTestObjectNotFound() : base() { }

        public GoTestObjectNotFound(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Объект компоненты goTest не найден.");
            view.setConfig(config);
            view.show();
        }
    }
}
