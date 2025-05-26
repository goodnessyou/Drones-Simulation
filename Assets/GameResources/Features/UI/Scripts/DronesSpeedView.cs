using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент для вывода скорости дронов
/// </summary>
[RequireComponent(typeof(Text))]
public class DronesSpeedView : MonoBehaviour
{
    [SerializeField] private DronesSpeedModel _speedModel = default;
    private Text _text = default;

    private void Awake()
    {
        _text = GetComponent<Text>();
        SetSpeedText();
    }

    private void OnEnable() => _speedModel.onDronesSpeedChange += SetSpeedText;
    private void OnDisable() => _speedModel.onDronesSpeedChange -= SetSpeedText;
    private void SetSpeedText() => _text.text = _speedModel.Speed.ToString();
}
