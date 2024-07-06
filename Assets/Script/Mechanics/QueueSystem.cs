using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    private LinkedList <QueueSystem> _items = new LinkedList<QueueSystem>();

    // Ajouter un élément à la queue
    public void Enqueue(QueueSystem item)
    {
        _items.AddLast(item);
    }

    // Retirer un élément de la queue
    public QueueSystem Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La queue est vide.");
        }

        QueueSystem value = _items.First.Value;
        _items.RemoveFirst();
        return value;
    }

    // Obtenir l'élément en tête de la queue sans le retirer
    public QueueSystem Peek()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("La queue est vide.");
        }

        return _items.First.Value;
    }

    // Vérifier si la queue est vide
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }

    // Obtenir le nombre d'éléments dans la queue
    public int Count()
    {
        return _items.Count;
    }

    public QueueSystem Clear()
    {
        _items.Clear();
        return this;
    }
}
