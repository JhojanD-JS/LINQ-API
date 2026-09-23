using LinqTraining.Data;
using LinqTraining.Models;
using System.Text.Json;

var books = SampleData.GetBooks();

Console.WriteLine("=== Query 1: Top 5 best-sellers per genre ===");
var query1 = books.GroupBy(b => b.Genre)
    .SelectMany(g => g.OrderByDescending(b => b.UnitsSold)
                      .Take(5)
                      .Select((b, index) => new
                      {
                          Genre = g.Key,
                          Rank = index + 1,
                          b.Title,
                          b.Author,
                          b.UnitsSold
                      }));
foreach (var b in query1)
    Console.WriteLine($"  [{b.Genre}] #{b.Rank} {b.Title} by {b.Author} — {b.UnitsSold} sold");


Console.WriteLine("\n=== Query 2: Authors with avg price > $25 ===");
var query2 = books.GroupBy(b => b.Author)
    .Select(g => new
    {
        Author = g.Key,
        BookCount = g.Count(),
        AveragePrice = g.Average(b => b.Price)
    })
    .Where(a => a.AveragePrice > 25)
    .OrderByDescending(a => a.AveragePrice);

foreach (var a in query2)
    Console.WriteLine($"  {a.Author,-20} — {a.BookCount} book(s)  — avg ${a.AveragePrice:F2}");

Console.WriteLine("\n=== Query 3: Out-of-stock books grouped by year ===");
var query3 = books.Where(b => b.Stock == 0)
    .GroupBy(b => b.Year)
    .Select(g => new
    {
        Year = g.Key,
        Count = g.Count(),
        Titles = g.Select(b => b.Title).ToList()
    })
    .OrderByDescending(g => g.Year);

foreach (var g in query3)
{
    Console.WriteLine($"  Year: {g.Year}  ({g.Count} books)");
    foreach (var title in g.Titles)
        Console.WriteLine($"    - {title}");
}

Console.WriteLine("\n=== Query 4: Search by partial title ===");
Console.Write("Enter search term: ");
var searchTerm = Console.ReadLine() ?? string.Empty;

var query4 = books
    .Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
    .Select(b => new { b.Title, b.Author, b.Price });

if (!query4.Any())
    Console.WriteLine("  No books found matching that search term.");
else
    foreach (var b in query4)
        Console.WriteLine($"  {b.Title,-30} — {b.Author,-20} — ${b.Price}");

Console.WriteLine("\n=== Query 5: Revenue summary per genre ===");
var query5 = books.GroupBy(b => b.Genre)
    .Select(g => new
    {
        Genre = g.Key,
        TitleCount = g.Count(),
        TotalRevenue = g.Sum(b => b.UnitsSold * b.Price)
    })
    .OrderByDescending(g => g.TotalRevenue);

foreach (var g in query5)
    Console.WriteLine($"  {g.Genre,-15} {g.TitleCount} titles  ${g.TotalRevenue:N2}");

Console.WriteLine("\n=== Author info from Open Library API ===");

var uniqueAuthors = books
    .Select(b => b.Author)
    .Distinct();

using var httpClient = new HttpClient();

foreach (var author in uniqueAuthors)
{
    try
    {
        var url = $"https://openlibrary.org/search/authors.json?q={Uri.EscapeDataString(author)}";
        var json = await httpClient.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var docs = doc.RootElement.GetProperty("docs");

        if (docs.GetArrayLength() == 0)
        {
            Console.WriteLine($"  {author,-20} — no data found on Open Library");
            continue;
        }

        var first = docs[0];
        var birthDate = first.TryGetProperty("birth_date", out var bd) ? bd.GetString() : null;
        var topWork = first.TryGetProperty("top_work", out var tw) ? tw.GetString() : null;

        Console.WriteLine($"  {author,-20} — born: {birthDate ?? "unknown"} — top work: {topWork ?? "unknown"}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  {author,-20} — error fetching data: {ex.Message}");
    }
}
