using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCuocDT
{
    interface IFormAction
    {
        void RefreshData();
        void New();
        void Save();
        void Delete();
    }
}
