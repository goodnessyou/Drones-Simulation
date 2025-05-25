using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент ресурса
/// </summary>
public class Supply : MonoBehaviour
{
    public bool IsTaken { get; set; }
    
    void Start()
    {
        IsTaken = false;
    }
}
