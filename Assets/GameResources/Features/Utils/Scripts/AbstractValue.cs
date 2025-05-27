using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Абстрактный класс значения в виде ScriptableObject
/// </summary>
abstract public class AbstractValue<T> : ScriptableObject
{
    public event Action onValueChanged = delegate { };
    
    public T Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(_value, value))
            {
                _value = value;
                onValueChanged.Invoke();
            }
        }
    }
   [SerializeField] private T _value = default;
}
