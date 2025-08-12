using System;

public class CategoryData
{
    public string Name { get; set; }
    public CategorySectionData CategorySection { get; set; }
    public int SQLId => _sqlData.Id;

    CategorySQLData _sqlData;

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
        _sqlData = new CategorySQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Name,
            CategorySection.SQLId
        );

        return _sqlData;
    }
}
