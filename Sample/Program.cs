namespace Sample
{
    internal class Program
    {
        private enum ShoppingStage
        {
            PlaceOrder,
            MakePayment,
            Deliver
        }

        static void Main(string[] args)
        {
            var builder = new Ordering<ShoppingStage>.Builder();

            builder
                .AndThen(ShoppingStage.PlaceOrder)
                .AndThen(ShoppingStage.MakePayment)
                .AndThen(ShoppingStage.Deliver);

            var ordering = builder.Build();

            // True
            CheckStage(ordering, ShoppingStage.PlaceOrder, ShoppingStage.MakePayment);
            // False
            CheckStage(ordering, ShoppingStage.MakePayment, ShoppingStage.PlaceOrder);

            // Cash on Delivery

            Console.WriteLine("Cash on Delivery");

            builder = new Ordering<ShoppingStage>.Builder();

            builder
                .AndThen(ShoppingStage.PlaceOrder)
                .AndThen(ShoppingStage.Deliver)
                .AndThen(ShoppingStage.MakePayment);

            ordering = builder.Build();
            
            // False
            CheckStage(ordering, ShoppingStage.PlaceOrder, ShoppingStage.MakePayment);
            // True
            CheckStage(ordering, ShoppingStage.Deliver, ShoppingStage.MakePayment);
        }

        private static void CheckStage<T>(Ordering<T> ordering, T from, T to)
        {
            Console.WriteLine($"{from} => {to}, IsOK : {ordering.IsOK(from, to)}");
        }
    }
}