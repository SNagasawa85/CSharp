// See https://aka.ms/new-console-template for more information

List<object> newList = new List<object>();
newList.Add(7);
newList.Add(28);
newList.Add(-1);
newList.Add(true);
newList.Add("chair");

int sum = 0;

for (var idx = 0; idx < newList.Count; idx++){
    Console.WriteLine(newList[idx]);
    if(newList[idx] is int){
        int val = (int)newList[idx];
        sum = sum + val;
    }
}

Console.WriteLine(sum);
