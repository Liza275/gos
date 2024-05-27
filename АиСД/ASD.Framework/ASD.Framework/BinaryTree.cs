using System;
using System.Collections.Generic;

namespace ASD.Framework
{

    public class BinaryTree
    {
        private Node root;

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node { Data = value };
            }
            else
            {
                AddTo(root, value);
            }
        }

        private void AddTo(Node node, int value)
        {
            if (value < node.Data)
            {
                if (node.Left == null)
                {
                    node.Left = new Node { Data = value };
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node { Data = value };
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public void Remove(int value)
        {
            Node current;
            Node parent;

            current = FindWithParent(value, out parent);

            if (current == null)
            {
                return;
            }

            if (current.Right == null)
            {
                if (parent == null)
                {
                    root = current.Left;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = current.Left;
                    }
                    if (parent.Data < current.Data)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    root = current.Right;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = current.Right;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node leftmost = current.Right.Left;
                Node leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    root = leftmost;
                }
                else
                {
                    if (parent.Data > current.Data)
                    {
                        parent.Left = leftmost;
                    }
                    else if (parent.Data < current.Data)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
        }

        private Node FindWithParent(int value, out Node parent)
        {
            Node current = root;
            parent = null;

            while (current != null)
            {
                if (current.Data > value)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (current.Data < value)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public bool Contains(int value)
        {
            Node parent;
            return FindWithParent(value, out parent) != null;
        }

        // Метод для вывода бинарного дерева в консоль
        public void Print()
        {
            Print(root, 0);
        }

        private void Print(Node node, int indent)
        {
            if (node != null)
            {
                Console.WriteLine(new string(' ', indent) + node.Data);
                Print(node.Left, indent + 2);
                Print(node.Right, indent + 2);
            }
        }
    }

    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
    }

}
