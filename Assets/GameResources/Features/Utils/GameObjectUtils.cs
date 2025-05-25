 using UnityEngine;

/// <summary>
/// Класс с методами расширения для gameObject
/// </summary>
public static class GameObjectUtils
{
    /// <summary>
    /// Сбросить локальную позицию в ноль
    /// </summary>
    /// <param name="target"></param>
    /// <param name="parent"></param>
    public static void ResetLocalPosition(this GameObject target, GameObject parent)
    {
        target.transform.SetParent(parent.transform);
        target.transform.localPosition = Vector3.zero;
        target.transform.SetParent(null);
    }

    /// <summary>
    /// Сбросить поворот в ноль
    /// </summary>
    /// <param name="target"></param>
    public static void ResetRotation(this GameObject target)
    {
        target.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    /// <summary>
    /// Сбросить локальный поворот в ноль
    /// </summary>
    /// <param name="target"></param>
    public static void ResetLocalRotation(this GameObject target, GameObject parent)
    {
        target.transform.rotation = parent.transform.rotation;
    }
}
