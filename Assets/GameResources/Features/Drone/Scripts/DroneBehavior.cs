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

    public FractionData Fraction
    {
        get => _fraction;
        set
        {
            if (_fraction != value)
            {
                _fraction = value;
            }
        }
    }

    [Header("Settings")]
    [SerializeField, Min(0)] private float _collectionTime = 2f;
    [SerializeField, Min(0)] private float _searchRadius = 20f;
    [SerializeField] private FractionData _fraction = default;
    [SerializeField] private LayerMask _resourceLayer = default;

    private NavMeshAgent _agent = default;
    private FractionBase _homeBase = default;
    private GameObject _currentTarget = default;
    private bool _isWorking = true;
    private Coroutine _workCycle = default;

    public void SetUp()
    {
        _homeBase = _fraction.FractionBase;

        if (_homeBase == null)
        {
            Debug.LogError("No ResourceBase found in scene!");
            _isWorking = false;
            return;
        }

        if (_workCycle == null)
        {
            _workCycle = StartCoroutine(WorkCycle());
        }
        
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.avoidancePriority = UnityEngine.Random.Range(1, 100);
    }

    private void OnEnable()
    {
        if (_fraction != null)
        {
            SetUp();
        }
    }

    private void OnDisable()
    {
        if (_currentTarget != null)
        {
            _currentTarget.GetComponent<Supply>().IsTaken = false;
        }

        if (_workCycle != null)
        {
            StopCoroutine(_workCycle);
            _workCycle = null;
        }
    }

    IEnumerator WorkCycle()
    {
        while (_isWorking)
        {
            // 1. Найти ближайший свободный ресурс
            _currentTarget = FindNearestResource();

            if (_currentTarget == null)
            {
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

            // 4. Вернуться на базу
            _agent.SetDestination(_homeBase.transform.position);
            yield return new WaitUntil(() => _agent.remainingDistance <= _agent.stoppingDistance && !_agent.pathPending);

            // 5. Выгрузить ресурс (визуальные эффекты)
            _fraction.ResourcesCount++;
            onSupplyUnload.Invoke();
            yield return new WaitForSeconds(_collectionTime);
            _agent.SetDestination(_currentTarget.transform.position);
        }
    }

    private GameObject FindNearestResource()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _searchRadius, _resourceLayer);
        GameObject nearestResource = null;
        float minDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
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