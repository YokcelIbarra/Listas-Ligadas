using LinkedListsProject.Models;

namespace LinkedListsProject.Structures;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    // First node in the list.
    private Node<T>? head;

    // Last node in the list.
    private Node<T>? tail;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        // Insert into an empty list.
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }

        // Insert before the first node.
        if (data.CompareTo(head.Data) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            return;
        }

        // Insert after the last node.
        if (tail != null && data.CompareTo(tail.Data) >= 0)
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
            return;
        }

        Node<T>? current = head;

        // Find the correct middle position.
        while (current.Next != null && data.CompareTo(current.Next.Data) >= 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Previous = current;

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }

        current.Next = newNode;
    }

    public void ShowForward()
    {
        if (head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node<T>? current = head;

        // Move from head to tail.
        while (current != null)
        {
            Console.Write(current.Data);

            if (current.Next != null)
            {
                Console.Write(" <-> ");
            }

            current = current.Next;
        }

        Console.WriteLine();
    }

    public void ShowBackward()
    {
        if (tail == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node<T>? current = tail;

        // Move from tail to head.
        while (current != null)
        {
            Console.Write(current.Data);

            if (current.Previous != null)
            {
                Console.Write(" <-> ");
            }

            current = current.Previous;
        }

        Console.WriteLine();
    }

    public bool Contains(T data)
    {
        Node<T>? current = head;

        // Search from head to tail.
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public bool RemoveOne(T data)
    {
        Node<T>? current = head;

        // Search the first match.
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                // Update the previous link.
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                // Update the next link.
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int RemoveAll(T data)
    {
        Node<T>? current = head;
        int removedCount = 0;

        // Search all matches.
        while (current != null)
        {
            Node<T>? nextNode = current.Next;

            if (current.Data.Equals(data))
            {
                // Update the previous link.
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                // Update the next link.
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                removedCount++;
            }

            current = nextNode;
        }

        return removedCount;
    }

    public void SortDescending()
    {
        if (head == null || head.Next == null)
        {
            return;
        }

        bool swapped;

        // Repeat until no swaps are needed.
        do
        {
            swapped = false;
            Node<T>? current = head;

            // Compare adjacent nodes.
            while (current.Next != null)
            {
                if (current.Data.CompareTo(current.Next.Data) < 0)
                {
                    T temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }

                current = current.Next;
            }
        }
        while (swapped);
    }

    public void ShowModes()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        int maxCount = 0;
        Node<T>? current = head;

        // Find the highest frequency.
        while (current != null)
        {
            bool alreadyProcessed = false;
            Node<T>? checker = head;

            // Check previous nodes.
            while (checker != current)
            {
                if (checker != null && checker.Data.Equals(current.Data))
                {
                    alreadyProcessed = true;
                    break;
                }

                checker = checker?.Next;
            }

            if (!alreadyProcessed)
            {
                int count = 0;
                Node<T>? counter = head;

                // Count matching nodes.
                while (counter != null)
                {
                    if (counter.Data.Equals(current.Data))
                    {
                        count++;
                    }

                    counter = counter.Next;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                }
            }

            current = current.Next;
        }

        Console.Write("Mode(s): ");
        bool firstMode = true;
        current = head;

        // Print all modes.
        while (current != null)
        {
            bool alreadyProcessed = false;
            Node<T>? checker = head;

            // Check previous nodes.
            while (checker != current)
            {
                if (checker != null && checker.Data.Equals(current.Data))
                {
                    alreadyProcessed = true;
                    break;
                }

                checker = checker?.Next;
            }

            if (!alreadyProcessed)
            {
                int count = 0;
                Node<T>? counter = head;

                // Count matching nodes.
                while (counter != null)
                {
                    if (counter.Data.Equals(current.Data))
                    {
                        count++;
                    }

                    counter = counter.Next;
                }

                if (count == maxCount)
                {
                    if (!firstMode)
                    {
                        Console.Write(", ");
                    }

                    Console.Write(current.Data);
                    firstMode = false;
                }
            }

            current = current.Next;
        }

        Console.WriteLine();
    }

    public void ShowChart()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node<T>? current = head;

        // Process each value once.
        while (current != null)
        {
            bool alreadyProcessed = false;
            Node<T>? checker = head;

            // Check previous nodes.
            while (checker != current)
            {
                if (checker != null && checker.Data.Equals(current.Data))
                {
                    alreadyProcessed = true;
                    break;
                }

                checker = checker?.Next;
            }

            if (!alreadyProcessed)
            {
                int count = 0;
                Node<T>? counter = head;

                // Count occurrences.
                while (counter != null)
                {
                    if (counter.Data.Equals(current.Data))
                    {
                        count++;
                    }

                    counter = counter.Next;
                }

                Console.Write(current.Data);
                Console.Write(" ");

                // Print one star per occurrence.
                for (int i = 0; i < count; i++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            current = current.Next;
        }
    }
}
