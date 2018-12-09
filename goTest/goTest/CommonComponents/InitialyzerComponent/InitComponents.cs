using goTest.SecurityComponent.Interfaces;
using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.InitialyzerComponent
{
    class InitComponents
    {
        public SecurityControllerInterface securityController;
        public GoTestControllerI goTestController;
        public GoTestAdapterI сreateSubjectViewAdapter;
        public GoTestAdapterI questionsViewAdapter;
        public GoTestAdapterI updateSubjectViewAdapter;
    }
}
