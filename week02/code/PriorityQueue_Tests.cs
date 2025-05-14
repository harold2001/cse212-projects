using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue three items with distinct priorities, then dequeue until empty.
    // Expected Result: highest-priority item returned first, then next highest, etc.
    // Defect(s) Found: 
    //  - The search loop uses `for (int index = 1; index < _queue.Count - 1; …)`, so it never considers the last element in the list.  If the highest-priority item sits at the end, it’s ignored.
    //  - After finding the “highPriorityIndex,” the code returns its value but never removes it from `_queue`, so subsequent dequeues keep returning the same item.

    public void TestPriorityQueue_BasicPriorityOrder()
    {
        var q = new PriorityQueue();
        q.Enqueue("low", 1);
        q.Enqueue("med", 5);
        q.Enqueue("high", 10);

        Assert.AreEqual("high", q.Dequeue());
        Assert.AreEqual("med", q.Dequeue());
        Assert.AreEqual("low", q.Dequeue());
    }

    [TestMethod]
    // Scenario: enqueue items with equal max priority in FIFO order.
    // Expected Result: first enqueued among equals is dequeued first.
    // Defect(s) Found:
    //  - Same two bugs as above: the end-of-list never gets scanned, and there’s no `_queue.RemoveAt(...)` after dequeue.
    //  - Additionally, the comparison uses `>=`, which (if the loop bounds were fixed) would pick the *later* of two equal-priority items rather than preserving FIFO.  To honor FIFO on ties you need to use `>` instead.
    public void TestPriorityQueue_EqualPriorityFifo()
    {
        var q = new PriorityQueue();
        q.Enqueue("A", 10);
        q.Enqueue("B", 5);
        q.Enqueue("C", 10);

        Assert.AreEqual("A", q.Dequeue());
        Assert.AreEqual("C", q.Dequeue());
        Assert.AreEqual("B", q.Dequeue());
    }

    [TestMethod]
    // Scenario: dequeue on empty should throw InvalidOperationException.
    // Expected Result: exception.
    // Defect(s) Found:
    // - None. It correctly throws InvalidOperationException when `_queue.Count == 0`.
    public void TestPriorityQueue_EmptyThrows()
    {
        var q = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => q.Dequeue());
    }

}