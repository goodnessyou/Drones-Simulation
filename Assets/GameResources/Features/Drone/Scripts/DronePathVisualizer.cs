using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Компонент для отрисовки пути дрона
/// </summary>
[RequireComponent(typeof(NavMeshAgent), typeof(LineRenderer))]
public class DronePathVisualizer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _lineHeightOffset = 4f;
    [SerializeField] private Color _lineColor = default;
    [SerializeField] private float _lineWidth = 0.2f;

    private NavMeshAgent _agent = default;
    private LineRenderer _lineRenderer = default;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        SetupLineRenderer();
    }

    private void SetupLineRenderer()
    {
        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;
        _lineRenderer.startColor = _lineColor;
        _lineRenderer.endColor = _lineColor;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default")) { color = _lineColor };
        _lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (_agent.hasPath)
        {
            DrawPath();
        }
        else
        {
            _lineRenderer.positionCount = 0;
        }
    }

    private void DrawPath()
    {
        var path = _agent.path;
        _lineRenderer.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            Vector3 pointPosition = path.corners[i] + Vector3.up * _lineHeightOffset;
            _lineRenderer.SetPosition(i, pointPosition);
        }
    }
}