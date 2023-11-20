using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();

            List<string> names= new List<string>
            {
                "Joe Blow",
                "Joe Schmoe",
                "John Smith",
                "Jane Doe",
                "Bob Bobberson",
                "Sam Sammerson",
                "Dave Daverson"
            };

            foreach (string name in names) 
            {
                Node<string> node = new Node<string>(null, name);
                list.AddLast(node);
            }

            //Lab Tests:
            //1. Adding nodes to the beginning of the list
            list.AddFirst(new Node<string>(null, "Dora the Explorer"));
            Console.WriteLine("First value is changed to: " + list.GetValue(0).Data);

            //2. Adding nodes to the last of the list
            list.AddLast(new Node<string>(null, "Boots the Monkey"));
            Console.WriteLine("Last value is changed to: " + list.GetValue(list.Count-1).Data);

            //3. Removing the first node on the list
            list.RemoveFirst();
            Console.WriteLine("First value is removed and changed to: " + list.GetValue(0).Data);

            //4. Removing the last node on the list
            list.RemoveLast();
            Console.WriteLine("Last value is removed and changed to: " + list.GetValue(list.Count-1).Data);

            //5. Retrieving the value of a node at a given index
            Console.WriteLine("Value at given index is: " + list.GetValue(4).Data);

            //6. Determining the size of the list
            Console.WriteLine("The size of the list can be accessed by using the Count property which is: " + list.Count);
        }
    }
    public class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public T Data { get { return _data; } set { _data = value; } }
        public Node<T> Next { get { return _next; } set { _next = value; } }

        public Node(Node<T> n, T data)
        {
            this._next = n;
            this._data = data;
        }

    }

    public class LinkedList<T>
    {
        public int Count {get; set;}
        public Node<T> head;

        public LinkedList() 
        {
            this.Count = 0;
            this.head = null;
        }

        public void AddFirst(Node<T> item)
        {
            if (this.head != null)
            {
                item.Next = this.head;
                this.head = item;
            }
            else
            {
                this.head = item;
                item.Next = null;
            }
            Count++;
        }
        public void AddLast(Node<T> item) 
        {
            if (this.head != null)
            {
                Node<T> node = this.head;
                while (node.Next != null) 
                {
                    node = node.Next;
                }
                node.Next = item;
                item.Next = null;
            }
            else
            {
                this.head = item;
                item.Next = null;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (this.head != null)
            {
                Node<T> node = this.head;
                this.head = node.Next;
                node = null;
                Count--;
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }

        public void RemoveLast() 
        {
            if (this.head != null)
            {
                Node<T> node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node = null;
                Count--;
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
        }

        public Node<T> GetValue(int index) 
        {
            Node<T> node = this.head;   
            for (int i = 0; i < (Count); i++)
            {
                if (i == index)
                {
                    return node;
                }
                else
                {
                    node = node.Next;
                }
            }
            return null;
        }
    }
}
