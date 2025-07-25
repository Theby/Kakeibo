using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI.Dates;
using UnityEngine;
using UnityEngine.UI;

public class IncomeFormPanel : MonoBehaviour
{
    [SerializeField] DatePicker datePicker;
    [SerializeField] TMP_InputField amountInput;
    [SerializeField] TMP_Dropdown currencyDropdown;
    [SerializeField] TMP_InputField descriptionInput;
    [SerializeField] Button submitButton;
    [SerializeField] Button backButton;

    public List<CurrencyData> Currencies => GameManager.KakeiboManager.Currencies;

    void Awake()
    {
        submitButton.onClick.AddListener(SaveIncomeHandler);
        backButton.onClick.AddListener(OpenHomePanelHandler);
    }

    public void Initialize()
    {
        ResetInputs();
    }

    void ResetInputs()
    {
        datePicker.SelectedDate = DateTime.Now;
        amountInput.text = string.Empty;
        currencyDropdown.ClearOptions();
        currencyDropdown.AddOptions(Currencies.Select(c => c.Name).ToList());
        descriptionInput.text = string.Empty;
    }

    void SaveIncomeHandler()
    {
        if (amountInput.text == string.Empty)
        {
            return;
        }

        var incomeData = new IncomeData
        {
            Date = datePicker.SelectedDate.Date,
            Amount = decimal.Parse(amountInput.text),
            Currency = Currencies[currencyDropdown.value],
            Description = descriptionInput.text
        };

        GameManager.KakeiboManager.AddIncome(incomeData);
        ResetInputs();
    }

    void OpenHomePanelHandler()
    {
        GameManager.CanvasManager.ShowHomePanel();
    }
}
