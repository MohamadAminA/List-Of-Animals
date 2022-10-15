using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace آموزش
{
    public partial class Form1 : Form
    {

        List<Dog> dogs = new List<Dog>();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            Dog newdog = new Dog ();
            if(textBox1.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if(textBox2.Text == "")
            {
                MessageBox.Show("لطفا نژاد را وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if(textBox3.Text == "")
            {
                MessageBox.Show("لطفا سال را وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if(textBox4.Text == "")
            {
                MessageBox.Show("لطفا ماه را وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            string Check = textBox3.Text;

            for(int i = 0; i<Check.Length; ++i)
                if (Check[i] < 48 || Check[i] > 57)
                {
                    MessageBox.Show("لطفا سن را به صورت عدد وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            Check = textBox4.Text;
            for(int i = 0; i<Check.Length; ++i)
                if (Check[i] < 48 || Check[i] > 57)
                {
                    MessageBox.Show("لطفا سن را به صورت عدد وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            
            if (Convert.ToInt32(Check) > 12 || Convert.ToInt32(Check) < 0)
            {
                MessageBox.Show("لطفا مقدار ماه را به صورت صحیح وارد نمایید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            newdog.Name = textBox1.Text;
            newdog.Nezhad = textBox2.Text;
            newdog.Sal = Convert.ToInt32(textBox3.Text);
            newdog.Mah = Convert.ToInt32(textBox4.Text);
            if (radioButton1.Checked)
                newdog.jensiat = Dog.Jensiat.نر;
            else
                newdog.jensiat = Dog.Jensiat.ماده;
            int num_eleman = dogs.Count;
            if (num_eleman == 0)
                newdog.ID = 1;
            else
                newdog.ID = dogs[num_eleman-1].ID + 1;
            
            dogs.Add(newdog);
            textBox5.Text = Convert.ToString(++num_eleman);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            dataGridView1.DataSource=null;
            dataGridView1.DataSource = dogs.ToList();
            textBox1.Focus();
            MessageBox.Show("عملیات با موفقیت انجام شد" ,  "Result" , MessageBoxButtons.OK , MessageBoxIcon.None);
            btnSpeech.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        List<Dog> Search = new List<Dog>();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox6_TextChanged(sender,e);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Search.Clear();
            if (checkBox1.Checked)
            {
                Search.AddRange(from i in dogs where i.Name.Contains(textBox6.Text) select i) ;
                //
                if (Search == null)
                {
                    textBox6.Text = textBox6.Text;
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Search.ToList();
            //    foreach (var item in dogs)
            //        if (item.Name.Contains(textBox6.Text) == true)
            //            Search.Add(item);
            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = Search.ToList();
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.Speak("Wellcome");
        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SelectVoiceByHints(VoiceGender.Female);
            foreach (Dog item in dogs)
            {
                speech.Speak("Name");
                speech.Speak(item.Name);
                
                speech.Speak(item.Nezhad);
                speech.Speak("Jensiat");
                if (item.jensiat == Dog.Jensiat.نر)
                {
                    speech.Speak("male");
                }
                else
                {
                    speech.Speak("female");
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            _ = textBox4.Focus();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            _ = radioButton2.Focus();
        }

        private void radioButton2_Leave(object sender, EventArgs e)
        {
            _ = button1.Focus();
        }
    }
}