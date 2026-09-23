using LinqTraining.Models;

namespace LinqTraining.Data;

public static class SampleData
{
    public static List<Book> GetBooks() => new()
    {
        new() { Id = 1,  Title = "Clean Code",                        Author = "Robert C. Martin",   Genre = "Technology",  Year = 2008, Price = 35.99m,  Stock = 12,  UnitsSold = 340 },
        new() { Id = 2,  Title = "The Pragmatic Programmer",          Author = "Andrew Hunt",         Genre = "Technology",  Year = 1999, Price = 32.50m,  Stock = 0,   UnitsSold = 215 },
        new() { Id = 3,  Title = "Design Patterns",                   Author = "Gang of Four",        Genre = "Technology",  Year = 1994, Price = 45.00m,  Stock = 5,   UnitsSold = 189 },
        new() { Id = 4,  Title = "Sapiens",                           Author = "Yuval Noah Harari",   Genre = "History",     Year = 2011, Price = 18.99m,  Stock = 40,  UnitsSold = 512 },
        new() { Id = 5,  Title = "Thinking, Fast and Slow",           Author = "Daniel Kahneman",     Genre = "Psychology",  Year = 2011, Price = 22.00m,  Stock = 25,  UnitsSold = 430 },
        new() { Id = 6,  Title = "Refactoring",                       Author = "Martin Fowler",       Genre = "Technology",  Year = 2018, Price = 38.99m,  Stock = 0,   UnitsSold = 175 },
        new() { Id = 7,  Title = "Atomic Habits",                     Author = "James Clear",         Genre = "Self-Help",   Year = 2018, Price = 16.99m,  Stock = 80,  UnitsSold = 780 },
        new() { Id = 8,  Title = "The 7 Habits of Highly Effective",  Author = "Stephen Covey",       Genre = "Self-Help",   Year = 1989, Price = 14.50m,  Stock = 55,  UnitsSold = 620 },
        new() { Id = 9,  Title = "Introduction to Algorithms",        Author = "Thomas H. Cormen",    Genre = "Technology",  Year = 2009, Price = 59.99m,  Stock = 8,   UnitsSold = 96  },
        new() { Id = 10, Title = "Homo Deus",                         Author = "Yuval Noah Harari",   Genre = "History",     Year = 2015, Price = 20.99m,  Stock = 0,   UnitsSold = 310 },
        new() { Id = 11, Title = "Deep Work",                         Author = "Cal Newport",         Genre = "Self-Help",   Year = 2016, Price = 17.99m,  Stock = 30,  UnitsSold = 395 },
        new() { Id = 12, Title = "The Psychology of Money",           Author = "Morgan Housel",       Genre = "Finance",     Year = 2020, Price = 19.99m,  Stock = 22,  UnitsSold = 460 },
        new() { Id = 13, Title = "Rich Dad Poor Dad",                 Author = "Robert Kiyosaki",     Genre = "Finance",     Year = 1997, Price = 12.99m,  Stock = 0,   UnitsSold = 700 },
        new() { Id = 14, Title = "C# in Depth",                       Author = "Jon Skeet",           Genre = "Technology",  Year = 2019, Price = 42.00m,  Stock = 7,   UnitsSold = 140 },
        new() { Id = 15, Title = "The Lean Startup",                  Author = "Eric Ries",           Genre = "Business",    Year = 2011, Price = 21.00m,  Stock = 18,  UnitsSold = 283 },
        new() { Id = 16, Title = "Zero to One",                       Author = "Peter Thiel",         Genre = "Business",    Year = 2014, Price = 18.50m,  Stock = 0,   UnitsSold = 320 },
        new() { Id = 17, Title = "Educated",                          Author = "Tara Westover",       Genre = "Biography",   Year = 2018, Price = 15.99m,  Stock = 14,  UnitsSold = 210 },
        new() { Id = 18, Title = "Influence",                         Author = "Robert Cialdini",     Genre = "Psychology",  Year = 1984, Price = 17.50m,  Stock = 33,  UnitsSold = 370 },
    };
}
