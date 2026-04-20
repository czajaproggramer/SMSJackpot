namespace SMSJackpot;
public class Postman
{
    private Campaign Camp { get;}

    public Postman(Campaign camp)
    {
        Camp = camp;
    }

    public void SendInitialMessageToAllUncontactedLeads()
    {
        List<Contact> uncontactedLeads = Contact.GetAllWithStatus(Camp.Leads.ToList(), LeadStatus.NOT_CONTACTED);
        foreach (var lead in uncontactedLeads)
        {
            Camp.DeliveryMethod.SendMessage(lead, Camp.Template);
            lead.Status = LeadStatus.NOT_RESPONDED;
        }

        ActionLog sendActionLog = new ActionLog("Wysyłka początkowej wiadomości do wszystkich nietkniętych leadów");
        Camp.AddLog(sendActionLog);
    }
    public void SendBaseFollowup()
    {
        List<Contact> unresponsiveLeads = Contact.GetAllWithStatus(Camp.Leads.ToList(), LeadStatus.NOT_RESPONDED);
        foreach (var lead in unresponsiveLeads)
        {
            Camp.DeliveryMethod.SendMessage(lead, "Dzien dobry, przypominam sie");
        }

        ActionLog sendActionLog = new ActionLog("Wysyłka followupu do kazdego kontaktu, któ®y nie odpowiedział" +
                                                "na pierwszą wiadomość");
        Camp.AddLog(sendActionLog);
    }

    public void FetchNewResponses()
    {
        DateTime lastFetchDate = (from l in Camp.ActionHistory where l.Name == "DataFetch"
            select l.PerformedAt).Last();
        var newResponses = Camp.ResponseCollector.GetAllResponsesFrom(lastFetchDate);
        Camp.AddLog(new ActionLog("DataFetch"));
    }
}