using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.Interfaces
{
    interface Model<TTypeOfResult, TConfigType>
    {
        void setConfig(TConfigType configData);
        void loadStore();//загрузка исходных данных откуда-то
        void subscribe(Observer newObserver);//подписка на модель
        TTypeOfResult getResult();
    }
}
