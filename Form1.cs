using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class GPA : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            A.Text = "4.0";
            A_Neg.Text = "3.67";
            B_Plus.Text = "3.33";
            B_Neg.Text = "2.67";
            C_Plus.Text = "2.33";
            C_Neg.Text = "1.67";
            D.Text = "1.00";
            F.Text = "0.00";

        }

        List<ComboBox> Combolist = new List<ComboBox>();
        List<NumericUpDown> Numericlist = new List<NumericUpDown>();
        List<KeyValuePair<string, double>> Grades = new List<KeyValuePair<string, double>>(7);
        public GPA()
        {
            InitializeComponent();
            inlist();
        }
        void inlist()
        {
            Combolist.Add(comboBox1);
            Combolist.Add(comboBox2);
            Combolist.Add(comboBox3);
            Combolist.Add(comboBox4);
            Combolist.Add(comboBox5);
            Combolist.Add(comboBox6);
            Combolist.Add(comboBox7);

            Numericlist.Add(numericUpDown1);
            Numericlist.Add(numericUpDown2);
            Numericlist.Add(numericUpDown3);
            Numericlist.Add(numericUpDown4);
            Numericlist.Add(numericUpDown5);
            Numericlist.Add(numericUpDown6);
            Numericlist.Add(numericUpDown7);


            Grades.Add(new KeyValuePair<string, double>("A", 4.0));
            Grades.Add(new KeyValuePair<string, double>("A-", 3.67));
            Grades.Add(new KeyValuePair<string, double>("B+", 3.33));
            Grades.Add(new KeyValuePair<string, double>("B-", 2.67));
            Grades.Add(new KeyValuePair<string, double>("C+", 2.33));
            Grades.Add(new KeyValuePair<string, double>("C-", 1.67));
            Grades.Add(new KeyValuePair<string, double>("D", 1.00));
            Grades.Add(new KeyValuePair<string, double>("F", 0.00));


            int index = 0;
            foreach(ComboBox box in Combolist)
            {
                box.Items.Add("A");
                box.Items.Add("A-");
                box.Items.Add("B+");
                box.Items.Add("B-");
                box.Items.Add("C+");
                box.Items.Add("C-");
                box.Items.Add("D");
                box.Items.Add("F");
                box.SelectedIndex = 0;
                Numericlist[index].Minimum = 1;
                Numericlist[index].Maximum = 3;
                box.SelectedIndexChanged += new System.EventHandler(this.gpachange);
                Numericlist[index++].ValueChanged += new System.EventHandler(this.gpachange);
            }

        }
        void CalculateGPA()
        {
            double total_hours = 0;
            List<double> credithours = new List<double>();
            List<string> grades = new List<string>();
            List<double> grade_points = new List<double>();
            for (int index = 0; index < 7; index++)
            {
                total_hours+= double.Parse(Numericlist[index].Value.ToString());
                double credit_hours = double.Parse(Numericlist[index].Value.ToString());
                credithours.Add(credit_hours);
                grades.Add(Combolist[index].Text);

            }
            for(int loop1=0;loop1<7;loop1++)
            {
                for(int loop2=0;loop2<7;loop2++)
                {
                    if(Grades[loop2].Key==grades[loop1])
                    {
                        grade_points.Add(Grades[loop2].Value);
                        break;
                    }
                }
            }
            double GPA=((credithours[0] * grade_points[0]) + (credithours[1] * grade_points[1]) + (credithours[2] * grade_points[2])
            + (credithours[3] * grade_points[3]) + (credithours[4] * grade_points[4]) + (credithours[5] * grade_points[5])
            + (credithours[6] * grade_points[6])) / total_hours;
            result.Text = Math.Round(GPA,3).ToString();

            
        }
        void gpachange(object sender,EventArgs e)
        {
            CalculateGPA();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculateGPA();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ComboBox box in Combolist)
            {
                box.SelectedIndex = 0;
            }
            foreach(NumericUpDown num in Numericlist)
            {
                num.Value = 1;
            }
        }
    }
}
