public static class QueueExtensions
{
    public static IQueue<T> Tail<T>(this IQueue<T> queue)
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        MyQueue<T> newQueue = new MyQueue<T>(queue);
        if(!newQueue.IsEmpty())
        {
            newQueue.Dequeue();
        }

        return newQueue;
    }
}