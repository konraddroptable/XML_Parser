using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace XMLParser
{
    class Timetable
    {
        private string DecodeFromUtf8(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);

            return Encoding.UTF8.GetString(bytes);
        }

        private int RemoveLeadingZero(string str)
        {
            int output;

            if (str.Substring(0, 1) == "0")
            {
                output = Int32.Parse(str.Substring(1, 1));
            }
            else
            {
                output = Int32.Parse(str);
            }

            return (output);
        }

        private int FromHourSolver(int fromHour)
        {
            if (fromHour == 0)
            {
                return fromHour = 23;
            }
            else
            {
                return fromHour;
            }
        }

        private XDocument CreateXmlDocument(string filename)
        {
            XDocument doc = new XDocument();
            return doc;
        }
        private string ScrapMinutes(HtmlDocument doc, string stationsRow, string minutesCell, string minutes, int i, int j)
        {
            return doc.DocumentNode.SelectSingleNode("(" + stationsRow + "[" + i + "]" + minutesCell + ")[" + j + "]" + minutes).InnerText.ToString();
        }

        private string ScrapTips(HtmlDocument doc, string singleStationRow, string minutesCell, string minutes, string tips, int i, int j)
        {
            //sometimes Tip is null
            return DecodeFromUtf8(doc.DocumentNode.SelectSingleNode("(" + singleStationRow + "[" + i + "]" + minutesCell + ")[" + j + "]" + tips).InnerText.ToString().Trim());
        }

        public XDocument Scraper(int idStart, int idEnd, bool today, int fromHour)
        {
            //output
            XDocument documentXml = new XDocument(new XElement("root"));

            //prepare date for url
            DateTime date = new DateTime();
            if (today)
                date = DateTime.Now;
            else
                date = DateTime.Now.AddDays(1);

            string day, month, year;
            day = date.Year.ToString("dd");
            month = date.Month.ToString("MM");
            year = date.Year.ToString("yyyy");

            string page = @"http://skm.trojmiasto.pl/rozklad.php?stacja_od=" + idStart.ToString() + @"&stacja_do=" + idEnd.ToString() + @"&data=" + day + "%2F" + month + "%2F" + year;

            //new webpage
            var webGet = new HtmlWeb();
            var doc = webGet.Load(page);

            //XPath formulas
            string stationsRow = @"//div[@class='station-row']";
            string singleStationRow = @"(//div[@class='station-row'])";
            string hours = @"/div[@class='hour']";
            string minutesCell = @"//div[@class='minutes-cell']";
            string minutes = @"/div[@class='minutes']";
            string tips = @"/div[@class='tips']";

            string hourScrap = String.Empty;
            int newHour;

            //hour 23->0 workaround
            fromHour = FromHourSolver(fromHour);

            //page scraping
            if (doc != null && doc.DocumentNode != null &&
                doc.DocumentNode.SelectNodes(stationsRow) != null)
            {
                
                XmlAddStationsInfo(documentXml, idStart, idEnd);
 
                int counter = 0;
                //get every single station-row in page
                for (int i = 1; i <= doc.DocumentNode.SelectNodes(stationsRow).Count; i++)
                {
                    hourScrap = doc.DocumentNode.SelectSingleNode(singleStationRow + "[" + i + "]" + hours).InnerText.ToString().Substring(0, 2);
                    newHour = RemoveLeadingZero(hourScrap);
                    if (newHour >= fromHour)
                    {
                        XmlAddRow(documentXml, counter);
                        XmlAddHour(documentXml, counter, newHour);
                        //get minutes-cell of each station-row
                        for (int j = 1; j <= doc.DocumentNode.SelectNodes(singleStationRow + "[" + i + "]" + minutesCell).Count; j++)
                        {
                            documentXml.Element("root")
                                .Elements("row")
                                .Where(row => row.Attribute("id").Value == counter.ToString())
                                .FirstOrDefault()
                                .Add(new XElement("minutesRow", new XElement("minutesValue", ScrapMinutes(doc, stationsRow, minutesCell, minutes, i, j)),
                                                                new XElement("minutesTips", ScrapTips(doc, singleStationRow, minutesCell, minutes, tips, i, j))));

                        }
                        counter++;
                    }
                }
            }

            return documentXml;
        }

        public string FindStationById(int id)
        {
            StationsList stations = new StationsList();
            List<Station> list = new List<Station>();
            list = stations.GetStations();

            return list.FirstOrDefault(x => x.Id == id).Name;
        }

        private void XmlAddStationsInfo(XDocument xml, int idStart, int idEnd)
        {
            //string day, month, year;
            //day = date.Year.ToString("dd");
            //month = date.Month.ToString("MM");
            //year = date.Year.ToString("yyyy");

            //prepare date for url
            DateTime date = new DateTime();
            date = DateTime.Now;
            bool isWeekend = (int)date.DayOfWeek == 0 || (int)date.DayOfWeek == 5 ? true : false;

            xml.Element("root").Add(new XElement("stations", new XElement("from",
                                                                 new XElement("id", idStart),
                                                                 new XElement("name", FindStationById(idStart))),
                                                             new XElement("to",
                                                                 new XElement("id", idEnd),
                                                                 new XElement("name", FindStationById(idEnd)))
                                                                 ),
                                    new XElement("timeStamp",
                                                            new XElement("date",
                                                                new XElement("year", date.Year.ToString()),
                                                                new XElement("month",
                                                                    new XElement("name", date.ToString("MMM", CultureInfo.InvariantCulture)),
                                                                    new XElement("value", date.Month.ToString())),
                                                                new XElement("day",
                                                                    new XElement("dayOfWeek",
                                                                        new XElement("name", date.DayOfWeek.ToString()),
                                                                        new XElement("value", (int)date.DayOfWeek + 1),
                                                                        new XElement("isWeekend", isWeekend)),
                                                                    new XElement("dayOfMonth",
                                                                        new XElement("value", date.Day.ToString())),
                                                                    new XElement("dayOfYear",
                                                                        new XElement("value", date.DayOfYear.ToString())))),
                                                            new XElement("time",
                                                                new XElement("hour", date.Hour.ToString()),
                                                                new XElement("minute", date.Minute.ToString()),
                                                                new XElement("second", date.Second.ToString()))));
        }

        private void XmlAddRow(XDocument xml, int counter)
        {
            xml.Element("root").Add(new XElement("row", new XAttribute("id", counter)));
        }

        private void XmlAddHour(XDocument xml, int counter, int newHour)
        {
            xml.Element("root")
                                .Elements("row")
                                .Where(row => row.Attribute("id").Value == counter.ToString())
                                .FirstOrDefault()
                                .Add(new XElement("hourValue", newHour));
        }

        public void XmlSaveToPath(XDocument xml, string path)
        {
            xml.Save(path);
        }
        
    }
}
