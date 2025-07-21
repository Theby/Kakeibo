using System.Globalization;
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
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        var expenses = GameManager.KakeiboManager.GetExpensesBy(e => !e.Paid || e.BillingYear == 2025 && e.BillingMonth == 7);
        var sortedExpenses = expenses.OrderBy(e => e.Date);

        CultureInfo culture = new CultureInfo("es-CL");

        foreach (var expenseData in sortedExpenses)
        {
            var expenseDisplay = Instantiate(textPrefab, content.transform);
            expenseDisplay.SetText(
                $"{expenseData.Date:yyyy/MM/dd}\n" +
                $"{expenseData.Category.CategorySection.Name}/{expenseData.Category.Name}\n" +
                $"{expenseData.Type.Name}: <b>{expenseData.Amount.ToString("C", culture)}</b>\n" +
                $"{expenseData.Description}");
        }
    }

    void OpenHomePanelHandler()
    {
        GameManager.CanvasManager.ShowHomePanel();
    }
}