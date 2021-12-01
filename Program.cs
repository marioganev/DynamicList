using System;



public class DynamicList

{

    private class Node // класът, съхраняващ данните 

    {

        private object element;  // данни за един елемент 

        private Node next;        // указател към следващия елемент  



        public object Element

        {

            get { return element; }

            set { element = value; }

        }



        public Node Next

        {

            get { return next; }

            set { next = value; }

        }

        public Node(object element, Node prevNode)

        {

            this.element = element;

            prevNode.next = this;

        }



        public Node(object element)

        {

            this.element = element;

            next = null;

        }

    } // край на класа, съхраняващ данните (обекта) 





    private Node head;   // указател към първия елемент на списъка 

    private Node tail;     // указател към последния елемент на списъка 

    private int count;     // брой елементи в списъка 



    // Конструктор 

    public DynamicList()

    {

        this.head = null;

        this.tail = null;

        this.count = 0;

    }



    // добавя елемент в края на списъка 

    public void Add(object item)

    {

        if (head == null)   // ако списъка е празен 

        {

            head = new Node(item);

            tail = head;

        }

        else

        {

            // ако списъка не е празен добавя елемента най-отзад 

            Node newNode = new Node(item, tail);

            tail = newNode;

        }

        count++; // увеличава броя на елементите 

    }



    // премахва елемент от списъка с индекс 

    public object Remove(int index)

    {

        if (index >= count || index < 0)

        {

            throw new ArgumentOutOfRangeException("Invalid index: " + index);

        }





        // намира елемента със зададения индекс чрез обхождане на списъка 

        int currentIndex = 0;

        Node currentNode = head;

        Node prevNode = null;

        while (currentIndex < index)

        {

            prevNode = currentNode;

            currentNode = currentNode.Next;

            currentIndex++;

        }



        // премахва елемента 

        count--;

        if (count == 0)

        {

            head = null;

        }

        else if (prevNode == null)

        {

            head = currentNode.Next;

        }

        else

        {

            prevNode.Next = currentNode.Next;

        }



        // намира последния елемент 

        Node lastElement = null;

        if (this.head != null)

        {

            lastElement = this.head;

            while (lastElement.Next != null)

            {

                lastElement = lastElement.Next;

            }

        }

        tail = lastElement;

        return currentNode.Element;

    }



    public static void Main()

    {

        DynamicList shoppingList = new DynamicList();

        shoppingList.Add("Мляко");

        shoppingList.Add("Мед");

        shoppingList.Add("Маслини");

        shoppingList.Add("Бира");


        Console.WriteLine("Какво трябва да купим? ");

        for (int i = 0; i < shoppingList.count; i++)

        {

            Console.WriteLine(shoppingList);

        }

        Console.WriteLine("Трябва ли да купим хляб? Не");
    }
}