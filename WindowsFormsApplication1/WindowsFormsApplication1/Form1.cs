using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static Form1 instance;
        public static Form1 Instance { get { return instance; } }
        Deck deck = new Deck();
        public Form1()
        {
            InitializeComponent();
        }
        public void AppendMyText(string text)
        {
            textBox1.AppendText(text);
        }
        private void printDeckButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for(int x = 0; x < deck.GetDeckLength(); x++) {
            string ls = string.Join(", ", deck.CardDeck[x].ToString());
            textBox1.AppendText(ls);
            textBox1.AppendText(Environment.NewLine);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            deck.PrintDeck();
        }

        private void newDeckButton_Click(object sender, EventArgs e)
        {
            deck = new Deck();
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            deck.RealShuffle();
        }
    }
}
