public class CategoryData
{
    public string Name { get; set; }
    public CategorySectionData CategorySection { get; set; }

    CategorySQLData _sqlData;
    public int SQLId => _sqlData.Id;

    public CategoryData()
    {
        _sqlData = null;
    }

    public CategoryData(CategorySQLData sqlData)
    {
        _sqlData = sqlData;

        Name = _sqlData.Name;
        CategorySection = GameManager.KakeiboManager.GetCategorySectionById(_sqlData.SectionId);
    }

    public CategorySQLData ToSQLData()
    {
        CategorySQLData categorySQLData = new CategorySQLData();
        if (_sqlData != null)
        {
            categorySQLData = _sqlData;
        }

        categorySQLData.Name = Name;
        categorySQLData.SectionId = CategorySection.SQLId;

        return categorySQLData;
    }
}
