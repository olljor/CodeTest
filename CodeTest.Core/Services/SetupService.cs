using CodeTest.Infrastructure.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Core.Services;
public class SetupService(IDbConnection connection)
{
    private readonly IDbConnection _connection = connection;

    public async Task RunDatabaseSetupScript()
    {
        await _connection.ExecuteAsync(SetupRepository.BaseSetupScript);
    }
}
