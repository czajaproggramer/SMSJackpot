namespace SMSJackpot;
public class Campaign
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; }
    public String Template { get; set; } = string.Empty;
    public HashSet<Contact> Leads { get; set; }
    public LinkedList<ActionLog> ActionHistory { get; set; }
    public IDeliveryMethod DeliveryMethod { get; }
    public IResponseCollector ResponseCollector { get; }

    public Campaign(string name, IDeliveryMethod deliveryMethod, IResponseCollector responseCollector)
    {
        Name = name;
        CreatedAt = DateTime.Now;
        Leads = new HashSet<Contact>();
        ActionHistory = new LinkedList<ActionLog>();
        DeliveryMethod = deliveryMethod;
        ResponseCollector = responseCollector;
    }

    public static Campaign CreateSMSCampaign(string name)
    {
        return new Campaign(name, new SMSDelivery(), new SMSResponseCollector());
    }

    public void GetCampaignInfo()
    {
        Console.WriteLine($"Kampania: {Name}, utworzona: {CreatedAt.ToShortDateString()}" +
                          $", zawiera {Leads.Count} kontaktów, wzorzec wiadomości: {Template}");
    }

    public void AddLog(ActionLog aL)
    {
        ActionHistory.AddLast(aL);
    }
}