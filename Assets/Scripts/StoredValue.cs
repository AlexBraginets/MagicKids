using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZergRush.ReactiveCore;
[System.Serializable]
public class StoredValue<T>
{
    private Cell<T> cell;
    public event Action<T> callback;
    public T Value
    {
        get => cell.value;
        set =>cell.value = value;
    }

    public StoredValue(T value)
    {
        cell = new Cell<T>(value);
        cell.ListenUpdates(InvokeCallback);
    }

    private void InvokeCallback(T value)
    {
        callback?.Invoke(value);
    }
}
