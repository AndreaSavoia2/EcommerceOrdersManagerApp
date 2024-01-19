namespace OrdersManagerApp
{
    internal class OrdersManager
    {
        List<Order> orders = new List<Order>();

        public bool ReadFile(String file)
        {
            try
            {

                string[] lines = File.ReadAllLines(file);

                foreach (string record in lines)
                {
                    string[] fields = record.Split(',');

                    int id = int.Parse(fields[0]);
                    string article = fields[1];
                    int quantity = int.Parse(fields[2]);
                    decimal unitPrice = decimal.Parse(fields[3]);
                    decimal percentageDiscount = decimal.Parse(fields[4]);
                    string buyer = fields[5];

                    orders.Add(new Order(id, article, quantity, unitPrice, percentageDiscount, buyer));
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Il file .csv non è stato trovato ERROR:{e}\n");
                return false;
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"La dyrectory non è stata trovata ERROR:{e}\n");
                return false;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Errore nella formattazione dei dati ERROR: {e}\n");
                return false;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Errore indice fuori intervallo ERROR: {e}\n");
                return false;
            }

            return true;
        }

        public List<Order> GetMax()
        {
            decimal max = decimal.MinValue;
            List<Order> maxRecords = new List<Order>();

            foreach (Order order in orders)
            {
                decimal discountedTotalPrice = order.Quantity * order.UnitPrice * (1 - order.PercentageDiscount / 100);

                if (discountedTotalPrice > max)
                {
                    max = discountedTotalPrice;
                    maxRecords.Clear();
                    maxRecords.Add(order);
                }
                else if (order.Quantity == max)
                {
                    maxRecords.Add(order);
                }
            }

            return maxRecords;
        }

        public List<Order> GetQuantityMax()
        {
            decimal max = decimal.MinValue;
            List<Order> maxRecords = new List<Order>();

            foreach (Order order in orders)
            {
                if (order.Quantity > max)
                {
                    max = order.Quantity;
                    maxRecords.Clear();
                    maxRecords.Add(order);
                }
                else if (order.Quantity == max)
                {
                    maxRecords.Add(order);
                }
            }

            return maxRecords;
        }

        public List<Order> GetMaxDifference()
        {

            decimal max = decimal.MinValue;
            List<Order> maxRecords = new List<Order>();

            foreach (Order order in orders)
            {
                decimal totalWithoutDiscount = order.Quantity * order.UnitPrice;
                decimal totalWithDiscount = totalWithoutDiscount * (1 - order.PercentageDiscount / 100);
                decimal difference = totalWithoutDiscount - totalWithDiscount;

                if (difference > max)
                {
                    max = difference;
                    maxRecords.Clear();
                    maxRecords.Add(order);
                }
                else if (order.Quantity == max)
                {
                    maxRecords.Add(order);
                }
            }

            return maxRecords;
        }

    }
}
