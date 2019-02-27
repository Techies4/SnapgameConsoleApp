using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapGame
{
    public enum Suit
    {
        CLUB,
        DIAMOND,
        HEART,
        SPADE
    }
    public enum Rank
    {
        ACE = 1,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING //king is 13
    }
    public class Card
    {
        private Rank _rank;
        private Suit _suit;
        private bool _faceUp;

       

        public Card(Rank r, Suit s)
        {
            _rank = r;
            _suit = s;
            _faceUp = false;
        }

        public static Card RandomCard()
        {
            Random rnd = new Random();

            Rank randomRank = (Rank)(rnd.Next((int)Rank.KING) + 1);
            Suit randomSuit = (Suit)(rnd.Next((int)Suit.SPADE + 1));

            Card randomCard = new Card(randomRank, randomSuit);

            return randomCard;
        }

        public Rank Rank
        {
            get { return _rank; }
        }
        public Suit Suit
        {
            get { return _suit; }
        }
        public bool FaceUp
        {
            get { return _faceUp; }
        }
        public void TurnOver()
        {
            _faceUp = !_faceUp;
        }
        public int CardIndex
        {
            get
            {
                if (_faceUp)
                {
                    switch (_suit)
                    {
                        case Suit.SPADE:
                            return (int)_rank - 1; // Ace = 1, but Ace Spades should be 0
                        case Suit.HEART:
                            return 12 + (int)_rank;
                        case Suit.DIAMOND:
                            return 25 + (int)_rank;
                        case Suit.CLUB:
                            return 38 + (int)_rank;
                        default:
                            return 52;
                    }
                }
                else
                    return 52;

            }
        }

        public string CardName => _rank.ToString() + _suit.ToString();

        public override string ToString()
        {
            if (_faceUp)
            {
                String result = "";

                switch (_rank)
                {
                    case Rank.JACK:
                        result += "Jack";
                        break;
                    case Rank.QUEEN:
                        result += "Queen";
                        break;
                    case Rank.KING:
                        result += "King";
                        break;
                    case Rank.ACE:
                        result += "Ace";
                        break;
                    case Rank.TEN:
                        result += "Ten";
                        break;
                    default:
                        result += (int)_rank;
                        break;
                }

                switch (_suit)
                {
                    case Suit.CLUB:
                        result += "Club";
                        break;
                    case Suit.SPADE:
                        result += "Spade";
                        break;
                    case Suit.HEART:
                        result += "Heart";
                        break;
                    case Suit.DIAMOND:
                        result += "Diamond";
                        break;
                    default:
                        result += "?";
                        break;
                }

                return result;
            }
            else
            {
                return "**";
            }
        }
    }
}
