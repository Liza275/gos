using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Framework
{
    internal class CircleList
    {
        private class Node
        {
            public User Data { get; set; }
            public Node Next { get; set; }

            public Node(User data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private Node tail;

        public CircleList()
        {
            head = null;
            tail = null;
        }

        public void Add(User user)
        {
            Node newNode = new Node(user);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                newNode.Next = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                tail.Next = head;
            }
        }

        public bool Remove(int userId)
        {
            if (head == null) return false;

            Node current = head;
            Node previous = null;
            do
            {
                if (current.Data.Id == userId)
                {
                    if (current == head)
                    {
                        head = head.Next;
                        tail.Next = head;
                    }
                    else if (current == tail)
                    {
                        tail = previous;
                        tail.Next = head;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);

            return false;
        }

        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node current = head;
            do
            {
                Console.WriteLine(current.Data.Name);
                current = current.Next;
            } while (current != head);
        }
    }
}
