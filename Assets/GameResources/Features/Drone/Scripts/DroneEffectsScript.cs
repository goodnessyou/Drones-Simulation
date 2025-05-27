using System.Collections;
using UnityEngine;

/// <summary>
/// Компонент для проигрывания эффекта разгрузки дрона
/// </summary>
public class DroneEffectsScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem unloadParticles;

    [SerializeField, Min(0f)] private float unloadTime = 1f;

    [SerializeField] private DroneBehavior _droneBehavior = default;

    private void OnEnable() => _droneBehavior.onSupplyUnload += OnSupplyUnload;
    private void OnDisable() => _droneBehavior.onSupplyUnload -= OnSupplyUnload;

    private void OnSupplyUnload() => StartCoroutine(PlayUnloadEffects());
    private IEnumerator PlayUnloadEffects()
    {
        if (unloadParticles != null)
        {
            unloadParticles.Play();
            yield return new WaitForSeconds(unloadTime);
            unloadParticles.Stop();
        }
    }
}
