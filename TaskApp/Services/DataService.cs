using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;

namespace TaskApp.Services
{
    internal class DataService
    {
        private readonly string _connectionString = @"Data Source=javadov.database.windows.net;Initial Catalog=azure_db;User ID=SqlAdmin;Password=BytMig123!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public async Task SaveIssueAsync(IssueEntity issueEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("IF NOT EXISTS (SELECT Id FROM Issues WHERE Topic = @Topic) INSERT INTO Issues VALUES (@Topic, @Description, @Status, @ContactId)", issueEntity);
        }

        public async Task<int> IssuesAsync(ContactEntity contactEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>("IF NOT EXISTS (SELECT Id FROM Contacts WHERE Email = @Email) INSERT INTO Contacts OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @PhoneNumber) ELSE SELECT ID FROM Contacts WHERE Email = @Email", contactEntity);
        }


        // public async Task<int> CommentsAsync(CommentEntity commentEntity)
        // {
        //     using var conn = new SqlConnection(_connectionString);
        //     return await conn.ExecuteScalarAsync<int>("IF NOT EXISTS (SELECT Id FROM Comments WHERE Topic = @Topic) INSERT INTO Comments INSERTED.Id VALUES (@Topic, @Description, @Status, @CommentId) ELSE SELECT ID FROM Issues WHERE Topic = @Topic AND Description = @Description AND Status = @Status", issueEntity);
        // }

        public async Task<IEnumerable<Issue>> GetAllIssuesAsync()
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.QueryAsync<Issue>("SELECT c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber, i.Topic, i.Description, i.Status FROM Contacts c JOIN Issues i ON i.ContactId = c.Id");
        }
    }
}