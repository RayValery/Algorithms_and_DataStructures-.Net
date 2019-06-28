using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class DoublyLinkedList
    {
        private Node head;
        private int size;

        public DoublyLinkedList()
        {
            head = null;
            size = 0;
        }

        private bool isEmpty()
        {
            return head == null;
        }

        public void Search(int course)
        {
            Node current = head;
            while (current != null)
            {
                int a = current.getMyStudent().getCourse();
                if (a == course)
                {
                    Console.WriteLine(current.toString());
                }
                current = current.getNext();
            }
        }

        public void NameSearch(string name)
        {
            Node current = head;
            while (current != null)
            {
                string a = current.getMyStudent().getName();
                if (a == name)
                {
                    Console.WriteLine(current.toString());
                }
                current = current.getNext();
            }
        }

        public void addFront(Data node)
        {
            if (head == null)
            {
                head = new Node(node);
                head.setPrevious(null);
                head.setNext(null);
            }
            else
            {
                Node newNode = new Node(node);
                newNode.setNext(head);
                head = newNode;
            }
            size++;
        }

        public void addBack(Data node)
        {
            if (head == null)
            {
                head = new Node(node);
                head.setPrevious(null);
                head.setNext(null);
            }
            else
            {
                Node current = head;
                while (current.getNext() != null)
                {
                    current = current.getNext();
                }
                Node newNode = new Node(node);
                newNode.setPrevious(current);
                current.setNext(newNode);
            }
            size++;
        }

        public void removeFront()
        {
            if (head == null) return;
            head = head.getNext();
            head.setPrevious(null);
            size--;
        }

        public void removeBack()
        {
            if (head == null) return;
            if (head.getNext() == null)
            {
                head = null;
                size--;
                return;
            }

            Node current = head;
            while (current.getNext().getNext() != null)
            {
                current = current.getNext();
            }
            current.setNext(null);
            size--;
        }

        public void print()
        {
            if (isEmpty()) { Console.WriteLine("No nodes for print"); return; }
            Console.WriteLine("First ---> Last");
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.toString());
                current = current.getNext();
            }
        }

        public void sort()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if ((head.getNext() == null)
                    && (head.getPrevious() == null))
            {
                Console.WriteLine("List has one node");
                return;
            }
            Node current = head;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; current.getNext() != null; j++)
                {
                    int h1 = current.getMyStudent().getCourse();
                    int h2 = current.getNext().getMyStudent().getCourse();
                    if (h1 > h2)
                    {
                        Data buffer = current.getMyStudent();
                        current.setMyStudent(current.getNext().getMyStudent());
                        current.getNext().setMyStudent(buffer);
                    }
                    current = current.getNext();
                }
                current = head;
            }
        }

        public int getSize() { return size; }

        public void insertAfter(int key, Data Student)
        {
            if (this.isEmpty()) return;
            Node current = head;          // start at beginning
            int count = 0;
            while (current.getNext() != null && count != key)    // until match is found,
            {
                current = current.getNext();     // move to next Node
                count++;
            }

            Node newNode = new Node(Student);   // make new Node

            if (current.getNext() == null)              // if last Node,
            {
                newNode.setNext(null);        // newNode --> null
                newNode.setPrevious(current);
                current.setNext(newNode);
                current = newNode;             // newNode <-- last
            }
            else                           // not last Node,
            {
                newNode.setNext(current.getNext()); // newNode --> old next
                                                    // newNode <-- old next
                current.getNext().setPrevious(newNode);
            }
            newNode.setPrevious(current);    // old current <-- newNode
            current.setNext(newNode);        // old current --> newNode
            size++;

        }

        public void deleteKey(int key)   
        {                              // (assumes non-empty list)??????????????
            if (this.isEmpty()) return;
            Node current = head;          // start at beginning
            int count = 0;
            while (current.getNext() != null && count != key)    // until match is found,
            {
                current = current.getNext();      // move to next Node
                count++;
            }
            if (current == head)             // found it; first item?
                head = current.getNext();       // first --> old next


            if (current.getNext() == null)              // last item?
                current = current.getPrevious();    // old previous <-- last
            else                           // not last
                                           // old previous <-- old next
                current = current.getPrevious();
            current.setNext(current.getNext().getNext());
            current.getNext().setPrevious(current);
            size--;
        }

    }
}
