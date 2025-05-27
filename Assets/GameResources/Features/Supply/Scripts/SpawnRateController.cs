using UnityEngine;

/// <summary>
/// Контроллер спавнрейта для цикличного спавнера
/// </summary>
[RequireComponent(typeof(CycleSpawner))]
public class SpawnRateController : MonoBehaviour
{
    [SerializeField] private IntegerValue _integerValue = default;

    private CycleSpawner _cycleSpawner = default;

    private void Awake()
    {
        _cycleSpawner = GetComponent<CycleSpawner>();
        SetSpawnRate();
    }

    private void OnEnable() => _integerValue.onValueChanged += SetSpawnRate;
    private void OnDisable() => _integerValue.onValueChanged -= SetSpawnRate;
    private void SetSpawnRate() => _cycleSpawner.Time = _integerValue.Value;
}
