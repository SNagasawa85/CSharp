// See https://aka.ms/new-console-template for more information
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

for (int i = 1; i <= 100; i++)
{
    if ( i%15 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    if ( i%3 == 0 && i%5 != 0)
    {
        Console.WriteLine("Fizz");
    }
    if ( i%5 == 0 && i%3 !=0)
    {
        Console.WriteLine("Buzz");
    }
}





