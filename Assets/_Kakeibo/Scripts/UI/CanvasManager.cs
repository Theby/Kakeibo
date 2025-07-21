using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] HomePanel homePanel;
    [SerializeField] IncomeFormPanel incomeFormPanel;
    [SerializeField] ExpenseFormPanel expenseFormPanel;
    [SerializeField] SeeExpensesPanel seeExpensesFormPanel;

    void Awake()
    {
        HidePanels();
    }

    public void Initialize()
    {
        ShowHomePanel();
    }

    void HidePanels()
    {
        homePanel.gameObject.SetActive(false);
        incomeFormPanel.gameObject.SetActive(false);
        expenseFormPanel.gameObject.SetActive(false);
        seeExpensesFormPanel.gameObject.SetActive(false);
    }

    public void ShowHomePanel()
    {
        HidePanels();
        homePanel.gameObject.SetActive(true);
        homePanel.Initialize();
    }

    public void ShowIncomeFormPanel()
    {
        HidePanels();
        incomeFormPanel.gameObject.SetActive(true);
        incomeFormPanel.Initialize();
    }

    public void ShowExpenseFormPanel()
    {
        HidePanels();
        expenseFormPanel.gameObject.SetActive(true);
        expenseFormPanel.Initialize();
    }

    public void ShowSeeExpensesPanel()
    {
        HidePanels();
        seeExpensesFormPanel.gameObject.SetActive(true);
        seeExpensesFormPanel.Initialize();
    }
}
