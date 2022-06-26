using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;


namespace Laboratoria1_Serializacja
{
    public partial class Form1 : Form
    {
        string JsonString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{osoba.Imie},\t\n{osoba.Nazwisko},\t\n{osoba.Wiek}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string JsonString = JsonConvert.SerializeObject(osoba);
            textBox2.Text = JsonString;
            textBox1.Clear();
            textBox1.Text = "SERIALIZED";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string JsonString = JsonConvert.SerializeObject(osoba);
            Osoba deserializedOsoba = JsonConvert.DeserializeObject<Osoba>(JsonString);
            textBox1.Text = $"{deserializedOsoba.Imie},\t\n{deserializedOsoba.Nazwisko},\t\n{deserializedOsoba.Wiek}";
            textBox2.Clear();
            textBox2.Text = "DESERIALIZED";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            osoba.Imie = textBox3.Text;
            textBox1.Text = $"{osoba.Imie},\t\n{osoba.Nazwisko},\t\n{osoba.Wiek}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            osoba.Nazwisko = textBox4.Text;
            textBox1.Text = $"{osoba.Imie},\t\n{osoba.Nazwisko},\t\n{osoba.Wiek}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string wiek = textBox5.Text;
            textBox5.Text = wiek;
            int wiekLiczba = Int32.Parse(wiek);
            osoba.Wiek = wiekLiczba;

            textBox1.Text = $"{osoba.Imie},\t\n{osoba.Nazwisko},\t\n{osoba.Wiek}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text = openFileDialog1.FileName;

                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    textBox2.Text = reader.ReadToEnd();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            openFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            //openFileDialog1.Filter = "client_secret.json (.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
                label5.Text = saveFileDialog1.FileName;
            }
        }
    }
}
