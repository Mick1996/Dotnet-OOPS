class Order
{   
    public void GetOrder()
    {
        Console.WriteLine("You have Placed an order for this product");
    }
}
class Payment 
{
    public void MakePayment()
    {
        Console.WriteLine("You have made Payment Successfuly");
    }
}
class Invoice
{
    public void GetInvoice()
    {
        Console.WriteLine("This is your Invoice");
    }
}
class PlaceOrder
{
    public void GetPlaceOrder()
    {
        Order order = new Order();
        Payment payment = new Payment();
        Invoice invoice = new Invoice();
        order.GetOrder();
        payment.MakePayment();
        invoice.GetInvoice();
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("You are placing an order");
        PlaceOrder placeorder = new PlaceOrder();
        placeorder.GetPlaceOrder();
    }
}




