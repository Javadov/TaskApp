using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskApp.Contexts;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;

namespace TaskApp.Services
{
    internal class DataService
    {
        private static DataContext context = new DataContext();

        public async Task SaveIssueAsync(IssueEntity issueEntity)
        {
            context.Issues.Add(issueEntity);
            await context.SaveChangesAsync();
        }

        public async Task<int> IssuesAsync(ContactEntity contactEntity)
        {
            context.Contacts.Add(contactEntity);
            await context.SaveChangesAsync();
            return contactEntity.Id;
        }

        public static ObservableCollection<Issue> Issues { get; set; } = new ObservableCollection<Issue>();

        public static async Task<IEnumerable<Issue>> GetAllAsync()
        {

            var issues = new List<Issue>();

            foreach (var issue in await context.Issue.ToListAsync())
                issues.Add(new Issue { FirstName = issue.FirstName, LastName = issue.LastName, Email = issue.Email, PhoneNumber = issue.PhoneNumber, Topic = issue.Topic, Description = issue.Description, Status = issue.Status, Comment = issue.Comment });

            return issues;
        }

        public async Task GetAll()
        {
            var result = await context.Issue.ToListAsync();

            if (result != null)
            {
                ObservableCollection<Issue> issues = new ObservableCollection<Issue>();

                foreach (var issue in result)
                {
                    Issue eReport = new Issue()
                    { FirstName = issue.FirstName, LastName = issue.LastName, Email = issue.Email, PhoneNumber = issue.PhoneNumber, Topic = issue.Topic, Description = issue.Description, Status = issue.Status, Comment = issue.Comment };
                    issues.Add(eReport);
                }

                Issues = issues;
            }
        }


        //        public static ObservableCollection<Issue> issues { get; set; } = new ObservableCollection<Issue>();
        //
        //        public static ObservableCollection<Issue> Issues()
        //        {
        //            var items = new ObservableCollection<Issue>();
        //            foreach (var issue in issues)
        //                items.Add(new Issue { FirstName = issue.FirstName , LastName = issue.LastName, Email = issue.Email, PhoneNumber = issue.PhoneNumber, Topic = issue.Topic, Description = issue.Description, Status = issue.Status, Comment = issue.Comment });
        //            return items;
        //        }
    }
}