// See https://aka.ms/new-console-template for more information

// 3 Basic Arrays

int[] numArray;
numArray = new int[] {0,1,2,3,4,5,6,7,8,9};

string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

bool[] values = new bool[] {true, false, true, false, true, false, true, false, true, false,};

List<string> flavors = new List<string>();
flavors.Add("Rocky Road");
flavors.Add("Mint Chip");
flavors.Add("Vanilla");
flavors.Add("Chocolate");
flavors.Add("Cherry");
flavors.Add("Neopolitan");

Console.WriteLine(flavors.Count);
Console.WriteLine(flavors[2]);

flavors.RemoveAt(2);

Console.WriteLine(flavors.Count);

Random rand = new Random();

Dictionary<string,string> profile = new Dictionary<string,string>();
profile.Add("Tim",flavors[rand.Next(0,5)]);
profile.Add("Martin",flavors[rand.Next(0,5)]);
profile.Add("Nikki",flavors[rand.Next(0,5)]);
profile.Add("Sara",flavors[rand.Next(0,5)]);

foreach (var name in profile)
{
    Console.WriteLine(name.Key + " - " + name.Value);
}




