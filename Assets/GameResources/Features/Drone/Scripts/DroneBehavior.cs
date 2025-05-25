using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

/// <summary>
/// Скрипт поведения дрона
/// </summary>
public class DroneBehavior : MonoBehaviour
{
    /// <summary>
    /// Событие разгрузки
    /// </summary>
    public event Action onSupplyUnload = delegate { };

    [Header("Settings")]
    [SerializeField] private float _collectionTime = 2f;
    [SerializeField] private float _searchRadius = 20f;
    [SerializeField] private FractionData _fractionData = default;
    [SerializeField] private LayerMask _resourceLayer = default;

    private NavMeshAgent _agent = default;
    private FractionBase _homeBase = default;
    private GameObject _currentTarget = default;
    private bool _isWorking = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _homeBase = _fractionData.FractionBase;
        
        if (_homeBase == null)
        {
            Debug.LogError("No ResourceBase found in scene!");
            _isWorking = false;
            return;
        }

        StartCoroutine(WorkCycle());
    }

    IEnumerator WorkCycle()
    {
        while (_isWorking)
        {
            // 1. Найти ближайший свободный ресурс
            _currentTarget = FindNearestResource();

            if (_currentTarget == null)
            {
                Debug.Log("No resources found, waiting...");
                yield return new WaitForSeconds(1f);
                continue;
            }
            // 2. Долететь до ресурса
            _agent.SetDestination(_currentTarget.transform.position);
            yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending);

            // 3. Собрать ресурс (ожидание 2 секунды)
            yield return new WaitForSeconds(_collectionTime);

            // Уничтожаем ресурс
            _currentTarget.SetActive(false);
            _currentTarget.GetComponent<Supply>().IsTaken = false;

            // 4. Вернуться на базу
            _agent.SetDestination(_homeBase.transform.position);
            yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending);

            // 5. Выгрузить ресурс (визуальные эффекты)
            onSupplyUnload.Invoke();
            yield return new WaitForSeconds(_collectionTime);
        }
    }

    private GameObject FindNearestResource()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _searchRadius, _resourceLayer);
        GameObject nearestResource = null;
        float minDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            // Проверяем, не занят ли ресурс другим дроном
            if (hitCollider.GetComponent<Supply>() && !hitCollider.GetComponent<Supply>().IsTaken)
            {
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestResource = hitCollider.gameObject;
                }
            }
        }

        if (nearestResource != null)
        {
            nearestResource.GetComponent<Supply>().IsTaken = true;
        }

        return nearestResource;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _searchRadius);
    }
}