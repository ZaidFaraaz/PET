using System;

class Pet
{
    public string PetType { get; }
    public string Name { get; }
    private int hunger;
    private int happiness;
    private int health;

    public Pet(string petType, string name)
    {
        PetType = petType;
        Name = name;
        hunger = 5;
        happiness = 5;
        health = 5;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"\n{Name} the {PetType}");
        Console.WriteLine($"Hunger: {hunger}/10 | Happiness: {happiness}/10 | Health: {health}/10");
    }

    public void Feed()
    {
        hunger = Math.Max(1, hunger - 2);
        health = Math.Min(10, health + 1);
        DisplayStats();
        Console.WriteLine($"{Name} is fed and feeling better.");
    }

    public void Play()
    {
        if (hunger >= 4)
        {
            happiness = Math.Min(10, happiness + 2);
            hunger = Math.Max(1, hunger + 1);
            DisplayStats();
            Console.WriteLine($"{Name} is currently playing and enjoying the time.");
        }
        else
        {
            Console.WriteLine($"{Name} has refused to play because it's too hungry. Please feed {Name} first.");
        }
    }

    public void Rest()
    {
        health = Math.Min(10, health + 2);
        happiness = Math.Max(1, happiness - 1);
        DisplayStats();
        Console.WriteLine($"{Name} is resting and recovering health.");
    }

    public void TimePasses()
    {
        hunger = Math.Min(10, hunger + 1);
        happiness = Math.Max(1, happiness - 1);
        DisplayStats();
        Console.WriteLine("Time passes...");

        // Check for consequences of neglect
        if (hunger >= 9)
        {
            health = Math.Max(1, health - 2);
            Console.WriteLine($"{Name} is too hungry and losing health!");
        }
        if (happiness <= 1)
        {
            health = Math.Max(1, health - 1);
            Console.WriteLine($"{Name} is very unhappy and health is deteriorating.");
        }
    }

    public void CheckStatus()
    {
        if (hunger <= 2 || happiness <= 2 || health <= 2)
        {
            Console.WriteLine("Warning: Your pet is not doing well. Please take care.");
        }
        else if (hunger >= 8 || happiness >= 8 || health >= 8)
        {
            Console.WriteLine("Warning: Your pet is very satisfied. Watch out for overfeeding.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Pet Care Console App!");
        Console.Write("Choose a pet type (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();
        Console.Write("Give your pet a name: ");
        string petName = Console.ReadLine();

        Pet userPet = new Pet(petType, petName);

        Console.WriteLine($"\nWelcome, {userPet.Name} the {userPet.PetType}!");

        while (true)
        {
            userPet.CheckStatus();

            Console.Write("\nChoose an action (feed, play, rest, exit): ");
            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "feed":
                    userPet.Feed();
                    break;
                case "play":
                    userPet.Play();
                    break;
                case "rest":
                    userPet.Rest();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the Pet Care Console App. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid action. Please choose from feed, play, rest, or exit.");
                    break;
            }

            userPet.TimePasses();
        }
    }
}
