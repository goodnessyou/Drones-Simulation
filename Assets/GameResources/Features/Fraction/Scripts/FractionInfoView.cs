using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент для вывода информации о фракции
/// </summary>
public class FractionInfoView : MonoBehaviour
{
    [SerializeField] private FractionData _frractionData = default;
    [SerializeField] private Text _fractionNameText = default;
    [SerializeField] private Text _fractionResourcesText = default;

    private void Awake()
    {
        _fractionNameText.text = _frractionData.Id;
        _fractionNameText.color = _frractionData.FractionMaterial.color;
        UpdateFractionInfo();
    }

    private void OnEnable() => _frractionData.onResourcesCountChange += UpdateFractionInfo;
    private void OnDisable() => _frractionData.onResourcesCountChange -= UpdateFractionInfo;
    private void UpdateFractionInfo() => _fractionResourcesText.text = _frractionData.ResourcesCount.ToString();
    
}
