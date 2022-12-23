using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cryptography_monoalphabetic_algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestInputValues()
        {
            if (string.IsNullOrEmpty(textBoxK1.Text) || string.IsNullOrEmpty(textBoxK2.Text) || string.IsNullOrEmpty(textBoxValue.Text))
            {
                DialogResult = MessageBox.Show(this,
                                            "Въведете стойностои за к1, к2 и текст за обработка!",
                                            "Липса на входни дании",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information,
                                            MessageBoxDefaultButton.Button1, 0);
            }
            else if (!Regex.IsMatch(textBoxValue.Text, @"^[a-zA-Z ]+$"))
            {
                DialogResult = MessageBox.Show(this,
                                           "Позволява се въвеждане само на латински букви!",
                                           "Неправилни входни дании",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                           MessageBoxDefaultButton.Button1, 0);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            TestInputValues();

            string value = textBoxValue.Text.ToUpper();
            string result = string.Empty;

            for(int i = 0; i < value.Length; i++)
            {
                int index = (int)value[i] - 64;
                result += string.Format("{0}", (char)((((int.Parse(textBoxK1.Text) * index) + int.Parse(textBoxK2.Text)) % 26) + 64));
            }

            textBoxResult.Text = result;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            TestInputValues();

            string value = textBoxValue.Text.ToUpper();
            string r1 = string.Empty;
            string r2 = string.Empty;
            string r3 = string.Empty;
            string r4 = string.Empty;

            for(int i = 0; i < value.Length; i++)
            {
                int index = (int)value[i] - 64;
                r1 += string.Format("{0}", (char)((((((index - (int.Parse(textBoxK2.Text))) / int.Parse(textBoxK1.Text)) + 0) % 26)) + 64));
                r2 += string.Format("{0}", (char)((((((index - (int.Parse(textBoxK2.Text))) / int.Parse(textBoxK1.Text)) + 10) % 26)) + 64));
                r3 += string.Format("{0}", (char)((((((index - (int.Parse(textBoxK2.Text))) / int.Parse(textBoxK1.Text)) + 20) % 26)) + 64));
                r4 += string.Format("{0}", (char)((((((index - (int.Parse(textBoxK2.Text))) / int.Parse(textBoxK1.Text)) + 30) % 26)) + 64));
            }

            textBoxResult.Text = string.Format("{0} {3} {1} {3} {2} {3} {4}", r1, r2, r3, '\n',r4);
        }
    }
}
