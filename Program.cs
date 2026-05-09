using LinkedListsProject.Structures;

namespace LinkedListsProject;

internal class Program
{
    private static void Main()
    {
        DoublyLinkedList<string> list = new DoublyLinkedList<string>();
        string option;

        // Show the full menu only once.
        ShowMenu();

        // Repeat until exit.
        do
        {
            Console.Write("Seleccione una opción: ");
            option = Console.ReadLine() ?? string.Empty;

            Console.WriteLine();

            switch (option)
            {
                case "1":
                    AddElement(list);
                    break;

                case "2":
                    list.ShowForward();
                    Console.WriteLine("La impresión de los elementos se muestra ordenada hacia adelante.");
                    break;

                case "3":
                    list.ShowBackward();
                    Console.WriteLine("La impresión de los elementos se muestra ordenada hacia atrás.");
                    break;

                case "4":
                    list.SortDescending();
                    Console.WriteLine("La lista fue ordenada descendentemente.");
                    break;

                case "5":
                    list.ShowModes();
                    Console.WriteLine("La moda corresponde al dato o datos con mayor número de ocurrencias.");
                    break;

                case "6":
                    list.ShowChart();
                    Console.WriteLine("El gráfico muestra la cantidad de ocurrencias de cada dato mediante asteriscos.");
                    break;

                case "7":
                    SearchElement(list);
                    break;

                case "8":
                    RemoveOneElement(list);
                    break;

                case "9":
                    RemoveAllElements(list);
                    break;

                case "0":
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            Console.WriteLine();
        }
        while (option != "0");
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Lista doblemente ligada");
        Console.WriteLine("1. Adicionar");
        Console.WriteLine("2. Mostrar hacia adelante");
        Console.WriteLine("3. Mostrar hacia atrás");
        Console.WriteLine("4. Ordenar descendentemente");
        Console.WriteLine("5. Mostrar la(s) moda(s)");
        Console.WriteLine("6. Mostrar gráfico");
        Console.WriteLine("7. Existe");
        Console.WriteLine("8. Eliminar una ocurrencia");
        Console.WriteLine("9. Eliminar todas las ocurrencias");
        Console.WriteLine("0. Salir");
    }

    private static void AddElement(DoublyLinkedList<string> list)
    {
        string element = ReadRequiredElement("Ingrese el dato: ");
        list.Add(element);
        Console.WriteLine("El dato fue agregado correctamente y ubicado según el orden de la lista.");
    }

    private static void SearchElement(DoublyLinkedList<string> list)
    {
        string element = ReadRequiredElement("Ingrese el dato a buscar: ");

        if (list.Contains(element))
        {
            Console.WriteLine("El dato existe en la lista.");
        }
        else
        {
            Console.WriteLine("El dato no existe en la lista.");
        }

        Console.WriteLine("La búsqueda verifica si al menos una ocurrencia del dato está en la lista.");
    }

    private static void RemoveOneElement(DoublyLinkedList<string> list)
    {
        string element = ReadRequiredElement("Ingrese el dato a eliminar: ");

        if (list.RemoveOne(element))
        {
            Console.WriteLine("Se eliminó una ocurrencia.");
        }
        else
        {
            Console.WriteLine("No se encontró el dato.");
        }

        Console.WriteLine("La operación elimina únicamente la primera ocurrencia encontrada.");
    }

    private static void RemoveAllElements(DoublyLinkedList<string> list)
    {
        string element = ReadRequiredElement("Ingrese el dato a eliminar: ");
        int removedCount = list.RemoveAll(element);

        Console.WriteLine($"Se eliminaron {removedCount} ocurrencias.");
        Console.WriteLine("La operación elimina todas las ocurrencias encontradas del dato indicado.");
    }

    private static string ReadRequiredElement(string message)
    {
        string element;

        // Ask until the value is not empty.
        do
        {
            Console.Write(message);
            element = Console.ReadLine() ?? string.Empty;
            element = element.Trim();

            if (element == string.Empty)
            {
                Console.WriteLine("El dato no puede estar vacío.");
            }
        }
        while (element == string.Empty);

        return element;
    }
}
