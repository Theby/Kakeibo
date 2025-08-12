using System;

public class CategorySectionData
{
    public string Name { get; set; }
    public int SQLId => _sqlData.Id;

    CategorySectionSQLData _sqlData;

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
        _sqlData = new CategorySectionSQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Name);

        return _sqlData;
    }
}
