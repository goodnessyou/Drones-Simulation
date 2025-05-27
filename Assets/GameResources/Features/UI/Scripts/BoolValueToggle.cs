using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент тоггла переключающий BoolValue
/// </summary>
[RequireComponent(typeof(Toggle))]
public class BoolValueToggle : MonoBehaviour
{
    [SerializeField] private BoolValue _boolValue = default;

    private Toggle _toggle = default;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = _boolValue.Value;
    }

    private void OnEnable() => _toggle.onValueChanged.AddListener(SetBoolValue);
    private void OnDisable() => _toggle.onValueChanged.RemoveListener(SetBoolValue);
    private void SetBoolValue(bool value) => _boolValue.Value = value;
}
