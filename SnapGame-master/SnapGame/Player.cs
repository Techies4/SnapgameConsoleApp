using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnapGame
{
    public class Player
    {
        Dictionary<int, List<Card>> _playerCards;
        Dictionary<string, Card> _boardCards;
        Dictionary<string, string> _allCards;
        public Player()
        {
            _playerCards = new Dictionary<int, List<Card>>();
            _boardCards = new Dictionary<string, Card>();
            _allCards = new Dictionary<string, string>();
            Console.WriteLine($"Card Assignment to Players Started");
            for (int i = 0; i < 4; i++)
            {
                InitializePlayer(i);
            }
            Console.WriteLine($"Card Assignment to Players Completed");
        }

        /// <summary>
        /// 52 cards is shuffled and then dealt out equally among the players.
        /// currently, this console app continue with the 4 fixed players.
        /// we can make it dynamic by user input with number of players.
        /// </summary>
        /// <param name="playerIndex"> accept the n number of players to play game </param>
        private void InitializePlayer(int playerIndex)
        {
            Dictionary<string, Card> cards = new Dictionary<string, Card>();
            for (int i = 0; i < 13; i++)
            {
                Card card = Card.RandomCard();
                while (_allCards.ContainsKey(card.CardName))
                {
                    card = Card.RandomCard();
                }
                cards.Add(card.CardName, card);
                _allCards.Add(card.CardName, card.CardName);
            }
            _playerCards.Add(playerIndex, cards.Values.ToList());
        }

        /// <summary>
        /// It will start point of this console app and execute the game.
        /// As part of this demo console app, we consider the fixed 4 players.
        /// There will be logic that compare the player's card and snap if it is there.
        /// </summary>
        public void Start()
        {
            while(_playerCards.Values.Any())
            {
                for (int iPlayer = 0; iPlayer < 4; iPlayer++)
                {
                    if (_playerCards[iPlayer].Any())
                    {
                        Card card = _playerCards[iPlayer].ElementAt(0);
                        if (card != null) //no card remaining for the player
                        {
                            Console.WriteLine($"Player {iPlayer + 1}'s turn: Card is: {card.CardName}");
                            card.TurnOver();
                            if (!_boardCards.ContainsKey(card.CardName))
                            {
                                _boardCards.Add(card.CardName, card);
                                _playerCards[iPlayer].RemoveAt(0);

                                CompareLastTwoCards(iPlayer);
                            }
                        }
                    }
                }
                if (_playerCards[0].Count == 52)
                {
                    Console.WriteLine($"Player 1 Win");
                    break;
                }
                else if (_playerCards[1].Count == 52)
                {
                    Console.WriteLine($"Player 2 Win");
                    break;
                }
                else if (_playerCards[2].Count == 52)
                {
                    Console.WriteLine($"Player 3 Win");
                    break;
                }
                else if (_playerCards[3].Count == 52)
                {
                    Console.WriteLine($"Player 4 Win");
                    break;
                }
            }
            
            Console.WriteLine($"Game Over");
            Console.ReadLine();
        }

        /// <summary>
        /// Function has logic to compare the player's card
        /// and declare the final snap if any player have it. 
        /// </summary>
        /// <param name="currentPlayer"></param>
        private void CompareLastTwoCards(int currentPlayer)
        {
            if (_boardCards.Count > 1)
            {
                int lastIndex = _boardCards.Count - 1;
                int secondLastIndex = _boardCards.Count - 2;

                if (_boardCards.ElementAt(secondLastIndex).Value.Rank.Equals(_boardCards.ElementAt(lastIndex).Value.Rank))
                {
                    Console.WriteLine($"Its Snap. Player {currentPlayer + 1} will get all the open cards");
                    //Console.ReadKey();
                    foreach (Card card in _boardCards.Values)
                    {
                        card.TurnOver();
                        _playerCards[currentPlayer].Add(card);
                    }
                    _boardCards = new Dictionary<string, Card>();
                }
            }
        }
    }
}

