Dictionary<string, ContatoList> contactList = new Dictionary<string, ContatoList>();

bool running = true;

while (running)
{
    Console.WriteLine("\n---- Contact Manager ----");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Remove Contact");
    Console.WriteLine("3. Search Contact");
    Console.WriteLine("4. List All Contact");
    Console.WriteLine("5. Update Contact");
    Console.WriteLine("6. Exit Application");
    Console.WriteLine("Choose an Option:  ");

    string optionToChoose = Console.ReadLine()!;

    switch (optionToChoose)
    {
        case "1":
            AddContact(contactList);
            break;

        case "2":
            RemoveContact(contactList);
            break;

        case "3":
            SearchContact(contactList);
            break;

        case "4":
            ListAllContacts(contactList);
            break;

        case "5":
            UpdateContact(contactList);
            break;

        case "6":
            running = false;
            Console.WriteLine("Exiting.....");
            break;

        default:
            Console.WriteLine("You entered an Invalid Option! Pleas try again....");
            break;
    }
}

static void AddContact(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter your name: ");
    string name = Console.ReadLine()!;

    if (contactList.ContainsKey(name))
    {
        Console.WriteLine("Contact Already Exists! ");
        return;
    }

    Console.WriteLine("Enter your Phone number: ");
    string phonenumber = Console.ReadLine()!;

    Console.WriteLine("Enter your Email: ");
    string email = Console.ReadLine()!;

    contactList[name] = new ContatoList(name, phonenumber, email);
    Console.WriteLine("Contact added successfully!");
}

static void RemoveContact(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter the name of the contact to be removed: ");
    string name = Console.ReadLine()!;

    if (contactList.Remove(name))
    {
        Console.WriteLine("Contact Removed successfully");
    }
    else
    {
        Console.WriteLine("Contact not found!");
    }
}

static void SearchContact(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter the name of the contact you want to search for: ");
    string name = Console.ReadLine()!;

    if (contactList.TryGetValue(name, out ContatoList? contact))
    {
        Console.WriteLine(contact);
    }
    else
    {
        Console.WriteLine("Contact not found!");
    }
}

static void ListAllContacts(Dictionary<string, ContatoList> contactList)
{
    if (contactList.Count == 0)
    {
        Console.WriteLine("No Contacts found!");
    }
    else
    {
        Console.WriteLine("\n---  Contact List ---");
        foreach (var contact in contactList.Values)
        {
            Console.WriteLine(contact);
        }
    }
}
static void UpdateContact(Dictionary<string, ContatoList> contactList)
{
    Console.WriteLine("Enter the name of the contact to be updated: ");
    string name = Console.ReadLine()!;

    if (contactList.TryGetValue(name, out ContatoList? existContact))
    {
        Console.WriteLine("Enter your new phone number");
        string phonenumber = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(phonenumber))
        {
            phonenumber = existContact.PhoneNumber;
        }

        Console.WriteLine("Enter your new Email: ");
        string email = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(email))
        {
            email = existContact.Email;
        }



        contactList[name] = new ContatoList(name, phonenumber, email!);
        Console.WriteLine("Contact updated successfully!");
    }
    else
    {
        Console.WriteLine("Cannot update contact wey no exist");
        return;
    }
}


class ContatoList
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ContatoList(string name, string phonenumber, string email)
    {
        Name = name;
        PhoneNumber = phonenumber;
        Email = email;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Telephone: {PhoneNumber}, Email: {Email}";
    }
}