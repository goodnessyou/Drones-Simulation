using System.Collections;
using UnityEngine;

/// <summary>
/// Цикличный спавнер префаба
/// </summary>
public class CycleSpawner : BaseSpawner
{
    /// <summary>
    /// Время между спавнами
    /// </summary>
    public float Time
    {
        get => time;
        set
        {
            if (time != value)
            {
                time = Mathf.Clamp(value, 1f, float.MaxValue);
            }
        }
    }

    [SerializeField, Min(0)] protected float time = 1.0f;

    protected override void Start()
    {
        if (isAutoSpawn)
        {
            StartCoroutine(CycleSpawnRoutine());
        }
    }

    protected IEnumerator CycleSpawnRoutine()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(time);
            Spawn();
        }
    }
}
