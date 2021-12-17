using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace NumberOfRepetitions
{
    internal class Reader
    {
        public Reader()
        {
            
        }

        /// <summary>
        /// Считывание дынных с файлов
        /// </summary>
        public List<string> ReadFiles(List<string> listPaths)
        {
            List<string> valuesList = new List<string>();
            List<string> pathListXML = new List<string>();
            List<string> pathListJSON = new List<string>();

            foreach (string path in listPaths)
            {
                switch (Path.GetExtension(path))
                {
                    case ".xml":
                        pathListXML.Add(path);
                        break;
                    case ".json":
                        pathListJSON.Add(path);
                        break;
                }
            }
            valuesList.AddRange(ReadXML(pathListXML));
            valuesList.AddRange(ReadJSON(pathListJSON));

            return valuesList;
        }

        /// <summary>
        /// Считывание данных из файла с расширением .JSON
        /// </summary>
        private List<string> ReadJSON(List<string> listPaths)
        {
            List<string> valuesJSON = new List<string>();

            foreach (string path in listPaths)
            {
                try
                {
                    var obj = JObject.Parse(File.ReadAllText(path));
                    foreach (var element in obj)
                    {
                        foreach (var v in element.Value)
                        {
                            valuesJSON.Add(v.ToString());
                        }
                    }
                }
                catch
                { throw new ArgumentException("Файл не содержит данных!"); }
                
            }
            return valuesJSON;
        }

        /// <summary>
        /// Считывание данных из файла с расширением .XML
        /// </summary>
        private List<string> ReadXML(List<string> listPaths)
        {
            List<string> valuesXML = new List<string>();

            foreach(var path in listPaths)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlElement elements = doc.DocumentElement;

                    foreach (XmlElement element in elements)
                    {
                        foreach (XmlNode childnode in element.ChildNodes)
                        {
                            if (childnode.Name == "Value")
                            {
                                valuesXML.Add(childnode.InnerText);
                            }
                        }
                    }
                }
                catch { throw new ArgumentException("Файл не содержит данных!"); }
            }
            return valuesXML;
        }
    }
}
