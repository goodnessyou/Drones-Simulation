using System;
using UnityEngine;

/// <summary>
/// Данные фракции в виде ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "New FractionData", menuName = "DronesSimulation/Features/Fraction/FractionData")]
public class FractionData : ScriptableObject
{
    /// <summary>
    /// Событие установки базы фракции
    /// </summary>
    public event Action onFractionBaseSet = delegate { };

    /// <summary>
    /// Событие изменения количества ресурсов у фракции
    /// </summary>
    public event Action onResourcesCountChange = delegate { };

    /// <summary>
    /// Id фракции
    /// </summary>
    public string Id => _id;

    /// <summary>
    /// Материал/цвет фракции
    /// </summary>
    public Material FractionMaterial => _fractionMaterial;

    public int ResourcesCount
    {
        get => _resourcesCount;
        set
        {
            if (_resourcesCount != value)
            {
                _resourcesCount = value;
                onResourcesCountChange.Invoke();
            }
        }
    }

    public FractionBase FractionBase
    {
        get => _fractionBase;
        set
        {
            if (_fractionBase != value)
            {
                _fractionBase = value;
                onFractionBaseSet.Invoke();
            }
        }
    }

    [SerializeField] private string _id = string.Empty;
    [SerializeField] private Material _fractionMaterial = default;
    [SerializeField, Min(0)] private int _resourcesCount = 0;
    [SerializeField] private FractionBase _fractionBase = default;
}
