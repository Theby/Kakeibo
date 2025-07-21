using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class KakeiboManager : MonoBehaviour
{
    SQLController _sqlController;

    public void Initialize(SQLController sqlController)
    {
        _sqlController = sqlController;

        AddDefaults();
    }

    void AddDefaults()
    {
        AddDefaultTypes();
        AddDefaultCategories();
        AddDefaultCurrencies();
    }

    void AddDefaultTypes()
    {
        if (!_sqlController.IsTableEmpty<TypeSQLData>())
        {
            return;
        }

        foreach (var defaultType in DefaultDatabaseValues.DefaultTypes)
        {
            AddType(defaultType);
        }
    }

    void AddDefaultCategories()
    {
        if (!_sqlController.IsTableEmpty<CategorySectionSQLData>())
        {
            return;
        }

        foreach (var defaultCategorySection in DefaultDatabaseValues.DefaultCategories)
        {
            AddCategorySection(defaultCategorySection.Key);
            var sectionId = _sqlController
                .GetBy<CategorySectionSQLData>(
                    x => x.Name == defaultCategorySection.Key)
                .Id;
            foreach (var defaultCategory in defaultCategorySection.Value)
            {
                AddCategory(sectionId, defaultCategory);
            }
        }
    }

    void AddDefaultCurrencies()
    {
        if (!_sqlController.IsTableEmpty<CurrencySQLData>())
        {
            return;
        }

        foreach (var defaultCurrency in DefaultDatabaseValues.DefaultCurrencyData)
        {
            AddCurrency(defaultCurrency);
        }
    }

    void AddType(string typeName)
    {
        var debitType = new TypeSQLData()
        {
            Name = typeName
        };
        _sqlController.Insert<TypeSQLData>(debitType);
    }

    void AddCategorySection(string categoryName)
    {
        var categorySection = new CategorySectionSQLData()
        {
            Name = categoryName
        };
        _sqlController.Insert<CategorySectionSQLData>(categorySection);
    }

    void AddCategory(int categorySectionId, string categoryName)
    {
        var category = new CategorySQLData()
        {
            Name = categoryName,
            SectionId = categorySectionId,
        };
        _sqlController.Insert<CategorySQLData>(category);
    }

    public void AddCurrency(CurrencyData currencyData)
    {
        var currency = currencyData.ToSQLData();
        _sqlController.Insert<CurrencySQLData>(currency);
    }

    public void AddIncome(IncomeData incomeData)
    {
        var income = incomeData.ToSQLData();
        _sqlController.Insert<IncomeSQLData>(income);

        var summary = GetSummaryData(incomeData.Date.Year);
        summary.TotalIncome += incomeData.Amount;
        UpdateSummary(summary);
    }

    public void AddExpense(ExpenseData expenseData)
    {
        var expense = expenseData.ToSQLData();
        _sqlController.Insert<ExpenseSQLData>(expense);

        var summary = GetSummaryData(expenseData.Date.Year);
        if (expense.Paid)
        {
            summary.TotalExpenses += expense.Amount;
        }
        else
        {
            summary.CreditHold += expense.Amount;
        }

        UpdateSummary(summary);
    }

    public List<ExpenseData> GetExpensesBy(Expression<Func<ExpenseSQLData,bool>> filter)
    {
        var expenses = new List<ExpenseData>();
        var data = _sqlController.GetAllBy<ExpenseSQLData>(filter);
        foreach (var sqlData in data)
        {
            var expense = new ExpenseData(sqlData);
            expenses.Add(expense);
        }

        return expenses;
    }

    public List<CurrencyData> GetAllCurrencies()
    {
        var currencies = new List<CurrencyData>();
        var data = _sqlController.GetAll<CurrencySQLData>();
        foreach (var sqlData in data)
        {
            var currency = new CurrencyData(sqlData);
            currencies.Add(currency);
        }

        return currencies;
    }

    public CurrencyData GetCurrencyById(int id)
    {
        var sqlData = _sqlController.GetById<CurrencySQLData>(id);
        var currencyData = new CurrencyData(sqlData);

        return currencyData;
    }

    public SummaryData GetSummaryData(int year)
    {
        var sqlData = _sqlController.GetBy<SummarySQLData>(s => s.Year == year);
        if (sqlData == null)
        {
            ForceUpdateSummary(year);
            sqlData = _sqlController.GetBy<SummarySQLData>(s => s.Year == year);
        }

        var summaryData = new SummaryData(sqlData);
        return summaryData;
    }

    public void AddSummary(SummaryData summaryData)
    {
        var summary = summaryData.ToSQLData();
        _sqlController.Insert<SummarySQLData>(summary);
    }

    public void UpdateSummary(SummaryData summaryData)
    {
        var summary = summaryData.ToSQLData();
        _sqlController.Update(summary);
    }

    void ForceUpdateSummary(int year)
    {
        var totalIncome = _sqlController.GetAllBy<IncomeSQLData>(
            i => i.Year == year).Sum(i => i.Amount);
        var totalExpenses = _sqlController.GetAllBy<ExpenseSQLData>(
            e => e.BillingYear == year && e.Paid).Sum(e => e.Amount);
        var creditHold = _sqlController.GetAllBy<ExpenseSQLData>(
            e => e.BillingYear == year && !e.Paid).Sum(e => e.Amount);
        SummaryData summaryData = new SummaryData
        {
            Year = year,
            TotalIncome = totalIncome,
            TotalExpenses = totalExpenses,
            CreditHold = creditHold
        };

        var sqlData = _sqlController.GetBy<SummarySQLData>(s => s.Year == year);
        if (sqlData == null)
        {
            AddSummary(summaryData);
        }
        else
        {
            UpdateSummary(summaryData);
        }
    }

    public CategorySectionData GetCategorySectionById(int categorySectionId)
    {
        var sqlData = _sqlController.GetById<CategorySectionSQLData>(categorySectionId);
        var categorySection = new CategorySectionData(sqlData);

        return categorySection;
    }

    public CategoryData GetCategoryById(int categoryId)
    {
        var sqlData = _sqlController.GetById<CategorySQLData>(categoryId);
        var category = new CategoryData(sqlData);

        return category;
    }

    public TypeData GetTypeById(int typeId)
    {
        var sqlData = _sqlController.GetById<TypeSQLData>(typeId);
        var typeData = new TypeData(sqlData);

        return typeData;
    }

    public List<TypeData> GetAllTypes()
    {
        var types = new List<TypeData>();
        var data = _sqlController.GetAll<TypeSQLData>();
        foreach (var sqlData in data)
        {
            var type = new TypeData(sqlData);
            types.Add(type);
        }

        return types;
    }

    public List<CategoryData> GetAllCategories()
    {
        var categories = new List<CategoryData>();
        var data = _sqlController.GetAll<CategorySQLData>();
        foreach (var sqlData in data)
        {
            var category = new CategoryData(sqlData);
            categories.Add(category);
        }

        return categories;
    }
}