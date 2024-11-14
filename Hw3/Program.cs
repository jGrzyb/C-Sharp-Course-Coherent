MyQueue<int> queue = new();
Random rand = new();
for(int i=0; i<20; i++) 
{
    try 
    {
        if(rand.Next() % 3 != 0)
        {
            int value = rand.Next() % 20 + 1;
            Console.WriteLine("enqueue: " + value);
            queue.Enqueue(value);
        }
        else
        {
            Console.WriteLine("dequeue: " + queue.Dequeue());
        }
        Console.WriteLine(queue);
    }
    catch(Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
}
MyQueue<int> tailed = (MyQueue<int>)queue.Tail();
Console.WriteLine("old queue: " + queue);
Console.WriteLine("tail: " + tailed);