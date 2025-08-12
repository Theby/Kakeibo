using System;
using SQLite;

public record SQLiteData(
    [property: PrimaryKey, AutoIncrement, Column("id")] int Id,
    [property: Column("enabled")] bool Enabled,
    [property: Column("input_date")] long InputDate)
{
    public SQLiteData() : this(0, true, DateTime.Now.Ticks){}
}