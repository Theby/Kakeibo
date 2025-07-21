public class CategorySectionData
{
    public string Name { get; set; }

    CategorySectionSQLData _sqlData;
    public int SQLId => _sqlData.Id;

    public CategorySectionData()
    {
        _sqlData = null;
    }

    public CategorySectionData(CategorySectionSQLData sqlData)
    {
        _sqlData = sqlData;

        Name = _sqlData.Name;
    }

    public CategorySectionSQLData ToSQLData()
    {
        CategorySectionSQLData categorySectionSQLData = new CategorySectionSQLData();
        if (_sqlData != null)
        {
            categorySectionSQLData = _sqlData;
        }

        categorySectionSQLData.Name = Name;

        return categorySectionSQLData;
    }
}
