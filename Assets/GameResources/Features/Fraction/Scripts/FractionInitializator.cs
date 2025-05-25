using UnityEngine;

/// <summary>
/// Инициализатор фрации и базы
/// </summary>
public class FractionInitializator : MonoBehaviour
{
    [SerializeField] private FractionData _fractionData = default;
    [SerializeField] private FractionBase _fractionBase = default;

    private void Awake() => _fractionData.FractionBase = _fractionBase;
}
