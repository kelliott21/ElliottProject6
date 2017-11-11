using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElliottProject6
{
    public partial class Form1 : Form
    {
        private Hashtable hTable = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"BinaryTextFile.txt");

            //Splits text file by the characters below
            char[] delimiterChars = { ' ', '"', '.', ':', '\t', '\r', '\n', '?', '!', ';', '(', ')' };
            string[] words = text.Split(delimiterChars);

            int index = 0;
            foreach (string s in words)
            {
                if (!string.IsNullOrWhiteSpace(s.Replace(",", "")))
                {
                    //ToLower makes all words lowercase
                    hTable.Add(index,s.ToLower().Replace(",", ""));
                    index++;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblResult.Visible = false;
            if(string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("A value is required.");
                return;
            }
            bool resultFound = hTable.ContainsValue(txtInput.Text.ToLower());
            if(resultFound)
            {
                lblResult.Text = "Value was found in the hash table.";
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Text = "Value was NOT found in the hash table.";
                lblResult.Visible = true;
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
