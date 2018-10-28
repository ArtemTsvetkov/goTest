using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Navigator.Exceptions
{
    class ViewsHistoryIsEmtptyException : Exception, ConcreteException
    {
        public ViewsHistoryIsEmtptyException() : base() { }

        public ViewsHistoryIsEmtptyException(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Ошибка: вызов view из чистой истории просмотров");
            view.setConfig(config);
            view.show();
        }
    }
}
