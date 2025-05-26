using System;
using UnityEngine;

/// <summary>
/// Булевое значение в виде ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "New BoolValue", menuName = "DronesSimulation/Features/Drone/BoolValue")]
public class BoolValue : ScriptableObject
{
    public event Action onValueChanged = delegate { };

    public bool Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                onValueChanged.Invoke();
            }
        }
    }
   [SerializeField] private bool _value = false;
}
