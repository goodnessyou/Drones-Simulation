using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент для вывода скорости дронов
/// </summary>
[RequireComponent(typeof(Text))]
public class IntegerValueView : MonoBehaviour
{
    [SerializeField] private IntegerValue _speedModel = default;
    private Text _text = default;

    private void Awake()
    {
        _text = GetComponent<Text>();
        SetSpeedText();
    }

    private void OnEnable() => _speedModel.onValueChanged += SetSpeedText;
    private void OnDisable() => _speedModel.onValueChanged -= SetSpeedText;
    private void SetSpeedText() => _text.text = _speedModel.Value.ToString();
}
