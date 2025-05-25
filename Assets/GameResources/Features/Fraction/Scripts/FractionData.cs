using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Данные базы
/// </summary>
 [CreateAssetMenu(fileName = "New FractionData", menuName = "DronesSimulation/Features/Fraction/FractionData")]
public class FractionData : ScriptableObject
{
    /// <summary>
    /// Id фракции
    /// </summary>
    public string Id => _id;

    /// <summary>
    /// Материал/цвет фракции
    /// </summary>
    public Material FractionMaterial => _fractionMaterial;

    [SerializeField] private string _id = string.Empty;
    [SerializeField] private Material _fractionMaterial = default;
}
