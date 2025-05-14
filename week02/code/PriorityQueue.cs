using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    /// <summary>
    /// Remove and return the value with the highest priority.  If multiple
    /// items share the highest priority, the one enqueued earliest is removed.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Find the index of the item with the highest priority (earliest on ties)
        int highPriorityIndex = 0;
        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = i;
        }

        // Remove the item and return its value
        var item = _queue[highPriorityIndex];
        _queue.RemoveAt(highPriorityIndex);
        return item.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
