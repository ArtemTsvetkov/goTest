using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Interfaces
{
    interface DataBaseChecker<TconfigType>
    {
        bool check(TconfigType config);
    }
}
