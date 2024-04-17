using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface ILinkedListADT<T>
    {
        void Add(T item);
        void AddLast(T item);
        void AddFirst(T item);
        void Replace(T oldItem, T newItem);
        int Count();
        T GetValue(int index);
        int IndexOf(T item);
        bool Contains(T item);
        bool IsEmpty();
        void Clear();
        void Remove(T item);
        void RemoveFirst();
        void RemoveLast();
    }
}

namespace SLL
{
    using Utility;

    public class SinglyLinkedList<T> : ILinkedListADT<T>
    {
        private Node<T> head;
        private int size;

        public SinglyLinkedList()
        {
            head = null;
            size = 0;
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        public void AddLast(T item)
        {
            Add(item);
        }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void Replace(T oldItem, T newItem)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (Equals(current.Data, oldItem))
                {
                    current.Data = newItem;
                    return;
                }
                current = current.Next;
            }
            throw new InvalidOperationException("Item to be replaced not found in the list.");
        }

        public int Count()
        {
            return size;
        }

        public T GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(T item)
        {
            Node<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1; 
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void Remove(T item)
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (Equals(head.Data, item))
            {
                head = head.Next;
                size--;
                return;
            }

            Node<T> current = head;
            while (current.Next != null)
            {
                if (Equals(current.Next.Data, item))
                {
                    current.Next = current.Next.Next;
                    size--;
                    return;
                }
                current = current.Next;
            }
            throw new InvalidOperationException("Item to be removed not found in the list.");
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty.");
            }
            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty.");
            }

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            size--;
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}

namespace ProblemDomain
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            User other = (User)obj;
            return Username == other.Username && Email == other.Email;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode() ^ Email.GetHashCode();
        }
    }
}
