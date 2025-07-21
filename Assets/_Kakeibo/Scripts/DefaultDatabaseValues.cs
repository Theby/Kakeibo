using System.Collections.Generic;

public static class DefaultDatabaseValues
{
    public static readonly string[] DefaultTypes = {
        "Debit",
        "Credit Santander",
        "Credit Itau"
    };
    public static readonly Dictionary<string, List<string>> DefaultCategories = new()
    {
        { "Personal",
            new List<string>
            {
                "Personal"
            } },
        { "Salary Discount",
            new List<string>
            {
                "Health Insurance",
                "Invoice",
                "Rent Tax",
            } },
        { "Housing",
            new List<string>
            {
                "Algarrobo Mortgage",
                "Light",
                "Water",
                "Condominium Fees",
                "San Joaquín Appt. Tax"
            } },
        { "Basics",
            new List<string>
            {
                "Super Market",
                "Filtered Water",
                "Internet Service",
                "Phone Service",
                "Cats",
                "Santander Taxes",
                "Itau Taxes",
                "METLIFE payments",
            } },
        { "Entertainment",
            new List<string>
            {
                "Spotify",
                "Chrunchyroll",
                "Uber One",
                "Abroad in Japan Patreon",
                "Excercise/Gym",
                "Cleaning Service",
                "Therapy",
            } },
        { "Savings",
            new List<string>
            {
                "METLIFE savings",
                "Holiday savings",
                "Car savings",
                "House savings",
                "APV savings",
                "Emergency savings",
            } },
        { "Additional Expenses",
            new List<string>
            {
                "Medicine",
                "Cloths",
                "Public Transport",
                "Others",
            } },
        { "Additional Savings",
            new List<string>
            {
                "BTC savings",
                "ETH savings",
                "Santander savings",
                "Itau savings",
            } },
    };
    public static readonly CurrencyData[] DefaultCurrencyData = {
        new()
        {
            Name = "Chilean Peso",
            ShortName = "CLP",
            Symbol = "$",
            Format = "0",
        },
        new()
        {
            Name = "US Dollar",
            ShortName = "USD",
            Symbol = "$",
            Format = "0,00",
        },
    };
}