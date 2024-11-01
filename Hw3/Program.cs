MyQueue<int> queue = new(10);
Random rand = new();
for(int i=0; i<30; i++) 
{
    try 
    {
        if(rand.Next() % 3 != 0)
        {
            int value = rand.Next() % 20;
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