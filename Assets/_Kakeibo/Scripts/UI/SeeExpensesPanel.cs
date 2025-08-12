using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeeExpensesPanel : MonoBehaviour
{
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GameObject content;
    [SerializeField] TextMeshProUGUI textPrefab;
    [SerializeField] Button backButton;

    void Awake()
    {
        backButton.onClick.AddListener(OpenHomePanelHandler);
    }

    public void Initialize()
    {
        content.transform.DestroyChildren();
        scrollRect.verticalNormalizedPosition = 0;

        var expenses = GameManager.KakeiboManager.GetExpensesBy(e => (!e.Paid && e.TypeId == 1) || (e.BillingYear == 2025 && e.BillingMonth == 8 && e.TypeId != 1));
        var sortedExpenses = expenses.OrderBy(e => e.Date);

        foreach (var expenseData in sortedExpenses)
        {
            var expenseDisplay = Instantiate(textPrefab, content.transform);
            expenseDisplay.SetText(
                $"{expenseData.Date.ToCalendarDate()}\n" +
                $"{expenseData.Category.CategorySection.Name}/{expenseData.Category.Name}\n" +
                $"{expenseData.Type.Name}: <b>{expenseData.Amount.ToCurrencyString()}</b>\n" +
                $"{expenseData.Description}\n");
        }
    }

    void OpenHomePanelHandler()
    {
        GameManager.CanvasManager.ShowHomePanel();
    }
}