using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLayout : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI buttonLabel;

    public event Action<TypeData> OnPressed;

    TypeData _data;

    public void SetData(TypeData data)
    {
        _data = data;

        buttonLabel.SetText(_data.Name);
        button.onClick.AddListener(OnButtonPressedHandler);
    }

    void OnButtonPressedHandler()
    {
        OnPressed?.Invoke(_data);
    }
}