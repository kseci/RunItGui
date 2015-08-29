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
            int x = 52;
                foreach (string suit in suits)
            {
                foreach (string face in faces)
                {  
                    cards.Add(new Card(suit, face, x));
                    x--;
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
        public List<Card> GetDiscardDeck()
        {
            
                return _DiscardDeck;
            
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
        public void CheckForRoyalFlush()
        {
            int counterDiamonds = 0;
            int counterClubs = 0;
            int counterHearts = 0;
            int counterSpades = 0;
            foreach (Card c in _DiscardDeck) { 
            if (c.suit == "Diamonds" && c.face == "Ten" || c.suit == "Diamonds" && c.face == "Jack" || c.suit == "Diamonds" && c.face == "Queen" || c.suit == "Diamonds" && c.face == "King" || c.suit == "Diamonds" && c.face == "Ace")
            {
                    counterDiamonds += 1;
            } else if (c.suit == "Spades" && c.face == "Ten" || c.suit == "Spades" && c.face == "Jack" || c.suit == "Spades" && c.face == "Queen" || c.suit == "Spades" && c.face == "King" || c.suit == "Spades" && c.face == "Ace")
                {
                    counterSpades += 1;
                }
                else if (c.suit == "Clubs" && c.face == "Ten" || c.suit == "Clubs" && c.face == "Jack" || c.suit == "Clubs" && c.face == "Queen" || c.suit == "Clubs" && c.face == "King" || c.suit == "Clubs" && c.face == "Ace")
                {
                    counterClubs += 1;
                }
                else if (c.suit == "Hearts" && c.face == "Ten" || c.suit == "Hearts" && c.face == "Jack" || c.suit == "Hearts" && c.face == "Queen" || c.suit == "Hearts" && c.face == "King" || c.suit == "Hearts" && c.face == "Ace")
                {
                    counterHearts += 1;
                }
            }
            if (counterDiamonds > 4 || counterSpades > 4 || counterHearts > 4 || counterClubs > 4)
            {
                this.totalRoyalFlushes += 1;
                this.totalFlushes -= 1;
                this.totalStraightFlushes -= 1;
                this.totalStraights -= 1;
            }
        }
        public void CheckForStraightFlush()
        {

            for (int x = 0; x < _DiscardDeck.Count - 4; x++)
            {
                bool ifFlushInHearts = _DiscardDeck[0 + x].suit == "Hearts" && _DiscardDeck[4 + x].suit == "Hearts";
                bool ifFlushInSpades = _DiscardDeck[0 + x].suit == "Spades" && _DiscardDeck[4 + x].suit == "Spades";
                bool ifFlushInDiamonds = _DiscardDeck[0 + x].suit == "Diamonds" && _DiscardDeck[4 + x].suit == "Diamonds";
                bool ifFlushInClubs = _DiscardDeck[0 + x].suit == "Clubs" && _DiscardDeck[4 + x].suit == "Clubs";

                if (ifFlushInHearts || ifFlushInSpades || ifFlushInDiamonds || ifFlushInClubs)
                {
                    for (int y = 0; y < 10; y++) { 
                    if (_DiscardDeck[0 + x].face == this.faces[0 + y] && _DiscardDeck[4 + x].face == this.faces[4 + y])
                    {
                            this.totalStraightFlushes += 1;
                            this.totalFlushes -= 1;
                            this.totalStraights -= 1;
                        }

                    }
                }


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
                SortCards();
                
                CheckForRoyalFlush();
                CheckForStraightFlush();
                CheckForFlush();
                CheckForStraight();
                _CardDeck = GetListOfCards();
                _DiscardDeck = GetListOfDiscards();
                RealShuffle();

            }
        }
        public void SortCards()
        {
            int gap = (_DiscardDeck.Count / 2);
            while (gap > 0)
            {
                for (int i = 0; i < _DiscardDeck.Count - gap; i++)
                {
                    int j = i + gap;
                    Card tmp = _DiscardDeck[j];
                    while (j >= gap && tmp.id > _DiscardDeck[j - gap].id)
                    {
                        _DiscardDeck[j] = _DiscardDeck[j - gap];
                        j -= gap;
                    }
                    _DiscardDeck[j] = tmp;

                }
                if (gap == 2)
                {
                    gap = 1;
                } else
                {
                    gap /= (int)2.2;
                }
            }
        }
        public bool isFlush()
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
                return true;
            } else
            {
                return false;
            }

        }
        public bool CheckForStraight()
        {
            int ace = 0;
            int deuce = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;
            int seven = 0;
            int eight = 0;
            int nine = 0;
            int ten = 0;
            int jack = 0;
            int queen = 0;
            int king = 0;



            foreach (Card c in _DiscardDeck)
            {
                switch (c.face)
                {
                    case "Ace":
                    ace += 1;
                    break;
                    case "Deuce":
                    deuce += 1;
                    break;
                    case "Three":
                        three += 1;
                        break;
                    case "Four":
                        four += 1;
                        break;
                    case "Five":
                        five += 1;
                        break;
                    case "Six":
                        six += 1;
                        break;
                    case "Seven":
                        seven += 1;
                        break;
                    case "Eight":
                        eight += 1;
                        break;
                    case "Nine":
                        nine += 1;
                        break;
                    case "Ten":
                        ten += 1;
                        break;
                    case "Jack":
                        jack += 1;
                        break;
                    case "Queen":
                        queen += 1;
                        break;
                    case "King":
                        king += 1;
                        break;
                }

            }
            bool wheel = ace > 0 && deuce > 0 && three > 0 && four > 0 && five > 0;
            bool twoSix = deuce > 0 && three > 0 && four > 0 && five > 0 && six > 0;
            bool threeSeven = three > 0 && four > 0 && five > 0 && six > 0 && seven > 0;
            bool fourEight = four > 0 && five > 0 && six > 0 && seven > 0 && eight > 0;
            bool fiveNine = five > 0 && six > 0 && seven > 0 && eight > 0 && nine > 0;
            bool sixTen = six > 0 && seven > 0 && eight > 0 && nine > 0 && ten > 0;
            bool sevenJack = seven > 0 && eight > 0 && nine > 0 && ten > 0 && jack > 0;
            bool eightQueen = eight > 0 && nine > 0 && ten > 0 && jack > 0 && queen > 0;
            bool nineKing = nine > 0 && ten > 0 && jack > 0 && queen > 0 && king > 0;
            bool tenAce = ten > 0 && jack > 0 && queen > 0 && king > 0 && ace > 0;
            bool straight = wheel || twoSix || threeSeven || fourEight || fiveNine || sixTen || sevenJack || eightQueen || nineKing || tenAce;
            if (straight)
            {
                totalStraights += 1;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
