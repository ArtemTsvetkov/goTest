using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Encryption.Realization.Exceptions
{
    class NotSupportKeysLength : Exception, ConcreteException
    {
        public NotSupportKeysLength() : base() { }

        public NotSupportKeysLength(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<InformationPopupWindowConfig> view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                "Неподдерживаемая длинна ключа. Обратитесь к администратору.");
            view.setConfig(config);
            view.show();
        }
    }
}
