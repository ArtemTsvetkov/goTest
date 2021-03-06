﻿using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Unswer
    {
        private string content;
        private bool isRight;
        private int id;
        private bool isDeleted;

        public Unswer()
        {
            IsDeleted = false;
        }

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public void isValid()
        {
            if (content == null)
            {
                throw new ObjectNotValid("Ответ: " + id + " не содержит контент");
            }
            else
            {
                if (content.Equals(""))
                {
                    throw new ObjectNotValid("Ответ: " + id + " не содержит контент");
                }
            }
        }

        public bool compare(Unswer unswer)
        {
            if (!unswer.content.Equals(content))
            {
                return false;
            }
            if (!unswer.isRight.Equals(isRight))
            {
                return false;
            }

            return true;
        }

        public Unswer copy()
        {
            Unswer copy = new Unswer();
            copy.content = content;
            copy.id = id;
            copy.isRight = isRight;
            copy.isDeleted = isDeleted;

            return copy;
        }

        public bool IsRight
        {
            get
            {
                return isRight;
            }

            set
            {
                isRight = value;
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

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
            }
        }

        public void delete()
        {
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
