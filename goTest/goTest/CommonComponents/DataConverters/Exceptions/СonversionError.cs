using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Exceptions
{
    class СonversionError : Exception, ConcreteException
    {
        public СonversionError() : base() { }

        public СonversionError(string message) : base(message) {}

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Ошибка преобразования типов. Обратитесь к администратору."+ ex.Message);
            view.setConfig(config);
            view.show();
        }
    }
}
