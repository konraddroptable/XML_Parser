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
        private List<string> TheSchemaErrors;
        private List<string> TheSchemaWarnings;

        public ErrorsCount ValidateXmlDocument(string xmlPath, string xsdPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            doc.Schemas.Add("", xsdPath);
            doc.Schemas.Compile();
            TheSchemaErrors = new List<string>();
            TheSchemaWarnings = new List<string>();
            doc.Validate(Xml_ValidationEventHandler);

            ErrorsCount ec = new ErrorsCount();
            ec.errorsCount = TheSchemaErrors.Count;
            ec.warningsCount = TheSchemaWarnings.Count;
            if (ec.errorsCount > 0)
                ec.validationFlag = false;
            else
                ec.validationFlag = true;

            return ec;
        }

        private void Xml_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error: TheSchemaErrors.Add(e.Message); break;
                case XmlSeverityType.Warning: TheSchemaWarnings.Add(e.Message); break;
            }
        }

        
        
    }

    class ErrorsCount
    {
        public int errorsCount;
        public int warningsCount;
        public bool validationFlag;
    }
}
