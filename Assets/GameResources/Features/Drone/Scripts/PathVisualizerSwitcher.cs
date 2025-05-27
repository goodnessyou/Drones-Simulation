using UnityEngine;

/// <summary>
/// Переключатель видимости пути дронов
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class PathVisualizerSwitcher : MonoBehaviour
{
    [SerializeField] private BoolValue _pathVisible = default;

    private LineRenderer _dronePathVisualizer = default;

    private void Awake()
    {
        _pathVisible.onValueChanged += SwitchPathVisible;
        _dronePathVisualizer = GetComponent<LineRenderer>();
        SwitchPathVisible();
    } 

    private void OnDestroy() => _pathVisible.onValueChanged -= SwitchPathVisible;
    private void SwitchPathVisible() => _dronePathVisualizer.enabled = _pathVisible.Value;
}
