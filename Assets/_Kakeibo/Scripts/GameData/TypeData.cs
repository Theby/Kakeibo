using System;

public class TypeData
{
    public string Name { get; set; }
    public int SQLId => _sqlData.Id;
    public bool IsDebit => SQLId == 1;

    TypeSQLData _sqlData;

    public TypeData()
    {
        _sqlData = null;
    }

    public TypeData(TypeSQLData sqlData)
    {
        _sqlData = sqlData;

        Name = _sqlData.Name;
    }

    public TypeSQLData ToSQLData()
    {
        _sqlData = new TypeSQLData(
            _sqlData?.Id ?? 0,
            _sqlData?.Enabled ?? true,
            _sqlData?.InputDate ?? DateTime.Now.Ticks,
            Name
        );

        return _sqlData;
    }
}
