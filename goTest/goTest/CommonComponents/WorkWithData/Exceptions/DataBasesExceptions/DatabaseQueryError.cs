using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.WorkWithData.Exceptions.DataBasesExceptions
{
    class DatabaseQueryError : Exception, ConcreteException
    {
        public DatabaseQueryError() : base() { }

        public DatabaseQueryError(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Синтаксическая ошибка в запросе к БД");
            view.setConfig(config);
            view.show();
        }
    }
}