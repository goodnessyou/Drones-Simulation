using UnityEngine;

/// <summary>
/// Скрипт для установки объекту материал фракции
/// </summary>
public class FractionMaterialView : MonoBehaviour
{
    [SerializeField] private FractionData _fractionData = default;
    [SerializeField] private Renderer _renderer = default;

    private void Awake()
    {
        if (_fractionData != null && _renderer != null)
        {
            _renderer.material = _fractionData.FractionMaterial;
        }
    }
}
