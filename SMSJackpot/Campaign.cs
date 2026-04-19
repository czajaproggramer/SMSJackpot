namespace SMSJackpot;
public class Campaign
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; }
    public String Template { get; set; } = string.Empty;
    public HashSet<Contact> Leads { get; set; }
    public LinkedList<ActionLog> ActionHistory { get; set; }

    public Campaign(string name)
    {
        Name = name;
        CreatedAt = DateTime.Now;
        Leads = new HashSet<Contact>();
        ActionHistory = new LinkedList<ActionLog>();
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