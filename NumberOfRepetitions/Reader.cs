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
        private int _countFile = 4;

        public Reader(Values values)
        {
            ReadJSON(values);
            ReadXML(values);
        }
        private void ReadJSON(Values values)
        {
            for (int i = 1; i < _countFile; i++)
            {
                var obj = JObject.Parse(File.ReadAllText($"D:\\TestTask\\Files\\file_{_countFile}.json"));
                try
                {
                    foreach (var element in obj)
                    {
                        foreach (var v in element.Value)
                        {
                            values.ListValues.Add(v.ToString());
                        }
                    }
                }
                catch { }
            }
        }

        private void ReadXML(Values values)
        {
            for (int i = 1; i < _countFile; i++)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load($"D:\\TestTask\\Files\\file_{_countFile}.xml");
                try
                {
                    XmlElement elements = doc.DocumentElement;

                    foreach (XmlElement element in elements)
                    {
                        foreach (XmlNode childnode in element.ChildNodes)
                        {
                            if (childnode.Name == "Value")
                            {
                                values.ListValues.Add(childnode.InnerText);
                            }
                        }
                    }
                }catch { }
            }
        }
    }
}
