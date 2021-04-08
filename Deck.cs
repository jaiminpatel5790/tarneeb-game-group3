using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardDisplayTake3
{
    public class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card()
            {
                Suit = (Enums.Suit)s,
                CardNumber = (Enums.CardNumber)c
            }
                )
            ).ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);
            return takeCards;
        }

        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            return sorted;

        }


    }
    //public class Deck
    //{
    //    public Deck()
    //    {
    //        Reset();
    //    }

    //    public List<PlayingCard> Cards { get; set; }

    //    public void Reset()
    //    {
    //        Cards = Enumerable.Range(1, 4)
    //            .SelectMany(s => Enumerable.Range(1, 13)
    //                                .Select(c => new PlayingCard()
    //                                {
    //                                    cardSuit = (PlayingCard.Suits)s,
    //                                    cardNumber = (PlayingCard.CardNumber)c


    //                                }
    //                                        )
    //                        )
    //               .ToList();
    //    }
    //    /// <summary>
    //    /// Shuffles cards lol
    //    /// </summary>
    //    public void Shuffle()
    //    {
    //        Cards = Cards.OrderBy(c => Guid.NewGuid())
    //                     .ToList();
    //    }

    //    public PlayingCard TakeCard()
    //    {
    //        var card = Cards.FirstOrDefault();
    //        Cards.Remove(card);

    //        return card;
    //    }

    //    public List<PlayingCard> TakeCards(int numberOfCards)
    //    {
    //        var cards = Cards.Take(numberOfCards);

    //        //var takeCards = cards as Card[] ?? cards.ToArray();
    //        var takeCards = cards as List<PlayingCard> ?? cards.ToList();
    //        Cards.RemoveAll(takeCards.Contains);

    //        return takeCards;
    //    }

    //    public List<PlayingCard> Sort(List<PlayingCard> listOfCards)
    //    {
    //        List<PlayingCard> sorted = listOfCards.GroupBy(s => s.cardSuit).
    //            OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.cardNumber)).ToList();

    //        return sorted;

    //    }
    //}
}
