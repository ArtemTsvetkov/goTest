using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class ObjectAlreadyCreated : Exception, ConcreteException
    {
        public ObjectAlreadyCreated() : base() { }

        public ObjectAlreadyCreated(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Такой объект уже существует в базе данных");
            view.setConfig(config);
            view.show();
        }
    }
}
