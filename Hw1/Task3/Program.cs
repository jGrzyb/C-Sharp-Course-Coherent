Console.Write("Put number of elements: ");
int count = int.Parse(Console.ReadLine() ?? "1");
int[] array = new int[count];
for(int i=0; i<count; i++) 
{
    Console.Write("Put your " + (i+1) + " value: ");
    array[i] = int.Parse(Console.ReadLine() ?? "1");
}

for(int i=0; i<array.Length; i++) 
{
    Console.Write(array[i] + " ");
}
Console.WriteLine();

int[] bufforArray = new int[count];
int bufforSize = 0;
for(int i=0; i<count; i++) 
{
    bool isAlreadyIn = false;
    for(int j=0; j<bufforSize; j++) 
    {
        if(bufforArray[j] == array[i]) 
        {
            isAlreadyIn= true;
        }
    }
    if(!isAlreadyIn) 
    {
        bufforArray[bufforSize] = array[i];
        bufforSize++;
    }
}
int[] finalArray = new int[bufforSize];
for(int i=0; i<bufforSize; i++) 
{
    finalArray[i] = bufforArray[i];
}

for(int i=0; i<finalArray.Length; i++) 
{
    Console.Write(finalArray[i] + " ");
}
Console.WriteLine();