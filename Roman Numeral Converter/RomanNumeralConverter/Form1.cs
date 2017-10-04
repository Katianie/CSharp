using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomanNumeralConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int GetNumericalValue(char numeral)
        {
            if(numeral == 'I' || numeral == 'i')
            {
                return 1;
            }
            else if(numeral == 'V' || numeral == 'v')
            {
                return 5;
            }
            else if(numeral == 'X' || numeral == 'x')
            {
                return 10;
            }
            else if(numeral == 'L' || numeral == 'l')
            {
                return 50;
            }
            else if(numeral == 'C' || numeral == 'c')
            {
                return 100;
            }
            else if(numeral == 'D' || numeral == 'd')
            {
                return 500;
            }
            else if (numeral == 'M' || numeral == 'm')
            {
                return 1000;
            }
            else
            {
                return -1;
            }
        }

        //I could try to be clever and use division but
        //I figured it might just be easier and more efficient
        //hard coding the compound symbols.
        public string GetRomanSymbol(int num)
        {
            if (num == 0)
            {
                return "";
            }
            else if (num == 1)
            {
                return "I";
            }
            else if (num == 2)
            {
                return "II";
            }
            else if (num == 3)
            {
                return "III";
            }
            else if (num == 4)
            {
                return "IV";
            }
            else if (num == 5)
            {
                return "V";
            }
            else if (num == 6)
            {
                return "VI";
            }
            else if (num == 7)
            {
                return "VII";
            }
            else if (num == 8)
            {
                return "VIII";
            }
            else if (num == 9)
            {
                return "XI";
            }
            else if (num == 10)
            {
                return "X";
            }
            else if (num == 20)
            {
                return "XX";
            }
            else if (num == 30)
            {
                return "XXX";
            }
            else if (num == 40)
            {
                return "XL";
            }
            else if (num == 50)
            {
                return "LC";
            }
            else if (num == 60)
            {
                return "LX";
            }
            else if (num == 70)
            {
                return "LXX";
            }
            else if (num == 80)
            {
                return "LXXX";
            }
            else if (num == 90)
            {
                return "LXXXX";
            }
            else if (num == 100)
            {
                return "C";
            }
            else if (num == 200)
            {
                return "CC";
            }
            else if (num == 300)
            {
                return "CCC";
            }
            else if (num == 400)
            {
                return "CD";
            }
            else if (num == 500)
            {
                return "D";
            }
            else if (num == 600)
            {
                return "DC";
            }
            else if (num == 700)
            {
                return "DCC";
            }
            else if (num == 800)
            {
                return "DCCC";
            }
            else if (num == 900)
            {
                return "CM";
            }
            else if (num == 1000) //Past 1000 roman numerals get fucked up history wise
            {
                return "M";
            }
            else if (num == 2000)
            {
                return "MM";
            }
            else if (num == 3000)
            {
                return "MMM";
            }
            else if (num == 4000)
            {
                return "MMMM";
            }
            else if (num == 5000)
            {
                return "MMMMM";
            }
            else if (num == 6000)
            {
                return "MMMMMM";
            }
            else if (num == 7000)
            {
                return "MMMMMMM";
            }
            else if (num == 8000)
            {
                return "MMMMMMMM";
            }
            else if (num == 9000)
            {
                return "MMMMMMMMM";
            }
            else
            {
                return "?";
            }
        }

        private void btnRomanToNum_Click(object sender, EventArgs e)
        {
            long total = 0;
            long i = 0;
            string strInput = txtRomanNumerals.Text;
            char[] str;
            int num1 = 0;
            int num2 = 0;
            bool error = false;

            //Remove whitespace before
            strInput = strInput.Trim();

            //Put it to char array so its easier to manage
            str = strInput.ToCharArray();

            while (i < (long)str.Length - 1)
            {
                num1 = GetNumericalValue(str[i]);
                num2 = GetNumericalValue(str[i + 1]);

                //Error checking
                if (num1 == -1 || num2 == -1)
                {
                    error = true;
                    break;
                }

                //Calculation

                //If the next character is greater than the current character,
                //the calculation is different.
                if(num1 >= num2)
                {
                    //This is to compensate for the last
                    //character so its not skipped.
                    if (i == str.Length - 2)
                    {
                        total += num2;
                    }

                    total += num1;    
                    
                    i++;
                }
                else
                {
                    //When a low value char comes before a high value char
                    //Then this is done to calculate the current number
                    total += (num2 - num1);
                    i += 2;
                }
            }
       
            if (error == true)
            {
                MessageBox.Show("Error Calculating, Symbol does not match a numerical value.");
            }
            else
            {
                lblNumber.Text = total.ToString();
            }
        }

        private void btnNumberToRoman_Click(object sender, EventArgs e)
        {
            char[] numStr = txtNumber.Text.ToCharArray();
            string finalResult = ""; //Buffer to hold the translation
            string currSym = ""; //Current symbol calculated
            int exponent = numStr.Length - 1; //This will be used like 10^exponent
            int i = 0; //Loop counter
            double bigNum = Math.Pow(10, exponent); //This keeps our numerical position like "hundreds place"
            double temp;
            bool error = false; //If set to true then there was a problem translating

            while (i < numStr.Length)
            {
                bigNum = Math.Pow(10, exponent);

                temp = int.Parse(numStr[i].ToString());
                currSym = GetRomanSymbol((int)(temp * bigNum));

                if (currSym == "?")
                {
                    error = true;
                    break;
                }

                finalResult += currSym; 

                i++;
                exponent--; //Change our numerical position
            }

            if (error == true)
            {
                MessageBox.Show("Error Calculating, Number might be too large.");
            }
            else
            {
                lblRomanNumerals.Text = finalResult;
            }
            

        }


    }
}
