using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRepetitions
{
    internal class FilesData
    {
        private List<string> _dataList = new List<string>();

        /// <summary>
        /// Данные из файлов
        /// </summary>
        public List<string> Data
        {
            get
            {
                return _dataList;
            }
            set { _dataList = value; }
        }
    }
}
