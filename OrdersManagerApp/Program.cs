using OrdersManagerApp;

string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string file = Path.Combine(projectDirectory, "File", "orders.csv");

OrdersManager ordersManager = new();

if (ordersManager.ReadFile(file))
{
    Console.WriteLine($"Record con importo totale più alto:\n {ordersManager.GetMax()}\n");

    Console.WriteLine($"Record con quantità più alta:\n {ordersManager.GetQuantityMax()}\n");

    Console.WriteLine($"Record con maggior differenza tra totale senza sconto e totale con sconto:\n {ordersManager.GetMaxDifference()}\n");
}