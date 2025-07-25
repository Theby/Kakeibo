using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UI.Dates;
using UnityEngine;
using UnityEngine.UI;

public class ExpenseFormPanel : MonoBehaviour
{
    [SerializeField] DatePicker datePicker;
    [SerializeField] DatePicker billingDatePicker;
    [SerializeField] TMP_Dropdown typeDropdown;
    [SerializeField] TMP_Dropdown categoryDropdown;
    [SerializeField] TMP_InputField amountInput;
    [SerializeField] TMP_Dropdown currencyDropdown;
    [SerializeField] TMP_InputField descriptionInput;
    [SerializeField] Button submitButton;
    [SerializeField] Button backButton;

    List<TypeData> Types => GameManager.KakeiboManager.Types;
    List<CategoryData> Categories => GameManager.KakeiboManager.Categories;
    List<CurrencyData> Currencies => GameManager.KakeiboManager.Currencies;

    void Awake()
    {
        submitButton.onClick.AddListener(SaveExpenseHandler);
        backButton.onClick.AddListener(OpenHomePanelHandler);
    }

    public void Initialize()
    {
        ResetInputs();
    }

    void ResetInputs()
    {
        datePicker.SelectedDate = DateTime.Now;
        billingDatePicker.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        typeDropdown.ClearOptions();
        typeDropdown.AddOptions(Types.Select(c => c.Name).ToList());
        categoryDropdown.ClearOptions();
        categoryDropdown.AddOptions(Categories.Select(c => c.Name).ToList());
        amountInput.text = string.Empty;
        currencyDropdown.ClearOptions();
        currencyDropdown.AddOptions(Currencies.Select(c => c.Name).ToList());
        descriptionInput.text = string.Empty;
    }

    void SaveExpenseHandler()
    {
        if (amountInput.text == string.Empty)
        {
            return;
        }

        var type = Types[typeDropdown.value];
        var expenseData = new ExpenseData()
        {
            Date = datePicker.SelectedDate.Date,
            BillingDate = billingDatePicker.SelectedDate.Date,
            Type = Types[typeDropdown.value],
            Category = Categories[categoryDropdown.value],
            Amount = decimal.Parse(amountInput.text),
            Currency = Currencies[currencyDropdown.value],
            Description = descriptionInput.text,
            Paid = type.IsDebit,
        };

        GameManager.KakeiboManager.AddExpense(expenseData);
        ResetInputs();
    }

    void OpenHomePanelHandler()
    {
        GameManager.CanvasManager.ShowHomePanel();
    }
}