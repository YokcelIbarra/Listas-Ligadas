namespace LinkedListsProject.Models;

public class Node<T>
{
    // Stored value.
    public T Data { get; set; }

    // Reference to the next node.
    public Node<T>? Next { get; set; }

    // Reference to the previous node.
    public Node<T>? Previous { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}
