namespace SMSJackpot;

public class SMSResponseCollector : IResponseCollector
{
    private static List<Response> responses = new List<Response>()
    {
        new Response(new Contact("505388244"), "Nie, masz downa", DateTime.Now),
        new Response(new Contact("517512544"), "Dawaj strone", DateTime.Now),
        new Response(new Contact("783211023"), "Moze kupie moze nie", DateTime.Now),
    };
    public List<Response> GetAllResponses()
    {
        return (from r in responses select r).ToList();
    }

    public List<Response> GetAllResponsesFrom(DateTime start)
    {
        return (from r in responses where r.SendDate >= start select r).ToList();
    }

    public List<Response> GetAllResponsesBetween(DateTime start, DateTime end)
    {
        return (from r in responses where r.SendDate >= start && r.SendDate <= end select r).ToList();
    }
}