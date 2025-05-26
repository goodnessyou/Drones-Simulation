using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Компонент для изменения скорость дрона NavMeshAgent
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class DroneSpeedChanger : MonoBehaviour
{
    [SerializeField] private DronesSpeedModel _speedModel = default;
    private NavMeshAgent _agent = default;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        SetDroneSpeed();
    }

    private void OnEnable() => _speedModel.onDronesSpeedChange += SetDroneSpeed;
    private void OnDisable() => _speedModel.onDronesSpeedChange -= SetDroneSpeed;
    private void SetDroneSpeed() => _agent.speed = _speedModel.Speed;
}
