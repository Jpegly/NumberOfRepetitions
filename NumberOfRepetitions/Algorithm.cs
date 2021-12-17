using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRepetitions
{
    internal class Algorithm
    {
        public Algorithm()
        {

        }

        /// <summary>
        /// Вычисляет символ с наибольшим количеством повторений и количество повторений
        /// </summary>
        public List<object> CountofSymbol(List<string> valuesList)
        {
            var result = valuesList.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => new { x.Key, Count = x.Count() })
                .First();

            var list = new List<object>();
            list.Add(result.Key);
            list.Add(result.Count);

            return list;
        }
    }
}
            
