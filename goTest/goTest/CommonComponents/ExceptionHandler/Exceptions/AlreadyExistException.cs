using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.ExceptionHandler.Exceptions
{
    class AlreadyExistException : Exception, ConcreteException
    {
        public AlreadyExistException() : base() { }

        public AlreadyExistException(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<InformationPopupWindowConfig> view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig("Исключение " +
                ex.GetType() + " было добавлено ранее, оно будет пропущено!");
            view.setConfig(config);
            view.show();
        }
    }
}
