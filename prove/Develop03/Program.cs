using System;
using System.Collections.Generic;

class Reference
{
    public string Book { get; }
    public string Chapter { get; }
    public string Verses { get; }

    public Reference(string book, string chapter, string verses)
    {
        Book = book;
        Chapter = chapter;
        Verses = verses;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{Verses}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "______" : Text;
    }
}

class ScripturePicker
{
    private Dictionary<int, List<(Reference, string)>> scriptures; 
    private Random random; 
    private List<Word> words; 
    private Reference reference; 

    public ScripturePicker()
    {
        random = new Random();
        scriptures = new Dictionary<int, List<(Reference, string)>>
        {
            { 1, new List<(Reference, string)>
                {
                    (new Reference("Moses", "1", "39"), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
                    (new Reference("Moses", "7", "18"), "And the Lord called his people Zion, because they were of one heart and one mind, and dwelt in righteousness; and there was no poor among them."),
                    (new Reference("Abraham", "3", "22–23"), "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; ...")
                }
            },
            { 2, new List<(Reference, string)>
                {
                    (new Reference("Proverbs", "3", "5–6"), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                    (new Reference("Isaiah", "1", "18"), "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, they shall be as white as snow; though they be red like crimson, they shall be as wool."),
                    (new Reference("Jeremiah", "1", "4–5"), "Then the word of the Lord came unto me, saying, Before I formed thee in the belly I knew thee; ...")
                }
            },
            { 3, new List<(Reference, string)>
                {
                    (new Reference("Matthew", "22", "36–39"), "Master, which is the great commandment in the law? Jesus said unto him, Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind."),
                    (new Reference("John", "3", "16"), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                    (new Reference("James", "2", "17–18"), "Even so faith, if it hath not works, is dead, being alone.")
                }
            },
            { 4, new List<(Reference, string)>
                {
                    (new Reference("2 Nephi", "32", "3"), "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ."),
                    (new Reference("Mosiah", "2", "17"), "And behold, I tell you these things that ye may learn wisdom; ..."),
                    (new Reference("Moroni", "10", "4–5"), "And when ye shall receive these things, I would exhort you that ye would ask God, ...")
                }
            },
            { 5, new List<(Reference, string)>
                {
                    (new Reference("D&C", "6", "36"), "Look unto me in every thought; doubt not, fear not."),
                    (new Reference("D&C", "18", "15–16"), "And if it so be that you should labor all your days in crying repentance unto this people, ..."),
                    (new Reference("D&C", "121", "36, 41–42"), "That the rights of the priesthood are inseparably connected with the powers of heaven, ...")
                }
            }
        };
    }

    private void PickRandomScripture(int choice)
    {
        var selectedScriptures = scriptures[choice];
        var randomIndex = random.Next(selectedScriptures.Count);
        (reference, string scriptureText) = selectedScriptures[randomIndex];

        words = new List<Word>();
        foreach (var wordText in scriptureText.Split(' '))
        {
            words.Add(new Word(wordText));
        }
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("A scripture will randomly generate from one of the Standard Works. Please choose 1-5:");
            Console.WriteLine("1. Pearl of Great Price");
            Console.WriteLine("2. Old Testament");
            Console.WriteLine("3. New Testament");
            Console.WriteLine("4. Book of Mormon");
            Console.WriteLine("5. Doctrine and Covenants");

            int choice = GetValidInput();
            Console.Clear();
            PickRandomScripture(choice);

            DisplayScripture();

            while (true)
            {
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Environment.Exit(0);
                }

                Console.Clear();

                HideRandomWords();

                DisplayScripture();

                if (AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("Great job, try memorizing another scripture.");

                    Console.WriteLine("Press Enter to restart the program...");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }

    private int GetValidInput()
    {
        int choice;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5:");
            }
        }
    }

    private void DisplayScripture()
    {
        Console.WriteLine(reference.ToString());
        Console.WriteLine(string.Join(" ", words));
    }

    private void HideRandomWords()
    {
        int wordsToHide = Math.Min(3, words.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            int index;
            do
            {
                index = random.Next(words.Count);
            } while (words[index].IsHidden);

            words[index].Hide();
        }
    }

    private bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        ScripturePicker picker = new ScripturePicker();
        picker.Start();
    }
}
