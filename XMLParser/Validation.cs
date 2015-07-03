using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XMLParser
{
    class Validation
    {
        public string ValidateXml()
        {
            string xsdMarkup =
                        @"<xsd:schema xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
               <xsd:element name='root'>
                <xsd:complexType>
                 <xsd:sequence>
                  <xsd:element name='Child1' minOccurs='1' maxOccurs='1'/>
                  <xsd:element name='Child2' minOccurs='1' maxOccurs='1'/>
                 </xsd:sequence>
                </xsd:complexType>
               </xsd:element>
              </xsd:schema>";
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));

            XDocument doc1 = new XDocument(
                new XElement("Root",
                    new XElement("Child1", "content1"),
                    new XElement("Child2", "content1")
                )
            );

            XDocument doc2 = new XDocument(
                new XElement("Root",
                    new XElement("Child1", "content1"),
                    new XElement("Child3", "content1")
                )
            );

            bool errors = false;
            doc2.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            string valid = errors ? "did not validate" : "validated";

            return valid;
        }
        
    }
}
