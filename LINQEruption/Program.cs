// See https://aka.ms/new-console-template for more information

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
Execute Assignment Tasks here!

IEnumerable<Eruption> chileEruption = eruptions.Where(e => e.Location == "Chile");
PrintEach(chileEruption, "Eruptions in Chile");

List<Eruption> hawaiinErupt = eruptions.Where(h => h.Location == "Hawaiian Is").ToList();
PrintEach(hawaiinErupt);
if(hawaiinErupt == null)
{
    Console.WriteLine("No Hawaiin Eruptions");
}
else if(hawaiinErupt.Count() == 1)
{
    PrintEach(hawaiinErupt, "Hawaiin Eruption:");
}
else if (hawaiinErupt.Count() > 1)
{
    Console.WriteLine("Hawaiin Eruption:" + hawaiinErupt[0]);
}

IEnumerable<Eruption> newZealand = eruptions.Where(z => z.Location == "New Zealand");
List<Eruption> result = new List<Eruption>();
foreach(Eruption one in newZealand)
{
    if(one.Year > 1900)
    {
        result.Add(one);
    }
}
PrintEach(result, "New Zealand after 1900:");

IEnumerable<Eruption> over2k = eruptions.Where(h => h.ElevationInMeters > 2000);
PrintEach(over2k, "these are very high");

IEnumerable<Eruption> volcs = eruptions.Where(v => v.Volcano.StartsWith("Z"));
PrintEach(volcs, volcs.Count().ToString());

IEnumerable<Eruption> all = eruptions.Where(a => a.ElevationInMeters > 0 );
List<int> hieghts = new List<int>();
foreach(Eruption one in all)
{
    hieghts.Add(one.ElevationInMeters);
}
int newmax = hieghts.Max();
Console.WriteLine(newmax);

IEnumerable<Eruption> tallest = eruptions.Where(v => v.ElevationInMeters == newmax);
PrintEach(tallest);

IEnumerable<Eruption> alpha = eruptions.OrderBy(n => n.Volcano);
PrintEach(alpha);

IEnumerable<Eruption> pre1k = eruptions.Where(y => y.Year < 1000).OrderBy(n => n.Volcano);
PrintEach(pre1k);


IEnumerable<Eruption> pre1k1 = eruptions.Where(y => y.Year < 1000).OrderBy(n => n.Volcano);
List<string> names = new List<string>();
foreach(Eruption one in pre1k1)
{
    names.Add(one.Volcano);
}
foreach(string name in names)
{
    Console.WriteLine(name);
}

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

