using System;
using UnityEngine;

/// <summary>
/// Данные базы
/// </summary>
[CreateAssetMenu(fileName = "New FractionData", menuName = "DronesSimulation/Features/Fraction/FractionData")]
public class FractionData : ScriptableObject
{
    public event Action OnFractionBaseSet = delegate { };

    /// <summary>
    /// Id фракции
    /// </summary>
    public string Id => _id;

    /// <summary>
    /// Материал/цвет фракции
    /// </summary>
    public Material FractionMaterial => _fractionMaterial;

    public FractionBase FractionBase
    {
        get { return _fractionBase; }
        set
        {
            _fractionBase = value;
            OnFractionBaseSet.Invoke();
        }
    }

    [SerializeField] private string _id = string.Empty;
    [SerializeField] private Material _fractionMaterial = default;

    private FractionBase _fractionBase = default;
}
