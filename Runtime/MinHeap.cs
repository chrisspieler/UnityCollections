using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MinHeap<T> : IEnumerable<T> 
    where T : IComparable
{
    public int Count => _data.Count();
    public bool ContainsElement(T element) => _data.Contains(element);

    private List<T> _data = new List<T>();
    private int ParentIndex(int i) => i / 2;
    private int LeftChildIndex(int i) => i * 2;
    private int RightChildIndex(int i) => i * 2 + 1;
    private bool IsLeaf(int i) => i >= (_data.Count() / 2) && i < _data.Count();
    private bool LessThan(int left, int right) => _data[left].CompareTo(_data[right]) < 0;
    private bool GreaterThan(int left, int right) => _data[left].CompareTo(_data[right]) > 0;
    private void Swap(int firstIndex, int secondIndex)
    {
        T temp;
        temp = _data[firstIndex];
        _data[firstIndex] = _data[secondIndex];
        _data[secondIndex] = temp;
    }

    private void Bubble(int i)
    {
        if (!IsLeaf(i))
        {
            // If any children of "i" are greater than "i"...
            if (GreaterThan(i, LeftChildIndex(i)) || GreaterThan(i, RightChildIndex(i)))
            {
                // If the left child is the smallest...
                if (LessThan(LeftChildIndex(i), RightChildIndex(i)))
                {
                    // Bubble up the left child
                    Swap(i, LeftChildIndex(i));
                    Bubble(LeftChildIndex(i));
                }
                // Otherwise, do the same for the right child.
                else
                {
                    Swap(i, RightChildIndex(i));
                    Bubble(RightChildIndex(i));
                }
            }
        }
    }

    public void Push(T element)
    {
        _data.Add(element);
        int current = _data.Count() - 1;
        while (LessThan(current, ParentIndex(current)))
        {
            Swap(current, ParentIndex(current));
            current = ParentIndex(current);
        }
    }

    public T Pop()
    {
        var min = _data[0];
        _data[0] = _data[_data.Count - 1];
        _data.RemoveAt(_data.Count - 1);
        if (_data.Count > 1)
        {
            Bubble(0);
        }
        return min;
    }

    public T Peek() => _data[0];

    public IEnumerator<T> GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _data.GetEnumerator();
    }
}
