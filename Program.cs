using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    class Program
    {
        static void Main(string[] args)
        {
            Data Student_1 = new Data("Max", 1, true);
            Data Student_2 = new Data("Valerie", 4, false);
            Data Student_3 = new Data("Vania", 2, true);
            Data Student_4 = new Data("Ann", 1, false);
            Data Student_5 = new Data("Julia", 3, false);

            DoublyLinkedList MyList = new DoublyLinkedList();

            MyList.addFront(Student_1);
            MyList.addFront(Student_2);
            MyList.addBack(Student_4);
            MyList.addBack(Student_5);
            MyList.insertAfter(1, Student_3);
            MyList.print();
            Console.WriteLine("\n======================================\n");

            Console.WriteLine("Deleting of element: \n");
            MyList.deleteKey(2);
            MyList.print();
            Console.WriteLine("\n======================================\n");

            MyList.sort();
            Console.WriteLine("Sorted List: \n");
            MyList.print();
            Console.WriteLine("\n======================================\n");

            Console.WriteLine("Element for Searching was found: \n");
            MyList.Search(3);
            Console.WriteLine("\n======================================\n");

            Console.WriteLine($"Size: {MyList.getSize()}");
            Console.WriteLine("\n======================================\n");

            MyList.NameSearch("Valerie");
            Console.WriteLine("\n======================================\n");
        }
    }
}
