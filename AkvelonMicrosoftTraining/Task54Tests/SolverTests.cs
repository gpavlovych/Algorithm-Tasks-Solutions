namespace Task54Tests
{
    using System;

    using BaseTests.Tests;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Task54;

    [TestClass]
    public class SolverTests
    {
        private void ShuffleTest(int cardsNumber, Func<int, int, bool> feedBack = null)
        {
            //arrange
            int[] cards = new int[cardsNumber];
            int[] initialCards = new int[cardsNumber];
            for (var cardIndex = 0; cardIndex < cardsNumber; cardIndex++)
            {
                initialCards[cardIndex] = cards[cardIndex] = cardIndex + 1;
            }

            //act
            Solver.Shuffle(cards, feedBack);

            //assert
            if (cardsNumber > 0)
            {
                TestHelper.AssertCollectionsNotEqual(initialCards, cards);
            }
        }

        [TestMethod]
        public void ShuffleTest10()
        {
            this.ShuffleTest(10, (item, index) => true);
        }

        [TestMethod]
        public void ShuffleTest52()
        {
            this.ShuffleTest(52, (item, index) => true);
        }

        [TestMethod]
        public void ShuffleTest0()
        {
            this.ShuffleTest(0, (item, index) => true);
        }

        [TestMethod]
        public void ShuffleTest10FeedbackNull()
        {
            this.ShuffleTest(10);
        }

        [TestMethod]
        public void ShuffleTest52FeedbackNull()
        {
            this.ShuffleTest(52);
        }

        [TestMethod]
        public void ShuffleTest0FeedbackNull()
        {
            this.ShuffleTest(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShuffleTestCardsNull()
        {
            Solver.Shuffle<int>(null, (item, index) => true);
        }
    }
}
