namespace Screening.TreeAnalysisTests
{
    using System;
    using System.IO;

    using Screening.TreeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for <see cref="Tree" /> class.
    /// </summary>
    [TestClass]
    public class TreeTests
    {
        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the correct input: single node with no children.
        /// </summary>
        [TestMethod]
        public void BuildTreeTestSingle()
        {
            //arrange
            string inputString = @"HeadNode, #, #";
            Tree expectedResult = new Tree("HeadNode", null, null);
            using (var reader = new StringReader(inputString))
            {

                //act
                var result = Tree.BuildTree(reader);

                //assert
                AssertTreeEqual(expectedResult, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the correct input.
        /// </summary>
        [TestMethod]
        public void BuildTreeTest()
        {
            //arrange
            string inputString = @"Fox, The, Lazy
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            var expectedResult = new Tree(
                "A",
                new Tree(
                    "Quick",
                    new Tree("Fox", 
                        new Tree("The", 
                            null, 
                            null), 
                        new Tree("Lazy", 
                            null, 
                            null)),
                    new Tree("Jumps", 
                        new Tree("Dog", 
                            null, 
                            null), 
                        null)),
                new Tree("Brown", 
                    null, 
                    new Tree("Over", 
                        null, 
                        null)));
            using (var reader = new StringReader(inputString))
            {

                //act
                var result = Tree.BuildTree(reader);
               
                //assert
                AssertTreeEqual(expectedResult, result);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (one of node names contains non-latin character).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestNonLatinName()
        {
            string inputString = @"F2ox, The, Lazy
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (one of lines has invalid format).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestInvalidLineFormat()
        {
            string inputString = @"Fox, The, Lazy, Lazy2
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (node name consists of non-alphabetic characters).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestNumericEntries()
        {
            string inputString = @"213, #, #";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (one of lines has # parent).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestAllSharps()
        {
            string inputString = @"#, #, #";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (one of lines has # parent).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestParentSharp()
        {
            string inputString = @"#, The, Lazy
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (multiple roots detected).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestMultipleRoots()
        {
            string inputString = @"Fox, The, Lazy
Quicka, Fox, Jumps
Jumps, Dog, #
A, Quickn, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (loops detected).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestLoops()
        {
            string inputString = @"Fox, The, Lazy
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, A";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (cycles detected).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeTestCycle()
        {
            string inputString = @"Fox, The, Dog
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the incorrect input (multiple parent occurrences detected).
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BuildTreeSameParents()
        {
            string inputString = @"Fox, The, Lazy
A, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                Tree.BuildTree(reader);
            }
        }

        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the empty input.
        /// </summary>
        [TestMethod]
        public void BuildTreeTestEmpty()
        {
            string inputString = @" 
";
            using (var reader = new StringReader(inputString))
            {
                var result = Tree.BuildTree(reader);
                Assert.IsNull(result);
            }
        }

        #region Helper methods

        private static void AssertTreeEqual(Tree expected, Tree actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
            }
            else
            {

                Assert.AreEqual(expected.ToString(), actual.ToString());
                AssertTreeEqual(expected.ChildLeft, actual.ChildLeft);
                AssertTreeEqual(expected.ChildRight, actual.ChildRight);
            }
        }

        #endregion Helper methods
    }
}