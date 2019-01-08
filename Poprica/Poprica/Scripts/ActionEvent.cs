using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct ActionEvent
    {
        public Action<int[]> method;
        public int[] args;

        public ActionEvent(Action<int[]> _method, int[] _args)
        {
            method = _method;
            args = _args;
        }
    }
}
