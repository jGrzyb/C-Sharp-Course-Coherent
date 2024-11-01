public interface IQueue<T>
{
    public void Enqueue(T t);
    public T Dequeue();
    public T Peek();
    public bool IsFull();
    public bool IsEmpty();
    public int GetSize();
}

public static class QueueExtensions
{
    public static IQueue<T> Tail<T>(this IQueue<T> queue)
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        IQueue<T> newQueue = new MyQueue<T>(queue.GetSize());
        queue.Dequeue();

        while (!queue.IsEmpty())
        {
            newQueue.Enqueue(queue.Dequeue());
        }

        return newQueue;
    }
}