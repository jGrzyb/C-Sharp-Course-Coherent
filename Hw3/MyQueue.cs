using System.ComponentModel.DataAnnotations;

public class MyQueue<T> : IQueue<T> 
{
    private int front;
    private int rear = -1;
    private int itemCount = 0;
    private T[] array = new T[2];


    public MyQueue() {}

    public MyQueue(IQueue<T> queue)
    {
        MyQueue<T> tempQueue = new MyQueue<T>();
        while(!queue.IsEmpty()) 
        {
            T item = queue.Dequeue();
            tempQueue.Enqueue(item);
        }
        while(!tempQueue.IsEmpty())
        {
            T item = tempQueue.Dequeue();
            queue.Enqueue(item);
            Enqueue(item);
        }

    }

    public void Enqueue(T t)
    {
        if(itemCount >= array.Length)
        {
            T[] newArray = new T[array.Length * 2];
            T[] tempArray = front < rear ? array[front..(rear+1)] : array[front..].Concat(array[..(rear+1)]).ToArray();
            Array.Copy(tempArray, newArray, tempArray.Length);
            front = 0;
            rear = tempArray.Length - 1;
            array = newArray;
        }
        if(rear == array.Length - 1)
        {
            rear = -1;
        }
        rear++;
        array[rear] = t;
        itemCount++;
    }

    public T Dequeue()
    {
        if(IsEmpty()) 
        {
            throw new Exception("Queue is empty");
        }
        T data = array[front];
        front++;
        if(front == array.Length) 
        {
            front = 0;
        }
        itemCount--;
        return data;
    }

    public bool IsEmpty() 
    {
        return itemCount == 0;
    }

    public override string ToString()
    {
        return string.Join(", ", array) + "     front: " + front + " rear: " + rear + " size: " + itemCount;
    }
}