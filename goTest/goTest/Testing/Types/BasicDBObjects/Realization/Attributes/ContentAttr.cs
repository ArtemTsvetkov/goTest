﻿using goTest.Testing.Types.BasicDBObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.BasicDBObjects.Realization.Attributes
{
    class ContentAttr : DbObject
    {
        public string getName()
        {
            return "Content";
        }
    }
}