namespace Screening.Tree
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
        /// <summary>
        /// The name of this node.
        /// </summary>
        private string contents;

        /// <summary>
        /// Prevents a default instance of the <see cref="Tree"/> class from being created.
        /// </summary>
        private Tree()
        {
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
            Dictionary<string, Tree> allNodes = new Dictionary<string, Tree>();
            Dictionary<string, Tree> parentNodes = new Dictionary<string, Tree>();
            Dictionary<string, Tree> childNodes = new Dictionary<string, Tree>();
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                ProcessNodeImage(line, allNodes, parentNodes, childNodes);
            }

            var roots = parentNodes.Except(childNodes).ToList();
            if (roots.Count() > 1)
            {
                throw new ArgumentException("Invalid tree specified: multiple roots detected");
            }

            if (!roots.Any() && parentNodes.Any())
            {
                throw new ArgumentException("Invalid tree specified: loops detected");
            }

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
            string[] items = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length != 3)
            {
                throw new ArgumentException(
                    "Invalid format of node image: parent_node, child_left_node|#, child_right_node|#");
            }

            var parentKey = items[0].Trim();
            var childLeftKey = items[1].Trim();
            var childRightKey = items[2].Trim();
            var parent = AddNodeByNameIfNotExists(parentKey, nodes, parentWatchedNodes, true);
            var childLeft = AddNodeByNameIfNotExists(childLeftKey, nodes, childWatchedNodes, false);
            var childRight = AddNodeByNameIfNotExists(childRightKey, nodes, childWatchedNodes, false);
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
        /// Invalid tree specified: node name can contain one or more UPPERCASE and/or lowercase English characters.
        /// or
        /// Invalid tree specified: parent is declared multiple times
        /// or
        /// Invalid tree specified: cycle detected
        /// or
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
                if (!nodes.ContainsKey(nodeName))
                {
                    if (!Regex.IsMatch(nodeName, "^[a-zA-Z]+$"))
                    {
                        throw new ArgumentException("Invalid tree specified: node name can contain one or more UPPERCASE and/or lowercase English characters.");
                    }

                    node = new Tree { contents = nodeName };
                    nodes.Add(nodeName, node);
                }
                else
                {
                    node = nodes[nodeName];
                }

                if (!watchedNodes.ContainsKey(nodeName))
                {
                    watchedNodes[nodeName] = node;
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
            else
            {
                if (isParent)
                {
                    throw new ArgumentException("Invalid tree specified: parent cannot be null");
                }
            }

            return node;
        }
    }
}
