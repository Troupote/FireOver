using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem<T> : MonoBehaviour
{
    private LinkedList<T> _items = new LinkedList<T>();

    // Ajouter un �l�ment � la queue
    public void Enqueue(T item)
    {
        _items.AddLast(item);
    }

    // Retirer un �l�ment de la queue
    public T Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La queue est vide.");
        }

        T value = _items.First.Value;
        _items.RemoveFirst();
        return value;
    }

    // Obtenir l'�l�ment en t�te de la queue sans le retirer
    public T Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La queue est vide.");
        }

        return _items.First.Value;
    }

    // V�rifier si la queue est vide
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    // Obtenir le nombre d'�l�ments dans la queue
    public int Count()
    {
        return _items.Count;
    }

    public QueueSystem<T> Clear()
    {
        _items.Clear();
        return this;
    }
}
