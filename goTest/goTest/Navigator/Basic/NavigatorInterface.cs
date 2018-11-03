using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Navigator.Basic
{
    interface NavigatorInterface
    {
        void navigateTo(string viewsName);
        void addView(NavigatorsView view);
        void navigateToPreviousView();
        void navigateToNextView();
        string getCurrentViewsName();
    }
}
