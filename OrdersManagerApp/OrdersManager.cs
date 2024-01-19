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

                foreach (var record in lines)
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

            return true;
        }

        public Order GetMax()
        {
            decimal max = decimal.MinValue;
            Order maxRecord = null;

            foreach (Order order in orders)
            {
                decimal discountedTotalPrice = order.Quantity * order.UnitPrice * (1 - order.PercentageDiscount / 100);

                if (discountedTotalPrice > max)
                {
                    max = discountedTotalPrice;
                    maxRecord = order;
                }
            }

            return maxRecord;
        }

        public Order GetQuantityMax()
        {

            decimal max = decimal.MinValue;
            Order maxRecord = null;

            foreach (Order order in orders)
            {
                if (order.Quantity > max)
                {
                    max = order.Quantity;
                    maxRecord = order;
                }

            }

            return maxRecord;
        }

        public Order GetMaxDifference()
        {

            decimal maxDifference = decimal.MinValue;
            Order maxRecord = null;

            foreach (Order order in orders)
            {
                decimal totalWithoutDiscount = order.Quantity * order.UnitPrice;
                decimal totalWithDiscount = totalWithoutDiscount * (1 - order.PercentageDiscount / 100);
                decimal difference = totalWithoutDiscount - totalWithDiscount;

                if (difference > maxDifference)
                {
                    maxDifference = difference;
                    maxRecord = order;
                }
            }

            return maxRecord;
        }

    }
}
