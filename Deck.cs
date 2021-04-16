using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace CardDisplayTake3
{
    /// <summary>
    /// Deck class creates a deck from the cards that we get from the cards class
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// A default constructor which will make the reset the deck to its original form
        /// </summary>
        public Deck()
        {
            Reset();
        }

        // A list of card objects
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Reset method will reset the whole deck to its original form 
        /// </summary>
        public void Reset()
        {
            // Using LINQ query returning the list of cards 
            Cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card()
            {
                Suit = (Enums.Suit)s,
                CardNumber = (Enums.CardNumber)c
            }
                )
            ).ToList();
        }

        /// <summary>
        /// This method will shuffle the card objects
        /// </summary>
        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        /// <summary>
        /// This method will remove the card from the list and return it
        /// </summary>
        /// <returns></returns>
        public Card TakeCard()
        {
            //Taking first card
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        /// <summary>
        /// This method will remove number of cards specified from the deck and give it to the players
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);
            return takeCards;
        }

        /// <summary>
        /// This method will sort the list of cards object
        /// </summary>
        /// <param name="listOfCards"> list containing all the list objects</param>
        /// <returns> the sorted list </returns>
        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            return sorted;

        }


    }
    
}
