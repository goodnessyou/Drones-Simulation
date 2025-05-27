using UnityEngine;

/// <summary>
/// Скрипт для установки объекту материал фракции
/// </summary>
public class FractionMaterialView : MonoBehaviour
{
    public FractionData FractionData
    {
        get => _fractionData;
        set
        {
            if (_fractionData != value)
            {
                _fractionData = value;
                SetMaterial();
            }
        }
    }

    [SerializeField] private FractionData _fractionData = default;
    [SerializeField] private Renderer _renderer = default;

    private void OnEnable() => SetMaterial();

    private void SetMaterial()
    {
        if (_fractionData != null && _renderer != null)
        {
            _renderer.material = _fractionData.FractionMaterial;
        }
    }
}
