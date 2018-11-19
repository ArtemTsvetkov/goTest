using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.Exceptions
{
    class NoConfigurationSpecified : Exception, ConcreteException
    {
        public NoConfigurationSpecified() : base() { }

        public NoConfigurationSpecified(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<InformationPopupWindowConfig> view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                "Не найден файл с базой данных: goTest.db.");
            view.setConfig(config);
            view.show();
        }
    }
}
