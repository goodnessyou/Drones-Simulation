using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Слайдер для установки Int Value в Scriptable object
/// </summary>
[RequireComponent(typeof(Slider))]
public class IntegerValueSlider : MonoBehaviour
{
    [SerializeField] private IntegerValue _speedValue = default;
    private Slider _slider = default;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        SetSliderValue();
    }

    private void OnEnable() => _slider.onValueChanged.AddListener(SetDronesSpeed);
    private void OnDisable() => _slider.onValueChanged.RemoveListener(SetDronesSpeed);

    private void SetDronesSpeed(float speed) => _speedValue.Value = (int)speed;

    private void SetSliderValue() => _slider.value = _speedValue.Value;
}
