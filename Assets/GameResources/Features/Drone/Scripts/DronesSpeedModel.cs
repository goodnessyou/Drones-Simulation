using System;
using UnityEngine;

/// <summary>
/// Модель скорости дронов
/// </summary>
[CreateAssetMenu(fileName = "New DronesSpeedModel", menuName = "DronesSimulation/Features/Drone/DronesSpeedModel")]
public class DronesSpeedModel : ScriptableObject
{
    public event Action onDronesSpeedChange = delegate { };
    public float Speed
    {
        get => _speed;
        set
        {
            if (_speed != value)
            {
                _speed = value;
                onDronesSpeedChange.Invoke();
            }
        }
    } 
    [SerializeField] private float _speed = 1;
}
