// See https://aka.ms/new-console-template for more information

static int[] RandomArray()
{
    Random rand = new Random();
    int[] NumArray = new int[10];
    for(var i = 0; i < 10; i++){
        NumArray[i] = rand.Next(5,25);
    }
    int min = NumArray[0];
    int max = NumArray[0];
    int sum = 0;
    for(var i = 0; i < 10; i++){
        if( NumArray[i] > max){
            max = NumArray[i];
        }
        if( NumArray[i] < min){
            min = NumArray[i];
        }
        sum = sum + NumArray[i];
    }
    Console.WriteLine(min);
    Console.WriteLine(max);
    Console.WriteLine(sum);
    return NumArray;
}


static string TossCoin()
{
    Console.WriteLine("Tossing a Coin!");
    Random rand = new Random();
    int coin = rand.Next(1,2);
    if(coin == 1){
        return "Heads";
    }
    else{
        return "Tails";
    }
}


static List<string> Names()
{
    List<string> People = new List<string>
    {
        "Todd",
        "Tiffany",
        "Geneva",
        "Sydney"
    };
    List<string> LongNames = new List<string>();
    foreach(string name in People)
    {
        if(name.Length > 5)
        {
            LongNames.Add(name);
        }
    }
    return LongNames;
}

static string PrintEach(List<string> value)
{
    string result = "";
    foreach(string one in value)
    {
        Console.Write(one + " ");
    }
    return result;
}

Console.WriteLine(Names());
Console.WriteLine(RandomArray());
Console.WriteLine(TossCoin());
PrintEach(Names());