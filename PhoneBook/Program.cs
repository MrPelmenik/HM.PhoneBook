// See https://aka.ms/new-console-template for more information


Phonebook phonebook = new Phonebook();
phonebook.AddPerson("Booba", 8800555);
phonebook.AddPerson("Loppa", 11111);
phonebook.AddPerson("Loppa", 11111);
phonebook.ShowAbonents();
phonebook.SearchByName("Loppa");
phonebook.SaveToTxt();
Console.ReadKey();

class Phonebook
{
    List<Abonent> abonents = new List<Abonent>();
    public Phonebook()
    {
        LoadFromTxt();
    }
    public void AddPerson(string name, int number)
    {
        if (CheckForOccupied(name, number))
            abonents.Add(new Abonent(name, number));
        else
            Console.WriteLine("Место занято");
    }
    void DeletePerson(int input)
    {
        abonents.RemoveAt(input);
    }
    bool CheckForOccupied(string name, int number)
    {
        foreach (Abonent ab in abonents)
            if (ab.name == name && ab.number == number)
                return false;
        return true;
    }
    void LoadFromTxt()
    {
        string path = "E:/Repos for VS/PhoneBook/PhoneBook/Book.txt";
        StreamReader reader = new StreamReader(path);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
           string name = line.Split(':').First();
           int number = int.Parse(line.Split(":").Last());
            AddPerson(name, number);
        }
        reader.Close();
    }
   public void SaveToTxt()
    {
        string path = "E:/Repos for VS/PhoneBook/PhoneBook/Book.txt";
        string text = string.Empty;
        StreamWriter writer = new StreamWriter(path);
        foreach (Abonent ab in abonents)
        {
            text = $"{ab.name}:{ab.number}";
                    writer.WriteLine(text);
        }
        writer.Close();
    }
    public void ShowAbonents() 
    {
        if (abonents.Count == 0)
        {
            Console.WriteLine("Book is empty");
            return;
        }
        foreach (Abonent ab in abonents) 
        {
            Console.WriteLine($"{ab.name}:{ab.number}");
        }
    }
    public void SearchByNumber(int input)
    {
        bool flag = false; 
        foreach (Abonent ab in abonents)
        {
            if (input == ab.number)
            {
                Console.WriteLine($"По запросу найден: {ab.name}:{ab.number}");
                flag = true;
            }
        }
        if (!flag)
            Console.WriteLine($"По запросу ничего не найдено");
    }
    public void SearchByName(string input)
    {
        bool flag = false;
        foreach (Abonent ab in abonents)
        {
            if (input == ab.name)
            {
                Console.WriteLine($"По запросу найден: {ab.name}:{ab.number}");
                flag = true;
            }
        }
        if (!flag)
            Console.WriteLine($"По запросу ничего не найдено");
    }
}

class Abonent
{
    public string name { get; }
    public int number { get; }
    public Abonent(string name, int number)
    {
        this.name = name;
        this.number = number;
    }
}

