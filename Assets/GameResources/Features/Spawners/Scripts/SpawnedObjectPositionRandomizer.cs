using UnityEngine;

/// <summary>
/// Рандомизация позиции заспавненного объекта спавнером с пулом
/// </summary>
[RequireComponent(typeof(PoolSpawner))]
public class SpawnedObjectPositionRandomizer : MonoBehaviour
{
    [SerializeField, Tooltip("Радиус для случайного размещения объекта"), Min(1f)]
    private float _randomizeRadius = 1f;

    private PoolSpawner _poolSpawner = default;

    private void Awake() => _poolSpawner = GetComponent<PoolSpawner>();
    private void OnEnable() => _poolSpawner.onPoolObjectSpawned += RandomizeObjectPosition;
    private void OnDisable() => _poolSpawner.onPoolObjectSpawned -= RandomizeObjectPosition;

    private void RandomizeObjectPosition()
    {
        Vector3 basePosition = _poolSpawner.transform.position;

        Vector2 randomOffset = Random.insideUnitCircle * _randomizeRadius;

        Vector3 randomizedPosition = new Vector3(
            basePosition.x + randomOffset.x,
            basePosition.y, 
            basePosition.z + randomOffset.y
        );

        _poolSpawner.LastSpawnedObject.transform.position = randomizedPosition;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _randomizeRadius);
    }
}
