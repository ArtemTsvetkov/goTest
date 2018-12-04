using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class NotAllAreasIsFill : Exception, ConcreteException
    {
        public NotAllAreasIsFill() : base() { }

        public NotAllAreasIsFill(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Заполнены не все требуемые параметры.");
            view.setConfig(config);
            view.show();
        }
    }
}