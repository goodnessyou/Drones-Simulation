using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Слайдер для установки скорости дронов
/// </summary>
[RequireComponent(typeof(Slider))]
public class DronesSpeedSlider : MonoBehaviour
{
    [SerializeField] private DronesSpeedModel _speedModel = default;
    private Slider _slider = default;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        SetSliderValue();
    }

    private void OnEnable() => _slider.onValueChanged.AddListener(SetDronesSpeed);
    private void OnDisable() => _slider.onValueChanged.RemoveListener(SetDronesSpeed);

    private void SetDronesSpeed(float speed) => _speedModel.Speed = speed;

    private void SetSliderValue() => _slider.value = _speedModel.Speed;
}
