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
        public static int cardsToDraw;
        public static int numberOfDraws;


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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cardsToDrawInput;
            int numberOfDrawsInput;
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("You must have inputs in both boxes!");
            }
            if (int.TryParse(textBox2.Text, out cardsToDrawInput) && int.TryParse(textBox3.Text, out numberOfDrawsInput))
            {
                if (cardsToDrawInput > 52 || cardsToDrawInput < 1 || numberOfDrawsInput < 1)
                {
                    MessageBox.Show("Cards to draw must be between 0 and 53, total draws must be over 1!");
                    return;
                }
                cardsToDraw = cardsToDrawInput;
                numberOfDraws = numberOfDrawsInput;

            } else
            {
                MessageBox.Show("Not a valid number!");
            }
            textBox4.Text = "";
            textBox4.AppendText("Number of cards drawn: " + cardsToDraw);
            textBox4.AppendText(Environment.NewLine);
            textBox4.AppendText("Number of total draws: " + numberOfDraws);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            Deck deck = new Deck();
            for (int x = 0; x < numberOfDraws; x++)
            {
                for(int y = 0; y < cardsToDraw; y++) { 
                deck.DealCard();
                }

                deck.CheckForFlush();
                deck = new Deck();
            }
            textBox5.Text = "";
            textBox5.AppendText("---------------------------------------");
            textBox5.AppendText(Environment.NewLine);
            textBox5.AppendText("Total flushes: " + deck.totalFlushes.ToString());
            textBox5.AppendText(Environment.NewLine);
            textBox5.AppendText("---------------------------------------");
            textBox5.AppendText(Environment.NewLine);
        }
    }
}
