﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow
{
    class InformationPopupWindowConfig
    {
        private string message;

        public InformationPopupWindowConfig(string message)
        {
            this.message = message;
        }

        public string getMessage()
        {
            return message;
        }
    }
}
