using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class EqualsTestExceptions : Exception, ConcreteException
    {
        public EqualsTestExceptions() : base() { }

        public EqualsTestExceptions(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Нельзя добавить два одинаковых теста для одной и той же дисциплины.");
            view.setConfig(config);
            view.show();
        }
    }
}
