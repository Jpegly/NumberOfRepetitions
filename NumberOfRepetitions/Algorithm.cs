using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRepetitions
{
    internal class Algorithm
    {
        private int _countMax = 0;
        private string _symbolMax = string.Empty;
        public Algorithm(Values values)
        {
            CountofSymbol(values);
        }

        public string GetCountMax
        {
            get
            {
                return _countMax.ToString();
            }
        }

        public string GetSymbolMax
        {
            get
            {
                return _symbolMax.ToString();
            }
        }

        private void CountofSymbol(Values values)
        {
            string symbol = values.ListValues[0];
            int count = 0;

            foreach (string value in values.ListValues)
            {
                if (symbol.Equals(value))
                {
                    count++;
                }
                else
                {
                    if (count > _countMax)
                    {
                        _symbolMax = symbol;
                        _countMax = count;
                    }
                    count = 0;
                    symbol = value.ToString();
                    count++;
                }
            }
        }
    }
}
