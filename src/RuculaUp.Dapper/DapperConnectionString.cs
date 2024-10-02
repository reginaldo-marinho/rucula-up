using System;

namespace RuculaUp.Dapper;

public class DapperConnectionString(string stringConnection)
{
    public string StringConnection {get; private set;} = stringConnection;
}
