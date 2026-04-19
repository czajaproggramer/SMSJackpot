namespace SMSJackpot;

public interface IResponseCollector
{
    public List<Response> GetAllResponses();
    public List<Response> GetAllResponsesFrom(DateTime start);
    public List<Response> GetAllResponsesBetween(DateTime start, DateTime end);
}