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
    if(coin == 2){
        return "Tails";
    }
}



