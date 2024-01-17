namespace OrdersManagerApp
{
    internal class Order
    {
        private int id;
        private string article;
        private int quantity;
        private decimal unitPrice;
        private int percentageDiscount;
        private string buyer;

        public Order(int id, string article, int quantity, decimal unitPrice, int percentageDiscount, string buyer)
        {
            this.id = id;
            this.article = article;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
            this.percentageDiscount = percentageDiscount;
            this.buyer = buyer;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Article
        {
            get { return article; }
            set { article = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int PercentageDiscount
        {
            get { return percentageDiscount; }
            set { percentageDiscount = value; }
        }

        public string Buyer
        {
            get { return buyer; }
            set { buyer = value; }
        }

        public override string ToString()
        {
            return $"ID: {Id}, Article: {Article}, Quantity: {Quantity}, Unit Price: {UnitPrice}, Discount: {PercentageDiscount}%, Buyer: {Buyer}";
        }
    }
}
