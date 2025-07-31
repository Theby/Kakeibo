using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PayCreditExpenseLayout : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI incomeValueText;
    [SerializeField] Button selectedButton;
    [SerializeField] TextMeshProUGUI buttonLabel;

    public ExpenseData Data { get; private set; }
    public bool IsSelected { get; private set; }

    public event Action OnSelected;

    public void SetData(ExpenseData data)
    {
        Data = data;

        incomeValueText.SetText(
            $"{Data.Date.ToCalendarDate()}\n" +
            $"{Data.Category.CategorySection.Name}/{Data.Category.Name}\n" +
            $"{Data.Type.Name}: <b>{Data.Amount.ToCurrencyString()}</b>\n" +
            $"{Data.Description}");

        selectedButton.onClick.RemoveAllListeners();
        selectedButton.onClick.AddListener(OnSelectedHandler);

        SetIsSelectedButton(true);
    }

    void OnSelectedHandler()
    {
        SetIsSelectedButton(!IsSelected);
    }

    void SetIsSelectedButton(bool isSelected)
    {
        IsSelected = isSelected;
        buttonLabel.SetText(IsSelected ? "O" : "X");

        OnSelected?.Invoke();
    }
}
