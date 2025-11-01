using System;
using System.Collections.Generic;

namespace UserApp;

class Program
{
    static List<User> users = new List<User>();
    static int nextId = 1;
    //start
    static void Main(string[] args)
    {
        Console.WriteLine("=== Simple User Management ===");

        while (true)
        {
            ShowMenu();
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllUsers();
                    break;
                case "2":
                    CreateUser();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n1. Show all users");
        Console.WriteLine("2. Create new user");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    static void ShowAllUsers()
    {
        Console.WriteLine("\n--- All Users ---");
        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
            return;
        }

        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
        }
    }

    static void CreateUser()
    {
        Console.Write("Enter user name: ");
        var name = Console.ReadLine();

        Console.Write("Enter user email: ");
        var email = Console.ReadLine();

        var user = new User
        {
            Id = nextId++,
            Name = name,
            Email = email
        };

        users.Add(user);
        Console.WriteLine("User created successfully!");
    }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}