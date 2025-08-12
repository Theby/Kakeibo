using System;
using SQLite;

[Table("Types")]
public record TypeSQLData(
    int Id,
    bool Enabled,
    long InputDate,
    [property: Column("name")] string Name) : SQLiteData(Id, Enabled, InputDate)
{
    public TypeSQLData() : this(0, true, DateTime.Now.Ticks, string.Empty){}
}