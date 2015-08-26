using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Deck
    {
        public List<Card> CardDeck { get; set; }
        public List<Card> DiscardDeck { get; set; }

        private const int NUMBER_OF_CARDS = 52;

        private string[] faces = {"Ace", "Duece", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                "Jack", "Queen", "King"};
        private string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
        private int currentCard;
        private int totalRoyals;
        private Random ranNum = new Random();


        public Deck()
        {
            CardDeck = GetListOfCards();
            DiscardDeck = GetListOfDiscards();

        }
        public List<Card> GetListOfCards()
        {
            List<Card> cards = new List<Card>();

            foreach (string suit in suits)
            {
                foreach (string face in faces)
                {
                    cards.Add(new Card(suit, face));
                }
            }

            return cards;
        }
        public List<Card> GetListOfDiscards()
        {
            List<Card> cards = new List<Card>();
            return cards;
        }
        public void Shuffle()
        {
            int n = CardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = ranNum.Next(n + 1);
                Card value = CardDeck[k];
                CardDeck[k] = CardDeck[n];
                CardDeck[n] = value;
            }
        }
        public void RealShuffle()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = CardDeck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = CardDeck[k];
                CardDeck[k] = CardDeck[n];
                CardDeck[n] = value;
            }
        }
        public void DealCard()
        {
            Card c = CardDeck[0];
            DiscardDeck.Add(c);
            CardDeck.RemoveAt(0);
        }
        public void PrintDeck()
        {
            foreach (Card c in CardDeck)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void PrintDiscards()
        {
            foreach (Card c in DiscardDeck)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void DeleteCard(string suit, string face)
        {
            CardDeck.RemoveAll(delegate (Card x) { return x.suit == suit && x.face == face; });
        }
        public void CheckForRoyalInSpades()
        {
            int counter = 0;
            foreach (Card c in DiscardDeck)
            {
                if (c.suit == "Spades" && c.face == "Ten" || c.suit == "Spades" && c.face == "Jack" || c.suit == "Spades" && c.face == "Queen" || c.suit == "Spades" && c.face == "King" || c.suit == "Spades" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Spades!");
                this.totalRoyals += 1;
            }
        }
        public void CheckForRoyalInHearts()
        {
            int counter = 0;
            foreach (Card c in DiscardDeck)
            {
                if (c.suit == "Hearts" && c.face == "Ten" || c.suit == "Hearts" && c.face == "Jack" || c.suit == "Hearts" && c.face == "Queen" || c.suit == "Hearts" && c.face == "King" || c.suit == "Hearts" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Hearts!");
                this.totalRoyals += 1;
            }
        }
        public void CheckForRoyalInDiamonds()
        {
            int counter = 0;
            foreach (Card c in DiscardDeck)
            {
                if (c.suit == "Diamonds" && c.face == "Ten" || c.suit == "Diamonds" && c.face == "Jack" || c.suit == "Diamonds" && c.face == "Queen" || c.suit == "Diamonds" && c.face == "King" || c.suit == "Diamonds" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Diamonds!");
                this.totalRoyals += 1;
            }
        }
        public void CheckForRoyalInClubs()
        {
            int counter = 0;
            foreach (Card c in DiscardDeck)
            {
                if (c.suit == "Clubs" && c.face == "Ten" || c.suit == "Clubs" && c.face == "Jack" || c.suit == "Clubs" && c.face == "Queen" || c.suit == "Clubs" && c.face == "King" || c.suit == "Clubs" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Clubs!");
                this.totalRoyals += 1;
            }
        }
        public void CheckForRoyal()
        {
            Deck deck = new Deck();
            int y = 0;
            while (y < 649739)
            {
                RealShuffle();
                for (int x = 0; x < 5; x++)
                {
                    deck.DealCard();


                }
                y++;
                CheckForRoyalInSpades();
                CheckForRoyalInHearts();
                CheckForRoyalInDiamonds();
                CheckForRoyalInClubs();
                deck = new Deck();
            }
        }
        public void PrintRoyals()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("hallo");
            }
        }

    }
}
