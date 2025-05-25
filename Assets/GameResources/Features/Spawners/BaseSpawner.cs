using System;
using UnityEngine;

/// <summary>
/// Базовый спавнер префаба
/// </summary>
public class BaseSpawner : MonoBehaviour
{
    /// <summary>
    /// Событие спавна объекта
    /// </summary>
    public event Action onObjectSpawned =  delegate { };
        
    /// <summary>
    /// Префаб в спавнере
    /// </summary>
    public GameObject Prefab => prefab;

    /// <summary>
    /// Последний заспавненый объект
    /// </summary>
    public GameObject LastSpawnedObject => lastSpawnedObject;

    /// <summary>
    /// id спавнера
    /// </summary>
    public string IdSpawner => idSpawner;
        
    [SerializeField] protected GameObject prefab = default;
    [SerializeField] protected bool isAutoSpawn = default;
    [SerializeField] protected string idSpawner = string.Empty;
    protected GameObject lastSpawnedObject = default;

    protected virtual void Start()
    {
        if (isAutoSpawn)
        {
            Spawn();
        }
    }

        
    /// <summary>
    /// Выполняем спаун
    /// </summary>
    public virtual void Spawn() 
    {
        lastSpawnedObject = Instantiate(prefab, transform.position, Quaternion.identity);
        onObjectSpawned.Invoke();
    } 

    /// <summary>
    /// Выполняем спаун в конкретной точке
    /// </summary>
    /// <param name="spawnPoint"></param>
    public virtual void Spawn(Transform spawnPoint) 
    {
        lastSpawnedObject = Instantiate(prefab, spawnPoint);
        onObjectSpawned.Invoke();
    } 

    protected virtual void OnDestroy()
    {
        Delegate[] delegates = onObjectSpawned.GetInvocationList();

        if (delegates != null)
        {
            foreach (Delegate d in delegates)
            {
                onObjectSpawned -= (Action)d;
            }
        }
    }
}
