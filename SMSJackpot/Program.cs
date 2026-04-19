using SMSJackpot;

HashSet<Contact> leads1 = Contact.GetLeadListFromFile("./../../../telefony.txt");
String template1 = "Dzien dobry,\nOstatnio szukalem stolarza na Google Maps i zauwazylem, ze" +
                   " nie ma Pan swojej strony internetowej. Moze zabrzmi to dziwnie, ale stworzylem dla " +
                   "Pana jej piekny projekt graficzny, czy chcialby Pan go zobaczyc?\nPozdrawiam,\n" +
                   "Borys Czajkowski\n(nie zainteresowany? odpowiedz \"nie\")\n";
foreach (var lead in leads1)
{
    Console.WriteLine(lead.PhoneNumber);
}
Campaign camp1 = new Campaign("Stolarze - Warszawa");
camp1.Leads = leads1;
camp1.Template = template1;

Postman postman = new Postman(camp1);
IDeliveryMethod szybkiSMS = new SMSDelivery();
postman.SendInitialMessageToAllUncontactedLeads(szybkiSMS);
