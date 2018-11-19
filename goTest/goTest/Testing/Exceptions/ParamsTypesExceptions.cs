﻿using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class ParamsTypesExceptions : Exception, ConcreteException
    {
        public ParamsTypesExceptions() : base() { }

        public ParamsTypesExceptions(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "В БД обнаружен неизвестный тип параметра");
            view.setConfig(config);
            view.show();
        }
    }
}