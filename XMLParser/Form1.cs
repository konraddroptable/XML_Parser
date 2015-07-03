using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using XMLParser;

namespace XMLParser
{
    public partial class Form1 : Form
    {
        XDocument xml = new XDocument();
        public Form1()
        {
            InitializeComponent();
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
            Timetable timetable = new Timetable();
            int idFrom = FindStationByName(stationFrom.SelectedItem.ToString());
            int idTo = -1;
            idTo = FindStationByName(stationTo.SelectedItem.ToString());
            int hour = (int)fromHour.SelectedItem;


            xml = timetable.Scraper(idFrom, idTo, true, hour);
            MessageBox.Show("Zakończono pobieranie", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                xml.Save(saveFileDialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation();
            MessageBox.Show(validation.ValidateXml());

        }


        
    }
}
