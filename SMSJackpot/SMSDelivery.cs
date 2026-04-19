namespace SMSJackpot;

public class SMSDelivery : IDeliveryMethod
{
    public void SendMessage(Contact contact, string template)
    {
        Console.WriteLine($"Wysłano SMS do {contact.PhoneNumber}");
    }
}