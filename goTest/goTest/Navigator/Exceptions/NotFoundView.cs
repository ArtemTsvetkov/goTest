using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Navigator.Exceptions
{
    class NotFoundView : Exception, ConcreteException
    {
        public NotFoundView() : base() { }

        public NotFoundView(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Попытка вызова неизвестной view");
            view.setConfig(config);
            view.show();
        }
    }
}
