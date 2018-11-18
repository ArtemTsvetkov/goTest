using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class EqualsQuestionsExceptions : Exception, ConcreteException
    {
        public EqualsQuestionsExceptions() : base() { }

        public EqualsQuestionsExceptions(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "Нельзя добавить два одинаковых вопроса в один и тот же тест.");
            view.setConfig(config);
            view.show();
        }
    }
}
