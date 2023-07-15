using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharpWin1
{
    public enum Operators { Add, Sub, Multi, Div }

    public partial class Calulator : Form
    {
        public int Result = 0;
        public bool isNewNum = true;
        public Operators Opt = Operators.Add;

        public Calulator()
        {
            InitializeComponent();
        }

        public int Add(int number1, int number2)
        {
            int sum = number1 + number2;
            return sum;

        }

        public float Add(float number1, float number2)
        {
            float sum = number1 + number2;
            return sum;

        }

        public int Sub(int number1, int number2)
        {
            int sub = number1 + number2;
            return sub;
        }

        private void NumButton1_Click(object sender, EventArgs e)
        {
            Button numButton = (Button)sender;
            SetNum(numButton.Text);
            Console.WriteLine(numButton.Text);

        }

        public void SetNum(string num) 
        {
            if (isNewNum)
            {
                NumScreen.Text = num;
                isNewNum = false;
            }
            else if (NumScreen.Text == "0")
            {
                NumScreen.Text = num;
            }
            else
            {
                NumScreen.Text = NumScreen.Text + num;
            }

        }

        private void NumPlus_Click(object sender, EventArgs e)
        {
            if (isNewNum == false)
            { 
                int num = int.Parse(NumScreen.Text);
                if (Opt == Operators.Add)
                    Result = Result + num;
                else if (Opt == Operators.Sub)
                    Result = Result - num;

                NumScreen.Text = Result.ToString();
                isNewNum = true;
            }

            Button optButton = (Button)sender;
            if (optButton.Text == "+")
                Opt = Operators.Add;

            else if (optButton.Text == "-")
                Opt = Operators.Sub;

        }

        private void NumClear_Click(object sender, EventArgs e)
        {
            Result = 0;
            isNewNum = true;
            Opt = Operators.Add;

            NumScreen.Text = "0";
        }

        private void NumButton2_Click(object sender, EventArgs e)
        {

        }
    }       

}
