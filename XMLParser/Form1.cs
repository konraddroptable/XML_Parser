using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using XMLParser;

namespace XMLParser
{
    public partial class Form1 : Form
    {
        XDocument xml = new XDocument();
        XmlDocument loadedXml = new XmlDocument();
        string xmlPath = "none";
        string xsdPath = "none";


        public Form1()
        {
            InitializeComponent();
            lblXml.Text = string.Empty;
            lblXsd.Text = string.Empty;

            StationsList station = new StationsList();


            PrepareCombo(station.GetStations(), stationFrom);
            PrepareCombo(station.GetDirections(), stationTo);

            fromHour.Items.Clear();
            int[] tabWithHours = GetHoursList();

            for (int i = 0; i < 24; i++)
                fromHour.Items.Add(tabWithHours[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Timetable timetable = new Timetable();
                int idFrom = FindStationByName(stationFrom.SelectedItem.ToString());
                int idTo = -1;
                idTo = FindStationByName(stationTo.SelectedItem.ToString());
                int hour = (int)fromHour.SelectedItem;

                xml = timetable.Scraper(idFrom, idTo, true, hour);
                MessageBox.Show("Zakończono pobieranie", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Błąd podczas pobierania pliku!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.xml != null)
                SaveXmlFile(this.xml);
            else
                MessageBox.Show("Brak pobranego dokumentu XML!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void PrepareCombo(List<Station> list, ComboBox combo)
        {
            combo.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                combo.Items.Add(list[i].Name);
            }
        }

        private int[] GetHoursList()
        {
            int[] tab = new int[24];

            for (int i = 0; i < 24; i++)
                tab[i] = i + 1;

            return tab;
        }

        private int FindStationByName(string name)
        {
            StationsList stations = new StationsList();
            List<Station> list = new List<Station>();
            list = stations.GetStations();
            int ret;

            try
            {
                ret = list.FirstOrDefault(x => x.Name == name).Id;

            }
            catch (System.NullReferenceException e)
            {
                ret = -1;
            }

            return ret;
        }

        private void SaveXmlFile(XDocument xml)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Document |*.xml";
            saveFileDialog.Title = "Zapisz plik dokument XML";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    xml.Save(saveFileDialog.FileName);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Nie wygenerowano wcześniej pliku XML", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Validation val = new Validation();
            ErrorsCount ec = new ErrorsCount();
            try
            {
                ec = val.ValidateXmlDocument(xmlPath, xsdPath);
                string msg = ec.validationFlag ? "Walidacja zakończona powodzeniem" : "Walidacja zakończona niepowodzeniem";
                string msg2 = "\n\nLiczba błędów: " + ec.errorsCount.ToString() + "\nLiczba ostrzeżeń: " + ec.warningsCount.ToString();

                MessageBox.Show(msg + msg2, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){
                if(ex is FileNotFoundException || ex is ArgumentException)
                    MessageBox.Show("Nie załadowano pliku z XML lub XSD!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LoadFile(string dialogFilter, string dialogTitle)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = dialogFilter;
            openFileDialog.Title = dialogTitle;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName.ToString();
            else
                return string.Empty;
        }

        private void loadXmlBtn_Click(object sender, EventArgs e)
        {
            xmlPath = LoadFile(@"XML Document |*.xml", @"Wybierz dokument XML do walidacji");
            if (xmlPath != "none")
                lblXml.Text = "Załadowano plik";
        }

        private void loadXsdBtn_Click(object sender, EventArgs e)
        {
            xsdPath = LoadFile(@"XSD Document |*.xsd", @"Wybierz dokument XSD do walidacji");
            if(xsdPath != "none")
                lblXsd.Text = "Załadowano plik";
        }


    }
}
