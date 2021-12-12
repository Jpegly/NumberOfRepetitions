using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRepetitions
{
    internal class Values
    {
        private List<string> _listValues = new List<string>();
        public List<string> ListValues
        {
            get
            {
                _listValues.Sort();
                return _listValues;
            }
        }
    }
}
