using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfRepetitions
{
    internal class CalculationViewModel: INotifyPropertyChanged
    {
        private int _count;
        private string _symbol;
        private List<string> _pathsList = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Количество повторений символа
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        /// <summary>
        /// Символ с наибольшим количеством повторений
        /// </summary>
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        /// <summary>
        /// Список путей файлов
        /// </summary>
        public List<string> Paths
        {
            get { return _pathsList; }
            set
            {
                _pathsList = value;
                OnPropertyChanged("Paths");
            }
        }

        /// <summary>
        /// Вычисление количества повторяемого символа
        /// </summary>
        public void Calculation()
        {
            var alg = new Algorithm();
            var reader = new Reader();
            var fileData = new FilesData();
            var resultList = new List<object>();
            try
            {
                fileData.Data = reader.ReadFiles(_pathsList);
                resultList = alg.CountofSymbol(fileData.Data);

                Symbol = resultList[0].ToString();
                Count = (int)resultList[1];
            } catch { throw; }
        }
    }
}
