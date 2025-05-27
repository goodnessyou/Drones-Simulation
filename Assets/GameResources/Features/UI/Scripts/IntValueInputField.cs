using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// компонент для InputField ввода значения в IntegerValue
/// </summary>
[RequireComponent(typeof(InputField))]
public class IntValueInputField : MonoBehaviour
{
    [SerializeField] private IntegerValue _spawnRateValue = default;

    private InputField _inputField = default;

    private void Awake()
    {
        _inputField = GetComponent<InputField>();
        _inputField.text = _spawnRateValue.Value.ToString();
    }

    private void OnEnable() => _inputField.onEndEdit.AddListener(TryChangeIntValue);

    private void TryChangeIntValue(string input)
    {
        int number;

        if (int.TryParse(input, out number))
        {
            _spawnRateValue.Value = number;
        }
        else
        {
            _inputField.text = _spawnRateValue.Value.ToString();
        }
    }
}
