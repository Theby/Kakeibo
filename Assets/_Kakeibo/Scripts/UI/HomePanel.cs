using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI incomeValueText;
    [SerializeField] TextMeshProUGUI expenseValueText;
    [SerializeField] TextMeshProUGUI bankValueText;
    [SerializeField] TextMeshProUGUI creditValueText;
    [SerializeField] TextMeshProUGUI totalValueText;
    [SerializeField] TextMeshProUGUI ggffExpRealValueText;
    [SerializeField] TextMeshProUGUI personalExpRealValueText;
    [SerializeField] TextMeshProUGUI versionText;
    [SerializeField] Button incomeButton;
    [SerializeField] Button expenseButton;
    [SerializeField] Button seeExpensesButton;
    [SerializeField] Button payCreditButton;

    public void Awake()
    {
        incomeButton.onClick.AddListener(OpenIncomePanelHandler);
        expenseButton.onClick.AddListener(OpenExpensePanelHandler);
        seeExpensesButton.onClick.AddListener(OpenSeeExpensesPanelHandler);
        payCreditButton.onClick.AddListener(OpenPayCreditPanelHandler);
    }

    public void Initialize()
    {
        var summaryData = GameManager.KakeiboManager.GetSummaryData(2025);

        var income = summaryData.TotalIncome;
        var expenses = summaryData.TotalExpenses;
        var bank = summaryData.TotalIncome - summaryData.TotalExpenses;
        var creditHold = summaryData.CreditHold;
        var total = bank - creditHold;

        incomeValueText.SetText(income.ToCurrencyString());
        expenseValueText.SetText(expenses.ToCurrencyString());
        bankValueText.SetText(bank.ToCurrencyString());
        creditValueText.SetText(creditHold.ToCurrencyString());
        totalValueText.SetText(total.ToCurrencyString());

        versionText.SetText($"v{Application.version}");
    }

    void OpenIncomePanelHandler()
    {
        GameManager.CanvasManager.ShowIncomeFormPanel();
    }

    void OpenExpensePanelHandler()
    {
        GameManager.CanvasManager.ShowExpenseFormPanel();
    }

    void OpenSeeExpensesPanelHandler()
    {
        GameManager.CanvasManager.ShowSeeExpensesPanel();
    }

    void OpenPayCreditPanelHandler()
    {
        GameManager.CanvasManager.ShowPayCreditsPanel();
    }
}
