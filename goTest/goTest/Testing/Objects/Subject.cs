using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Realization;
using goTest.Testing.Realization.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Subject
    {
        private string name;
        private int id;
        private List<Test> tests;

        public Subject()
        {
            tests = new List<Test>();
        }

        public void isValid()
        {
            if(id<=0)
            {
                throw new ObjectNotValid("Один из предметов не содержит идентификатор, обратитесь" +
                    " к администратору");
            }
            if(name==null)
            {
                throw new ObjectNotValid("У предмета с id:"+id+" не задано имя");
            }
            else
            {
                if(name.Equals(""))
                {
                    throw new ObjectNotValid("У предмета с id:" + id + " не задано имя");
                }
            }
            for(int i=0; i<tests.Count; i++)
            {
                tests.ElementAt(i).isValid();
            }
        }

        public IntHierarchy searchObjectIndex(int objectId)
        {
            try
            {
                return getTestIndex(objectId);
            }
            catch(GoTestObjectNotFound ex)
            {
                return getChildIndex(objectId);
            }
        }

        private IntHierarchy getTestIndex(int testId)
        {
            for (int i = 0; i < tests.Count; i++)
            {
                if (tests.ElementAt(i).Id == testId)
                {
                    IntHierarchy hi = new IntHierarchy(new Test().GetType());
                    hi.value = i;
                    return hi;
                }
            }

            throw new GoTestObjectNotFound();
        }

        private IntHierarchy getChildIndex(int id)
        {
            for (int i = 0; i < tests.Count; i++)
            {
                try
                {
                    IntHierarchy hi = new IntHierarchy(new Test().GetType(), 
                        tests.ElementAt(i).searchObjectIndex(id));
                    hi.value = i;
                    return hi;
                }
                catch(GoTestObjectNotFound ex)
                {
                }
            }

            throw new GoTestObjectNotFound();
        }

        public Subject copy()
        {
            Subject copy = new Subject();
            copy.name = name;
            copy.id = id;
            for(int i=0; i<tests.Count; i++)
            {
                copy.tests.Add(tests.ElementAt(i).copy());
            }

            return copy;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        internal List<Test> Tests
        {
            get
            {
                return tests;
            }

            set
            {
                tests = value;
            }
        }

        public void delete()
        {
            for (int i = 0; i < Tests.Count; i++)
            {
                Tests.ElementAt(i).delete();
            }
            deleteSelf();
        }

        private void deleteSelf()
        {
            GoTestQueryConfiguratorI queryConfigurator = new GoTestQueryConfigurator();
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectReferences(id));
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectParameters(id));
            SqlLiteSimpleExecute.execute(queryConfigurator.deleteObjectFromObjectsTable(id));
        }
    }
}
