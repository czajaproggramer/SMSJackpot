namespace SMSJackpot;

public class Response
{
    public Contact Sender { get; }
    public String Message { get; }
    public DateTime SendDate { get; }
    public ResponseStatus StatusOfResponse {get;}

    public Response(Contact sender, string message, DateTime dateTime, ResponseStatus rs)
    {
        Sender = sender;
        Message = message;
        SendDate = dateTime;
        StatusOfResponse = rs;
    }
}