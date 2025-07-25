using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PayCreditsPanel : MonoBehaviour
{
    [SerializeField] Button backButton;
    [SerializeField] Button showAllButton;
    [SerializeField] ScrollRect buttonScrollRect;
    [SerializeField] GameObject buttonContent;
    [SerializeField] ButtonLayout buttonLayoutPrefab;
    [SerializeField] TextMeshProUGUI totalLabel;
    [SerializeField] ScrollRect expenseScrollRect;
    [SerializeField] GameObject expenseContent;
    [SerializeField] PayCreditExpenseLayout payCreditExpenseLayoutPrefab;
    [SerializeField] Button payButton;

    List<ExpenseData> _sortedExpenses;
    List<PayCreditExpenseLayout> _payCreditExpenseLayouts;

    void Awake()
    {
        backButton.onClick.AddListener(OpenHomePanelHandler);
        payButton.onClick.AddListener(PayCreditHandler);
        showAllButton.onClick.AddListener(ShowAllHandler);
    }

    public void Initialize()
    {
        buttonContent.transform.DestroyChildren();
        buttonScrollRect.verticalNormalizedPosition = 0;

        expenseContent.transform.DestroyChildren();
        expenseScrollRect.verticalNormalizedPosition = 0;

        var types = GameManager.KakeiboManager.Types;
        foreach (var typeData in types)
        {
            var buttonLayout = Instantiate(buttonLayoutPrefab, buttonContent.transform);
            buttonLayout.SetData(typeData);
            buttonLayout.OnPressed += OnTypeButtonPressed;
        }

        UpdateExpenses();
        ShowExpenses(_sortedExpenses);
        UpdateTotal();
    }

    void UpdateExpenses()
    {
        var expenses = GameManager.KakeiboManager.GetExpensesBy(e => !e.Paid);
        _sortedExpenses = expenses.OrderBy(e => e.Date).ToList();
    }

    void ShowExpenses(List<ExpenseData> expenses)
    {
        expenseContent.transform.DestroyChildren();
        expenseScrollRect.verticalNormalizedPosition = 0;

        _payCreditExpenseLayouts = new List<PayCreditExpenseLayout>();
        foreach (var expenseData in expenses)
        {
            var layout = Instantiate(payCreditExpenseLayoutPrefab, expenseContent.transform);
            layout.SetData(expenseData);
            layout.OnSelected += OnExpenseSelectedHandler;

            _payCreditExpenseLayouts.Add(layout);
        }
    }

    void UpdateTotal()
    {
        decimal total = _payCreditExpenseLayouts.Where(e => e.IsSelected)
            .Sum(e => e.Data.Amount);
        totalLabel.SetText(total.ToCurrencyString());
    }

    void OpenHomePanelHandler()
    {
        GameManager.CanvasManager.ShowHomePanel();
    }

    void PayCreditHandler()
    {
        var selectedExpenses = _payCreditExpenseLayouts.Where(e => e.IsSelected)
            .Select(e => e.Data).ToList();

        GameManager.KakeiboManager.UpdateExpenses(selectedExpenses);

        UpdateExpenses();
        ShowExpenses(_sortedExpenses);
        UpdateTotal();
    }

    void ShowAllHandler()
    {
        ShowExpenses(_sortedExpenses);
    }

    void OnTypeButtonPressed(TypeData data)
    {
        var expenses = _sortedExpenses.Where(e => e.Type.Name == data.Name).ToList();
        ShowExpenses(expenses);
    }

    void OnExpenseSelectedHandler()
    {
        UpdateTotal();
    }
}
