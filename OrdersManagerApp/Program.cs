using OrdersManagerApp;

string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string file = Path.Combine(projectDirectory, "File", "orders.csv");

OrdersManager ordersManager = new();

if (ordersManager.ReadFile(file))
{
    Console.WriteLine("Records con importo totale più alto:");
    foreach (var order in ordersManager.GetMax())
    {
        Console.WriteLine(order);
    }
    Console.WriteLine();

    Console.WriteLine("Records con quantità più alta:");
    foreach (var order in ordersManager.GetQuantityMax())
    {
        Console.WriteLine(order);
    }
    Console.WriteLine();

    Console.WriteLine("Records con maggior differenza tra totale senza sconto e totale con sconto:");
    foreach (var order in ordersManager.GetMaxDifference())
    {
        Console.WriteLine(order);
    }
    Console.WriteLine();
}