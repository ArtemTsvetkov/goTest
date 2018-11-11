using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestControllerI
    {
        void createSubject(string name);
        void createTest(string name, string subject, int questionsNumber, 
            int requeredUnswersNumber);
        void updateSubject(string oldName, string newName);
        void addEmptyQuestonArea();
        void deleteQuestion(int row);
        void addEmptyUnswerArea();
        void deleteUnswer(int row);
    }
}
