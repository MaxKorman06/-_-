using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КПІЗ_ОІПЗ
{
    public partial class Form1 : Form
    {
        private List<Data> LData;

        void way_A_B() 
        {
            double val = 8, leg = 4;
            label1.Text = "Відстань:" + leg;
            label2.Text = "Ціна:" + (leg * val);
        }

        void way_A_C()
        {
            double val = 8, leg = 6;
            label1.Text = "Відстань:" + leg;
            label2.Text = "Ціна:" + (leg * val);
        }
        void way_B_C()
        {
            double val = 8, leg = 3;
            label1.Text = "Відстань:" + leg;
            label2.Text = "Ціна:" + (leg * val);
        }
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] {"A", "B", "C"});
            comboBox2.Items.AddRange(new string[] { "A", "B", "C"});
            comboBox1.Text = "Місце відправлення";
            comboBox2.Text = "Місце призначення";

            AllData();

            FillСomboBox();
        }
        private void FillСomboBox()
        {
            foreach (var Row in LData.Select(s => s.Key).Distinct())
            {
                comboBox1.Items.Add(Row);
            }
        }
        private List<Data> AllData()
        {
            LData = new List<Data>()
            {
                new Data { Key = "Тип1", Value = "Значение1" },
                new Data { Key = "Тип1", Value = "Значение2" },
                new Data { Key = "Тип1", Value = "Значение3" },
                new Data { Key = "Тип2", Value = "Значение4" },
                new Data { Key = "Тип2", Value = "Значение5" },
                new Data { Key = "Тип2", Value = "Значение6" }
            };
            return LData;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            foreach (var Row in LData.Where(w => w.Key.SequenceEqual(comboBox1.SelectedItem.ToString())).Select(s => s.Value))
            {
                comboBox2.Items.Add(Row);
            }
        }
    }

    public class Data
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
    private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Місце відправлення")
            {
                if (comboBox2.Text == comboBox1.Text)
                {
                    label1.Text = "Відстань: 0";
                    label2.Text = "Ціна: 0";
                }
                if (comboBox1.Text == "A")
                {

                    if (comboBox2.Text == "B")
                    {
                        way_A_B();
                    }
                    if (comboBox2.Text == "C")
                    {
                        way_A_C();
                    }
                }
                if (comboBox1.Text == "B")
                {
                    if (comboBox2.Text == "A")
                    {
                        way_A_B();
                    }
                    if (comboBox2.Text == "C")
                    {
                        way_B_C();
                    }
                }
                if (comboBox1.Text == "C")
                {
                    if (comboBox2.Text == "A")
                    {
                        way_A_C();
                    }
                    if (comboBox2.Text == "B")
                    {
                        way_B_C();
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
