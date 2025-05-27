using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул спаунер
/// </summary>
public class PoolSpawner : CycleSpawner
{
    /// <summary>
    /// Событие изменения количества объектов в пуле
    /// </summary>
    public event Action onPoolObjectSpawned = delegate { };

    [SerializeField] protected List<ItemPool> items = new List<ItemPool>();
    [SerializeField, Min(0)] protected int countPrewarm = 3;
    protected ItemPool tempItem = default;

    /// <summary>
    /// Спаун с помощью пула
    /// </summary>
    [ContextMenu("Test Spawn")]
    public override void Spawn()
    {
        if (items.Count <= 0)
        {
            base.Spawn();
            ItemPool itemPool = LastSpawnedObject.GetComponent<ItemPool>();
            itemPool.Init(this);
        }
        else
        {
            items[items.Count - 1].gameObject.ResetRotation();
            items[items.Count - 1].gameObject.ResetLocalPosition(gameObject);
            items[items.Count - 1].gameObject.SetActive(true);
            lastSpawnedObject = items[items.Count - 1].gameObject;
            items.RemoveAt(items.Count - 1);

        }
        onPoolObjectSpawned.Invoke();
    }

    /// <summary>
    /// Вернуть в пул
    /// </summary>
    /// <param name="itemPool"></param>
    public void ReturnToPool(ItemPool itemPool)
    {
        items.Add(itemPool);
        StartCoroutine(SetParentDelayed(itemPool));
    }

    protected override void Start()
    {
        for (int i = 0; i < countPrewarm; i++)
        {
            base.Spawn();
            tempItem = LastSpawnedObject.GetComponent<ItemPool>();
            tempItem.Init(this);
            tempItem.gameObject.SetActive(false);
        }
        base.Start();
    } 
    
    private IEnumerator SetParentDelayed(ItemPool itemPool)
    {
        yield return null;
        if (itemPool != null)
        {
            itemPool.transform.SetParent(transform);
        }
    }
}
