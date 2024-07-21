using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleAppXml
{
    internal class XMLService
    {
        private string XmlPath;
        private XmlDocument _activeDoc;

        public XMLService(string path)
        {
            XmlPath = path;
            _activeDoc = ReadXML()!;
        }


        public void CreateNodeFromModel<TModel>(TModel model)
        {
            // Initialize the XmlSerializer with the type of the model
            XmlSerializer serializer = new XmlSerializer(typeof(TModel));

            // Use StringWriter for the serialization process
            using (StringWriter stringWriter = new StringWriter())
            {
                // Serialize the model into the StringWriter
                serializer.Serialize(stringWriter, model);

                // Load the serialized model string into an XmlDocument
                XmlDocument serializedDoc = new XmlDocument();
                serializedDoc.LoadXml(stringWriter.ToString());

                // Import the serialized document's root element into the target document
                XmlNode importedNode = _activeDoc.ImportNode(serializedDoc.DocumentElement, true);

                // Append the imported node directly to the document's root element or another specific node
                _activeDoc.DocumentElement.AppendChild(importedNode);

                // Save the active document
                _activeDoc.Save(XmlPath);
            }
        }

        public void CreateByModel(string q, string a)
        {
            if(string.IsNullOrEmpty(q) || string.IsNullOrEmpty(a))
            {
                Console.WriteLine("there is no question or answer");
                return;
            }
            ItemModel newItem = new ItemModel(q,a);
            CreateNodeFromModel<ItemModel>(newItem);
        }


        //read xml file
        public XmlDocument? ReadXML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            using (FileStream fileStream = new FileStream(XmlPath, FileMode.Open, FileAccess.Read))
            {
                xmlDoc.Load(fileStream);
            }
            return xmlDoc;
        }

    }
}
