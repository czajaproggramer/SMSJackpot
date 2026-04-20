using SMSJackpot;

public class Contact
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public LeadStatus Status { get; set; }
    public string Name = string.Empty;
    public string BusinessName = string.Empty;
    public List<Response> ResponseList = new List<Response>();

    public Contact(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        Status = LeadStatus.NOT_CONTACTED;
    }

    private static bool ValidatePhoneNumber(string phoneNumber)
    {
        bool isValid = true;
        phoneNumber = phoneNumber.Replace(" ", "");
        if (phoneNumber.StartsWith('+'))
        {
            string countryCode = phoneNumber.Substring(1, 2);
            if (countryCode != "48")
            {
                throw new Exception($"Numer kierunkowy nie wskazuje na Polskę ({countryCode})");
            }

            phoneNumber = phoneNumber.Substring(3);
        }

        if (phoneNumber.Length != 9)
        {
            throw new Exception($"Nieprawidłowa długość numeru ({phoneNumber.Length})");
        }
        return isValid;
    }

    public static HashSet<Contact> GetLeadListFromFile(string path)
    {
        HashSet<Contact> leadList = new HashSet<Contact>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var phoneNumber = SanitizePhoneNumber(line);
            bool isValid = false;
            try
            {
                isValid = ValidatePhoneNumber(phoneNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            if (isValid)
            {
                leadList.Add(new Contact(phoneNumber));    
            }
        }

        return leadList;
    }

    private static string SanitizePhoneNumber(string rawPhoneNumber)
    {
        string sanitizedPhoneNumber = rawPhoneNumber.Replace(" ", "").Replace("-", "");
        return sanitizedPhoneNumber;
    }

    public override bool Equals(object? obj)
    {
        Contact toCompare = (Contact)obj;
        return this.PhoneNumber.Equals(toCompare.PhoneNumber);
    }

    public static List<Contact> GetAllWithStatus(List<Contact> list, LeadStatus lStatus)
    {
        return (from l in list where l.Status == lStatus select l).ToList();
    }
}