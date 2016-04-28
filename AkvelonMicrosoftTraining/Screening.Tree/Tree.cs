using System.Data;

namespace Screening.TreeAnalysis
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class which represents binary tree (each node can contain 0, 1 or 2 child nodes).
    /// </summary>
    public class Tree
    {
        private struct TreeKeys
        {
            public TreeKeys(string parentKey, string childLeftKey, string childRightKey)
            {
                this.ParentKey = parentKey;
                this.ChildLeftKey = childLeftKey;
                this.ChildRightKey = childRightKey;
            }
            public string ParentKey { get; }

            public string ChildLeftKey { get; }

            public string ChildRightKey { get; }

            public static TreeKeys Parse(string line)
            {
                string[] items = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length != 3)
                {
                    throw new ArgumentException(
                        "Invalid format of node image: parent_node, child_left_node|#, child_right_node|#");
                }

                var parentKey = items[0].Trim();
                var childLeftKey = items[1].Trim();
                var childRightKey = items[2].Trim();
                return new TreeKeys(parentKey, childLeftKey, childRightKey);
            }
        }
        /// <summary>
        /// The name of this node.
        /// </summary>
        private string contents;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tree"/> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="childLeft">The child left.</param>
        /// <param name="childRight">The child right.</param>
        public Tree(string contents, Tree childLeft, Tree childRight)
        {
            this.contents = contents;
            this.ChildLeft = childLeft;
            this.ChildRight = childRight;
        }

        /// <summary>
        /// Gets the child left node.
        /// </summary>
        /// <value>
        /// The child left node.
        /// </value>
        public Tree ChildLeft { get; private set; }

        /// <summary>
        /// Gets the child right node.
        /// </summary>
        /// <value>
        /// The child right node.
        /// </value>
        public Tree ChildRight { get; private set; }

        /// <summary>
        /// Gets the parent node.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        public Tree Parent { get; private set; }

        /// <summary>
        /// Builds the tree of its node images specified in separate lines.
        /// </summary>
        /// <param name="reader">The reader which contains images of tree nodes.</param>
        /// <returns>
        /// The tree which has been built.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Invalid tree specified: multiple roots detected
        /// or
        /// Invalid tree specified: loops detected
        /// </exception>
        public static Tree BuildTree(TextReader reader)
        {
            string line;

            // Storage of all tree nodes by key (when algorithm creates new node, it looks up if an instance with the same content already exist here)
            Dictionary<string, Tree> allNodes = new Dictionary<string, Tree>();

            // Storage of tree nodes by key which have children
            Dictionary<string, Tree> parentNodes = new Dictionary<string, Tree>();

            // Storage of tree nodes by key which have parents
            Dictionary<string, Tree> childNodes = new Dictionary<string, Tree>();

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                ProcessNodeImage(line, allNodes, parentNodes, childNodes);
            }

            // Detect nodes without parents (roots).
            var roots = parentNodes.Except(childNodes).ToList();

            // More than 1 root exist - invalid tree structure
            if (roots.Count() > 1)
            {
                throw new ArgumentException("Invalid tree specified: multiple roots detected");
            }

            // No roots exist but there are nodes which have children
            if (!roots.Any() && parentNodes.Any())
            {
                throw new ArgumentException("Invalid tree specified: loops detected");
            }

            // Return root
            return roots.SingleOrDefault().Value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.contents;
        }

        /// <summary>
        /// Processes the node image (specified as comma separated text line: parent_node_key, child_left_node_key|#, child_right_node_key|#).
        /// </summary>
        /// <param name="line">The line which represents node image.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="parentWatchedNodes">The list of parent nodes which were watched.</param>
        /// <param name="childWatchedNodes">The list of child nodes which were watched.</param>
        /// <exception cref="System.ArgumentException">Invalid format of node image: parent_node, child_left_node|#, child_right_node|#</exception>
        private static void ProcessNodeImage(
            string line,
            Dictionary<string, Tree> nodes,
            Dictionary<string, Tree> parentWatchedNodes,
            Dictionary<string, Tree> childWatchedNodes)
        {
            var parsedLine = TreeKeys.Parse(line);
            var parent = AddNodeByNameIfNotExists(parsedLine.ParentKey, nodes, parentWatchedNodes, true);
            var childLeft = AddNodeByNameIfNotExists(parsedLine.ChildLeftKey, nodes, childWatchedNodes, false);
            var childRight = AddNodeByNameIfNotExists(parsedLine.ChildRightKey, nodes, childWatchedNodes, false);
            parent.ChildLeft = childLeft;
            parent.ChildRight = childRight;
            SetParent(childLeft, parent);
            SetParent(childRight, parent);
        }

        /// <summary>
        /// Sets the parent for the child node.
        /// </summary>
        /// <param name="child">The child node.</param>
        /// <param name="parent">The parent.</param>
        private static void SetParent(Tree child, Tree parent)
        {
            if (child != null)
            {
                child.Parent = parent;
            }
        }

        /// <summary>
        /// Adds the node by name to the dictionary of all nodes if not exists or returns existing.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodes">The nodes.</param>
        /// <param name="watchedNodes">The list of watched nodes.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns>
        /// An instance of <see cref="Tree" /> which belongs to the dictionary of nodes.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Invalid tree specified: parent cannot be null
        /// </exception>
        private static Tree AddNodeByNameIfNotExists(
            string nodeName,
            Dictionary<string, Tree> nodes,
            Dictionary<string, Tree> watchedNodes,
            bool isParent)
        {
            Tree node = null;
            if (nodeName != "#")
            {
                node = FindOrCreateNode(nodeName, nodes);

                EnsureNodeNotWatched(nodeName, watchedNodes, isParent, node);
            }
            else
            {
                if (isParent)
                {
                    throw new ArgumentException("Invalid tree specified: parent cannot be null");
                }
            }

            return node;
        }

        /// <summary>
        /// Ensures the node not watched (if it occured in child nodes, can no more occur in child nodes and the same for parent nodes).
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="watchedNodes">The watched nodes.</param>
        /// <param name="isParent">if set to <c>true</c> the node is parent.</param>
        /// <param name="node">The node.</param>
        /// <exception cref="ArgumentException">
        /// Invalid tree specified: parent is declared multiple times
        /// or
        /// Invalid tree specified: cycle detected
        /// </exception>
        private static void EnsureNodeNotWatched(string nodeName, Dictionary<string, Tree> watchedNodes, bool isParent, Tree node)
        {
            if (!watchedNodes.ContainsKey(nodeName))
            {
                watchedNodes[ nodeName ] = node;
            }
            else
            {
                if (isParent)
                {
                    throw new ArgumentException("Invalid tree specified: parent is declared multiple times");
                }
                else
                {
                    throw new ArgumentException("Invalid tree specified: cycle detected");
                }
            }
        }

        /// <summary>
        /// Finds the node in the storage or creates and adds to storage if not found.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodes">The storage of nodes.</param>
        /// <returns>An instance of <see cref="Tree"/> from storage.</returns>
        private static Tree FindOrCreateNode(string nodeName, Dictionary<string, Tree> nodes)
        {
            Tree node;
            if (!nodes.TryGetValue(nodeName, out node))
            {
                ValidateNodeName(nodeName);

                node = new Tree(nodeName, null, null);
                nodes.Add(nodeName, node);
            }
            return node;
        }

        /// <summary>
        /// Validates the name of the node to make sure it consists of latin characters only.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <exception cref="ArgumentException">Invalid tree specified: node name can contain one or more UPPERCASE and/or lowercase English characters.</exception>
        private static void ValidateNodeName(string nodeName)
        {
            if (!Regex.IsMatch(nodeName, "^[a-zA-Z]+$"))
            {
                throw new ArgumentException(
                    "Invalid tree specified: node name can contain one or more UPPERCASE and/or lowercase English characters.");
            }
        }
    }
}
