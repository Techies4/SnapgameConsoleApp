using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnapGame.UnitTest
{
    public class CardTest
    {
        [Test]
        public void TestCardCreation()
        {
            Card c = new Card(Rank.KING, Suit.HEART);
            c.TurnOver();
            Assert.AreEqual(Rank.KING, c.Rank);
            Assert.AreEqual(Suit.HEART, c.Suit);

            c = new Card(Rank.TWO, Suit.DIAMOND);
            c.TurnOver();
            Assert.AreEqual(Rank.TWO, c.Rank);
            Assert.AreEqual(Suit.DIAMOND, c.Suit);
        }

        [Test]
        public void TestCardIndex()
        {
            Card c = new Card(Rank.ACE, Suit.SPADE);
            Assert.AreEqual(52, c.CardIndex);
            c.TurnOver();
            Assert.AreEqual(0, c.CardIndex);

            c = new Card(Rank.KING, Suit.CLUB);
            Assert.AreEqual(52, c.CardIndex);
            c.TurnOver();
            Assert.AreEqual(51, c.CardIndex);
        }

        [Test]
        public void TestCardToString()
        {
            Card c = new Card(Rank.ACE, Suit.SPADE);
            c.TurnOver();
            Assert.AreEqual("AceSpade", c.ToString());

            c = new Card(Rank.TEN, Suit.CLUB);
            c.TurnOver();
            Assert.AreEqual("TenClub", c.ToString());

            c = new Card(Rank.THREE, Suit.DIAMOND);
            c.TurnOver();
            Assert.AreEqual("3Diamond", c.ToString());

            c = new Card(Rank.JACK, Suit.HEART);
            c.TurnOver();
            Assert.AreEqual("JackHeart", c.ToString());
        }

        [Test]
        public void TestCardTurnOver()
        {
            Card c = new Card(Rank.ACE, Suit.DIAMOND);
            Assert.AreEqual("**", c.ToString());
            c.TurnOver();
            Assert.AreEqual("AceDiamond", c.ToString());
            c.TurnOver();
            Assert.AreEqual("**", c.ToString());

            c = new Card(Rank.FOUR, Suit.HEART);
            Assert.AreEqual("**", c.ToString());
            c.TurnOver();
            Assert.AreEqual("4Heart", c.ToString());
        }
    }
}
