using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Deck
    {
        private List<Card> _CardDeck;
        private List<Card> _DiscardDeck;

        public List<Card> CardDeck
        {
            get { return _CardDeck; }
            set { _CardDeck = value; }
        }


        private const int NUMBER_OF_CARDS = 52;

        private string[] faces = {"Ace", "Duece", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                "Jack", "Queen", "King"};
        private string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
        private int currentCard;

       
        public int totalRoyalFlushes { get; set; }
        public int totalStraightFlushes { get; set; }
        public int totalFourOfAKind { get; set; }
        public int totalHouses { get; set; }
        public int totalFlushes { get; set; }
        public int totalStraights { get; set; }
        public int totalThreeOfAKind { get; set; }
        public int totalTwoPairs { get; set; }
        public int totalOnePairs { get; set; }
        public int totalHighCard { get; set; }

        private Random ranNum = new Random();
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();


        public Deck()
        {
            _CardDeck = GetListOfCards();
            _DiscardDeck = GetListOfDiscards();

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
            int n = _CardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = ranNum.Next(n + 1);
                Card value = _CardDeck[k];
                _CardDeck[k] = _CardDeck[n];
                _CardDeck[n] = value;
            }
        }
        public void RealShuffle()
        {
            int n = _CardDeck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Card value = _CardDeck[k];
                _CardDeck[k] = _CardDeck[n];
                _CardDeck[n] = value;
            }
        }
        public void DealCard()
        {
            Card c = _CardDeck[0];
            _DiscardDeck.Add(c);
            _CardDeck.RemoveAt(0);
        }
        public void PrintDeck()
        {
            foreach (Card c in _CardDeck)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void PrintDeckInBox()
        {
            foreach (Card c in _CardDeck)
            {
                //Form1.Instance.AppendMyText(c.ToString());
            }
        }
        public void PrintDiscards()
        {
            foreach (Card c in _DiscardDeck)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void DeleteCard(string suit, string face)
        {
            _CardDeck.RemoveAll(delegate (Card x) { return x.suit == suit && x.face == face; });
        }
        public void CheckForRoyalInSpades()
        {
            int counter = 0;
            foreach (Card c in _DiscardDeck)
            {
                if (c.suit == "Spades" && c.face == "Ten" || c.suit == "Spades" && c.face == "Jack" || c.suit == "Spades" && c.face == "Queen" || c.suit == "Spades" && c.face == "King" || c.suit == "Spades" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Spades!");
                this.totalRoyalFlushes += 1;
            }
        }
        public void CheckForRoyalInHearts()
        {
            int counter = 0;
            foreach (Card c in _DiscardDeck)
            {
                if (c.suit == "Hearts" && c.face == "Ten" || c.suit == "Hearts" && c.face == "Jack" || c.suit == "Hearts" && c.face == "Queen" || c.suit == "Hearts" && c.face == "King" || c.suit == "Hearts" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Hearts!");
                this.totalRoyalFlushes += 1;
            }
        }
        public void CheckForRoyalInDiamonds()
        {
            int counter = 0;
            foreach (Card c in _DiscardDeck)
            {
                if (c.suit == "Diamonds" && c.face == "Ten" || c.suit == "Diamonds" && c.face == "Jack" || c.suit == "Diamonds" && c.face == "Queen" || c.suit == "Diamonds" && c.face == "King" || c.suit == "Diamonds" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Diamonds!");
                this.totalRoyalFlushes += 1;
            }
        }
        public void CheckForRoyalInClubs()
        {
            int counter = 0;
            foreach (Card c in _DiscardDeck)
            {
                if (c.suit == "Clubs" && c.face == "Ten" || c.suit == "Clubs" && c.face == "Jack" || c.suit == "Clubs" && c.face == "Queen" || c.suit == "Clubs" && c.face == "King" || c.suit == "Clubs" && c.face == "Ace")
                {
                    counter++;
                }
            }
            if (counter >= 5)
            {
                Console.WriteLine("RoyalFlush in Clubs!");
                this.totalRoyalFlushes += 1;
            }
        }
        public void CheckForFlush()
        {
            int counterSpades = 0;
            int counterDiamonds = 0;
            int counterHearts = 0;
            int counterClubs = 0;
            foreach (Card c in _DiscardDeck)
            {
                if (c.suit == "Spades")
                {
                    counterSpades += 1;
                }
                if (c.suit == "Diamonds")
                {
                    counterDiamonds += 1;
                }
                if (c.suit == "Hearts")
                {
                    counterHearts += 1;
                }
                if (c.suit == "Clubs")
                {
                    counterClubs += 1;
                }
            }
           if (counterSpades > 4 || counterClubs > 4 || counterHearts > 4 || counterDiamonds > 4)
            {
                this.totalFlushes += 1;
            //    return true;
            //} else {
            //    return false;
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
        public int GetDeckLength()
        {
            int listLength = 0;
            foreach (Card a in _CardDeck)
            {
                listLength += 1;
            }
            return listLength;
        }
        public void RunDeck(int cards, int iterations)
        {
            
            for (int x = 0; x < iterations; x++)
            {
                for (int y = 0; y < cards; y++)
                {
                    DealCard();
                }

                CheckForFlush();
                _CardDeck = GetListOfCards();
                _DiscardDeck = GetListOfDiscards();
                RealShuffle();

            }
        }

    }
}
