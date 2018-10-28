using goTest.CommonComponents.ExceptionHandler.Interfaces;
using goTest.CommonComponents.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goTest.CommonComponents.ExceptionHandler.View.Error.PopupWindow
{
    class ErrorPopupWindow : ExceptionViewInterface<ErrorPopupWindowConfig>
    {
        private ErrorPopupWindowConfig config;

        public void setConfig(ErrorPopupWindowConfig config)
        {
            this.config = config;
        }

        public void show()
        {
            try
            {
                if (config == null)
                {
                    throw new NoConfigurationSpecified("No configuration specified");
                }
                MessageBox.Show(
                    config.getMessage(),
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                ExceptionHandler.Realization.ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
