using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestQueryConfiguratorI
    {
        string updateSubject(string oldName, string newName);
        string createSubject(string name);
        string getSubjectId(string subjectName);
    }
}
