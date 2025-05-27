using UnityEngine;

/// <summary>
/// Компонент ресурса
/// </summary>
public class Supply : MonoBehaviour
{
    public bool IsTaken
    {
        get => _isTaken;
        set
        {
            if (_isTaken != value)
            {
                _isTaken = value;
            }
        }
    }
    
    [SerializeField] private bool _isTaken = false;
    
    void OnEnable() => IsTaken = false;
    
}
