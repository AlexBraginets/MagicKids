using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Data
{
    public event Action OnChanged;
    protected void Changed() => OnChanged?.Invoke();
    public abstract void InitOnChangedCallbackChain();
}
