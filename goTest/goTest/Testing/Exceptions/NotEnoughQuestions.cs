using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class NotEnoughQuestions : Exception, ConcreteException
    {
        public NotEnoughQuestions() : base() { }

        public NotEnoughQuestions(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "В базе данных недостаточно вопросов для загрузки объекта-теста.");
            view.setConfig(config);
            view.show();
        }
    }
}
