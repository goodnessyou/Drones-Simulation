using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер спавнера дронов фракции
/// </summary>
public class DroneSpawnerController : MonoBehaviour
{
    [SerializeField] private IntegerValue _dronesCount = default;
    [SerializeField] private FractionData _fractionData = default;
    [SerializeField] private PoolSpawner _dronesSpawner = default;
    [SerializeField] private List<GameObject> _activeDrones = new List<GameObject>();

    private DroneBehavior _drone = default;

    private void Start()
    {
        for (int i = 0; i < _dronesCount.Value; i++)
        {
            SpawnDrone();
        }
    }

    private void OnEnable()
    {
        _dronesSpawner.onPoolObjectSpawned += SetupDrone;
        _dronesCount.onValueChanged += OnDronesCountChange;
    }

    private void OnDisable()
    {
        _dronesSpawner.onPoolObjectSpawned -= SetupDrone;
        _dronesCount.onValueChanged -= OnDronesCountChange;
    }

    private void OnDronesCountChange()
    {
        if (_dronesCount.Value > _activeDrones.Count)
        {
            while (_activeDrones.Count != _dronesCount.Value)
            {
                SpawnDrone();
            }
        }
        else
        {
            while (_activeDrones.Count != _dronesCount.Value)
            {
                _activeDrones[_activeDrones.Count - 1].gameObject.SetActive(false);
                _activeDrones.RemoveAt(_activeDrones.Count - 1);
            }
        }
    }

    private void SpawnDrone() => _dronesSpawner.Spawn();
    
    private void SetupDrone()
    {
        if (_dronesSpawner.LastSpawnedObject.TryGetComponent<DroneBehavior>(out _drone))
        {
            _drone.Fraction = _fractionData;
            _drone.GetComponent<FractionMaterialView>().FractionData = _fractionData;
            _drone.SetUp();
            _activeDrones.Add(_drone.gameObject);
        }
    }
}
