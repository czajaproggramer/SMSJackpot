namespace SMSJackpot;

public interface IDeliveryMethod
{
    public void SendMessage(Contact contact, String template);
}