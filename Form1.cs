using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_10_Repeated_number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        Random rdb = new Random();
        bool x = false;
        byte number;
        byte counter;


        Label creatbutton(short X,short Y)
        {
    

            Label lbl1 = new Label();
          
            lbl1.ForeColor = Color.Green;
            lbl1.BackColor = Color.Black;
            lbl1.Size = new System.Drawing.Size(80, 70);
            lbl1.Font = new Font("Tahoma", 16, FontStyle.Regular);
            lbl1.Text = 0.ToString();
            lbl1.TextAlign = ContentAlignment.MiddleCenter;
            lbl1.BorderStyle = BorderStyle.FixedSingle;
            lbl1.Location = new System.Drawing.Point(X, Y);


            
            panel1.Controls.Add(lbl1);
            return lbl1;

        }

        void Addnumbers()
        {
            if(x==true)
            {
                panel1.Controls.Clear();
                x = false;
            }

            counter = 0;
            short X = 40;
            short Y = 10;
            Label labl;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    labl = creatbutton(X,Y);

                    number=Convert.ToByte(rdb.Next(1, 10).ToString());
                    labl.Text = number.ToString();
                    labl.Tag = number;
                    panel1.Controls.Add(labl);

                    if (label1.Text == labl.Tag.ToString())
                    {
                        counter++;
                    }

                    X += 80;
                }

                X = 40;
                Y += 70;
            }

            x = true;

        }

        void CheckAnswer()
        {
            if (textBox1.Text==counter.ToString())
            {
                label1.Text = "correct";
            }
            else
            {
                label1.Text = "Wrong";
            }

        }

        void Main()
        {
            // Specify the path to your .wav file  
            string path = @"C:\Users\TOPTECH\Music\Shot.wav";

            // Create a SoundPlayer instance  
            SoundPlayer player = new SoundPlayer(path);

         
                // Load the .wav file  
                player.Load();
                player.Play();
                // Play the song  
                //player.PlaySync(); // Use Play() for asynchronous play  

               // Console.WriteLine("Song is playing...");
   

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

     

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Focus();
                MessageBox.Show("Text Box should have a value!", "Wrong");

            }
            else
            {
                Main();
                CheckAnswer();

            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrWhiteSpace(textBox1.Text))
            //{
            //    textBox1.Focus();
            //    MessageBox.Show( "Text Box should have a value!", "Wrong");

            //}
            //else
            //{
            number = Convert.ToByte(rdb.Next(1, 10));
            label1.Text = number.ToString();
            Addnumbers();

            // }
        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            ErrorProvider er = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {

               e.Cancel = true;
               textBox1.Focus();
               er.SetError(textBox1, "should have a value!");
            }
            else
            {
                e.Cancel = false;
                er.SetError(textBox1, "");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        }
    }
}
