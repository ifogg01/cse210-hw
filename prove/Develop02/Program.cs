using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public JournalEntry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}\n{Prompt}\n{Response}";
    }

    public static JournalEntry FromFileFormat(string[] lines)
    {
        if (lines.Length < 3) return null; 
        DateTime date = DateTime.Parse(lines[0]);
        string prompt = lines[1];
        string response = string.Join("\n", lines, 2, lines.Length - 2); 
        return new JournalEntry(prompt, response, date);
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    private List<string> prompts = new List<string>
    {
        "How did I show kindness today?",
        "What am I most grateful for today?",
        "What was the best part of my day?",
        "Was there something simple that made my day a little bit better today?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "Can I be better tomorrow than I was today, if so how?"
    };

    private Random random = new Random();

    public void WriteEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;

        JournalEntry entry = new JournalEntry(prompt, response, date);
        entries.Add(entry);

        Console.WriteLine("Entry saved!\n");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.\n");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }

    public void SaveJournal()
    {
        Console.WriteLine("Enter a filename to save the journal (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                    writer.WriteLine("---"); 
                }
            }
            Console.WriteLine("Journal saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}\n");
        }
    }

    public void LoadJournal()
    {
        Console.WriteLine("Enter the filename to load the journal from (e.g., journal.txt): ");
        string filename = Console.ReadLine();

        try
        {
            if (File.Exists(filename))
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                List<string> entryLines = new List<string>();

                foreach (var line in lines)
                {
                    if (line == "---") 
                    {
                        var entry = JournalEntry.FromFileFormat(entryLines.ToArray());
                        if (entry != null) entries.Add(entry);
                        entryLines.Clear();
                    }
                    else
                    {
                        entryLines.Add(line);
                    }
                }

                Console.WriteLine("Journal loaded successfully!\n");
            }
            else
            {
                Console.WriteLine("File not found.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}\n");
        }
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Program
{
    static void Main()
    {
        DisplayWelcomeMessage();

        Journal journal = new Journal();
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("1. Write a new entry - from journal prompts");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save & date journal entries to file");
            Console.WriteLine("4. Load journal entries from file");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournal();
                    break;
                case "4":
                    journal.LoadJournal();
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.\n");
                    break;
            }
        }

        Console.WriteLine("Please come back and write more soon.");
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("This is a Journaling Program.");
        Console.WriteLine("You can write new entries, save and load them from a file, as well as review past entries.");
        Console.WriteLine("What would you like to do today?\n");
    }
}
