using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Navigator.Exceptions
{
    class ViewAlreadyAddedException : Exception, ConcreteException
    {
        public ViewAlreadyAddedException() : base() { }

        public ViewAlreadyAddedException(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Попытка добавления в навигатор нескольких view с одинаковыми названиями");
            view.setConfig(config);
            view.show();
        }
    }
}
