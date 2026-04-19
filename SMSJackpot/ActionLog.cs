namespace SMSJackpot;
public class ActionLog
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PerformedAt { get; }

    public ActionLog(string name)
    {
        Name = name;
        Description = string.Empty;
        PerformedAt = DateTime.Now;
    }
    public ActionLog(string name, string description)
    {
        Name = name;
        Description = description;
        PerformedAt = DateTime.Now;
    }
}