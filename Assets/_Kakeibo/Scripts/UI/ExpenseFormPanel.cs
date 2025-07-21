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

    List<TypeData> _types;
    List<CategoryData> _categories;
    List<CurrencyData> _currencies;

    void Awake()
    {
        submitButton.onClick.AddListener(SaveExpenseHandler);
        backButton.onClick.AddListener(OpenHomePanelHandler);

        _types = GameManager.KakeiboManager.GetAllTypes();
        _categories = GameManager.KakeiboManager.GetAllCategories();
        _currencies = GameManager.KakeiboManager.GetAllCurrencies();
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
        typeDropdown.AddOptions(_types.Select(c => c.Name).ToList());
        categoryDropdown.ClearOptions();
        categoryDropdown.AddOptions(_categories.Select(c => c.Name).ToList());
        amountInput.text = string.Empty;
        currencyDropdown.ClearOptions();
        currencyDropdown.AddOptions(_currencies.Select(c => c.Name).ToList());
        descriptionInput.text = string.Empty;
    }

    void SaveExpenseHandler()
    {
        if (amountInput.text == string.Empty)
        {
            return;
        }

        var type = _types[typeDropdown.value];
        var expenseData = new ExpenseData()
        {
            Date = datePicker.SelectedDate.Date,
            BillingDate = billingDatePicker.SelectedDate.Date,
            Type = _types[typeDropdown.value],
            Category = _categories[categoryDropdown.value],
            Amount = decimal.Parse(amountInput.text),
            Currency = _currencies[currencyDropdown.value],
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