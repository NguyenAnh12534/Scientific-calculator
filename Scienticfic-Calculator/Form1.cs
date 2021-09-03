using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scienticfic_Calculator
{
    public partial class Calculator : Form
    {
        Double kq = 0;
        String operation = "";
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)//one of the number buttons or "." button is clicked
        {
            if (txtScreen.Text == "0" )
                txtScreen.Text = "";
           
            Button number = (Button)sender;
            if(number.Text==".")
            {
                if (!txtScreen.Text.Contains("."))
                    txtScreen.Text = txtScreen.Text + number.Text;
            }    
            else
                txtScreen.Text = txtScreen.Text + number.Text;
        }

        private void button20_Click(object sender, EventArgs e)//button AC is clicked
        {
            txtScreen.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)//button Del is clicked
        {
            if (txtScreen.Text.Length > 0)
            {
                if(txtScreen.Text.EndsWith(" "))
                {
                    txtScreen.Text = txtScreen.Text.Remove(txtScreen.Text.Length - 3, 3);
                }
                else
                    txtScreen.Text = txtScreen.Text.Remove(txtScreen.Text.Length - 1, 1);
            }
            if (txtScreen.Text == "")
                txtScreen.Text = "0";
        }

        private void Operator_click(object sender, EventArgs e)//one of (+,-,x,÷) buttons is clicked
        {
            Button opt = (Button)sender;
            if(!txtScreen.Text.EndsWith(" "))
            {
                txtScreen.Text = txtScreen.Text + " " + opt.Text + " ";
            }
        }

        private void button18_Click(object sender, EventArgs e)//button "=" is clicked
        {
            String txtScreenTemp = txtScreen.Text;
            Console.WriteLine(txtScreenTemp.IndexOf(" ").ToString() + " " + txtScreenTemp.LastIndexOf(" ").ToString());
            string Operator = "";
            while (txtScreenTemp!="")
            {
                int endIndex = txtScreenTemp.IndexOf(" ");
                if(endIndex<0)
                {
                    endIndex = txtScreenTemp.Length;
                }
                double temp = 0;
                try {
                    temp = Convert.ToDouble(txtScreenTemp.Substring(0,endIndex));
                    Console.WriteLine(temp.ToString());
                    if (Operator != "")
                    {
                        switch (Operator)
                        {
                            case "+":
                                kq = kq + temp;
                                break;
                            case "-":
                                kq = kq - temp;
                                break;
                            case "x":
                                kq = kq * temp;
                                break;
                            case "÷":
                                kq = kq / temp;
                                break;
                        }
                        Operator = "";
                    }
                    else
                        kq = temp;
                }
                catch (Exception ex)
                {
                    Operator = txtScreenTemp.Substring(0, endIndex);
                    Console.WriteLine(Operator);
                }
                
                txtScreenTemp = txtScreenTemp.Remove(0, endIndex);
                txtScreenTemp = txtScreenTemp.TrimStart();
                Console.WriteLine(txtScreenTemp);
            }
            txtScreen.Text = kq.ToString();
        }
    }
}
