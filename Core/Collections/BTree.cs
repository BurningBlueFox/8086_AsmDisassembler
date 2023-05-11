using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS0693
namespace AsmParser.Core.Collections
{
    public class BTree<T>
    {
        [NotNull] private readonly Node<T> _root = new();

        public void Add(IEnumerable<int> sequence, T t)
        {
            var boolList = sequence.Select(i => i > 0).ToList();
            Add(boolList, t);
        }
        public void Add(IEnumerable<bool> sequence, T t)
        {
            var selectedNode = _root;
            foreach (var b in sequence)
            {
                if (b)
                {
                    selectedNode.Right ??= new Node<T>();
                    selectedNode = selectedNode.Right;
                }
                else
                {
                    selectedNode.Left ??= new Node<T>();
                    selectedNode = selectedNode.Left;
                }
            }
            selectedNode.Content = t;
        }

        public T Retrieve(IEnumerable<bool> sequence)
        {
            var selectedNode = _root;
            foreach (var b in sequence)
            {
                if (b)
                {
                    if (selectedNode.Right == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find right node");
                    selectedNode = selectedNode.Right;
                }
                else
                {
                    if (selectedNode.Left == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find left node");
                    selectedNode = selectedNode.Left;
                }
            }
            if (selectedNode.Content == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find content in leaf node");
            return selectedNode.Content;
        }

        public T TraverseUntilFound(IEnumerable<int> sequence)
        {
            var boolList = sequence.Select(i => i > 0).ToList();
            return TraverseUntilFound(boolList);
        }
        
        public T TraverseUntilFound(IEnumerable<bool> sequence)
        {
            var selectedNode = _root;
            foreach (var b in sequence)
            {
                if (b)
                {
                    if (selectedNode.Right == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find right node");
                    selectedNode = selectedNode.Right;
                    if (selectedNode.Content != null) return selectedNode.Content;
                }
                else
                {
                    if (selectedNode.Left == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find left node");
                    selectedNode = selectedNode.Left;
                    if (selectedNode.Content != null) return selectedNode.Content;
                }
            }
            if (selectedNode.Content == null) Console.Error.WriteLine($"{this}:: Retrieve traversal didnt find content in leaf node");
            return selectedNode.Content;
        }

        private class Node<T>
        {
            public T Content = default!;
            public Node<T> Left = null!;
            public Node<T> Right = null!;
        }
    }
}