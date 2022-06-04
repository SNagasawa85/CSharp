// See https://aka.ms/new-console-template for more information

static void PrintNumbers()
{
    for(var i = 0; i<=255; i++){
        Console.WriteLine(i);
    }
}

static void PrintOdds()
{
    for(var i = 0; i<=255; i++){
        if(i%2 != 0){
        Console.WriteLine(i);
        }
    }    
}

static void PrintSum()
{
    int sum = 0;
    for(var i = 0; i<=255; i++){
        sum = sum + i;
        Console.WriteLine("New Number: " + i + "Sum: " + sum);
        }
}

static void LoopArray(int[] numbers)
{
    for(var i = 0; i < numbers.Length; i++){
        Console.WriteLine(i)
    }
}

static int FindMax(int[] numbers)
{
    int max = numbers[0];
    for(var i = 0; i < numbers.Length; i++){
        if(i < max){
            max = numbers[i];
        }
    }
    return max;
}

static void GetAverage(int[] numbers)
{
    int sum = 0;
    for(var i = 0; i < numbers.Length; i++){
        sum = sum + i;
    }
    int avg = sum/numbers.Length;
    Console.WriteLine(avg);
}

static int[] OddArray()
{
    int[] odds = new int[128];
    for(var i=0; i<=255; i++){
        if(i%2 != 0){
            odds.Add(i);
        }
    }
    return odds;
}

static int GreaterThanY(int[] numbers, int y)
{
    int total = 0;
    for(var i = 0; i<numbers.Length; i++){
        if(numbers[i] < y){
            total = total +1;
        }
    }
}