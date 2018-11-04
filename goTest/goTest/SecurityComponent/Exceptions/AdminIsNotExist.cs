﻿using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Exceptions
{
    class AdminIsNotExist : Exception, ConcreteException
    {
        public AdminIsNotExist() : base() { }

        public AdminIsNotExist(string message) : base(message) { }

        public void processing(Exception ex)
        {
            ExceptionViewInterface<ErrorPopupWindowConfig> view = new ErrorPopupWindow();
            ErrorPopupWindowConfig config = new ErrorPopupWindowConfig(
                "В базе данных отсутствуют администратор. Пожалуйста, создайте пароль для "+
                "этого пользователя.");
            view.setConfig(config);
            view.show();
        }
    }
}
