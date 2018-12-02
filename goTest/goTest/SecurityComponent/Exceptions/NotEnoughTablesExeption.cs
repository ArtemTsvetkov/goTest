using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class NotEnoughTablesExeption : Exception, ConcreteException
    {
        public NotEnoughTablesExeption() : base() { }

        public NotEnoughTablesExeption(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<InformationPopupWindowConfig> view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(
                "В базе данных отсутствуют необходимые таблицы или(и) объекты.");
            view.setConfig(config);
            view.show();
        }
    }
}
