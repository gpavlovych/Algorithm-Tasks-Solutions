namespace Screening.TreeTests
{
    using System;
    using System.IO;

    using Screening.Tree;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for <see cref="Tree" /> class.
    /// </summary>
    [TestClass]
    public class TreeTests
    {
        /// <summary>
        /// Tests the <see cref="Tree.BuildTree"/> method with the correct input.
        /// </summary>
        [TestMethod]
        public void BuildTreeTest()
        {
            string inputString = @"Fox, The, Lazy
Quick, Fox, Jumps
Jumps, Dog, #
A, Quick, Brown
Brown, #, Over";
            using (var reader = new StringReader(inputString))
            {
                var result = Tree.BuildTree(reader);
                Assert.AreEqual("A", result.ToString());
                Assert.AreEqual("Quick", result.ChildLeft.ToString());
                Assert.AreEqual("Brown", result.ChildRight.ToString());
                Assert.AreEqual("Fox", result.ChildLeft.ChildLeft.ToString());
                Assert.AreEqual("Jumps", result.ChildLeft.ChildRight.ToString());
                Assert.IsNull(result.ChildRight.ChildLeft);
                Assert.AreEqual("Over", result.ChildRight.ChildRight.ToString());
                Assert.AreEqual("The", result.ChildLeft.ChildLeft.ChildLeft.ToString());
                Assert.AreEqual("Lazy", result.ChildLeft.ChildLeft.ChildRight.ToString());
                Assert.AreEqual("Dog", result.ChildLeft.ChildRight.ChildLeft.ToString());
                Assert.IsNull(result.ChildLeft.ChildRight.ChildRight);

                Assert.AreEqual(result, result.ChildLeft.Parent);
                Assert.AreEqual(result, result.ChildRight.Parent);
                Assert.AreEqual(result.ChildLeft, result.ChildLeft.ChildLeft.Parent);
                Assert.AreEqual(result.ChildLeft, result.ChildLeft.ChildRight.Parent);
                Assert.IsNull(result.ChildRight.ChildLeft);
                Assert.AreEqual(result.ChildRight, result.ChildRight.ChildRight.Parent);
                Assert.AreEqual(result.ChildLeft.ChildLeft, result.ChildLeft.ChildLeft.ChildLeft.Parent);
                Assert.AreEqual(result.ChildLeft.ChildLeft, result.ChildLeft.ChildLeft.ChildRight.Parent);
                Assert.AreEqual(result.ChildLeft.ChildRight, result.ChildLeft.ChildRight.ChildLeft.Parent);
                Assert.IsNull(result.ChildLeft.ChildRight.ChildRight);
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
    }
}