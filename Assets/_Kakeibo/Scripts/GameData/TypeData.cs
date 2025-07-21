public class TypeData
{
    public string Name { get; set; }

    TypeSQLData _sqlData;
    public int SQLId => _sqlData.Id;

    public bool IsDebit => SQLId == 1;

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
        TypeSQLData typeSQLData = new TypeSQLData();
        if (_sqlData != null)
        {
            typeSQLData = _sqlData;
        }

        typeSQLData.Name = Name;

        return typeSQLData;
    }
}
