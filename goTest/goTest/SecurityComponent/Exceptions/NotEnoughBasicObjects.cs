using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class NotEnoughBasicObjects : Exception, ConcreteException
    {
        public NotEnoughBasicObjects() : base() { }

        public NotEnoughBasicObjects(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "В базе данных отсутствует базовый объект:"+ex.Message);
            view.setConfig(config);
            view.show();
        }
    }
}
