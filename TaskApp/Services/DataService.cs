using Dapper;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using TaskApp.Contexts;
using TaskApp.MVVM.Entities;
using TaskApp.MVVM.Models;

namespace TaskApp.Services
{
    internal class DataService
    {
        private static DataContext context = new DataContext();

        #region Save Issue
        public async Task SaveIssueAsync(IssueEntity issueEntity)
        {

            if (issueEntity == null || string.IsNullOrEmpty(issueEntity.Topic) || string.IsNullOrEmpty(issueEntity.Description))
            {
                MessageBox.Show("Fyll i alla obligatoriska fält.");
                return;
            }
            else
            {

                context.Issues.Add(issueEntity);
                await context.SaveChangesAsync();
            }
        }
        #endregion

        #region Check Contact
        public async Task<int> IssuesAsync(ContactEntity contactEntity)
        {
            if (contactEntity == null || string.IsNullOrEmpty(contactEntity.FirstName) || string.IsNullOrEmpty(contactEntity.LastName) || string.IsNullOrEmpty(contactEntity.Email))
            {
                MessageBox.Show("Fyll i alla obligatoriska fält.");
                return -1;
            }
            else
            {
                var contact = await context.Contacts.FirstOrDefaultAsync(x => x.Email == contactEntity.Email);

                if (contact != null)
                    return contact.Id;
                else
                    context.Contacts.Add(contactEntity);

                await context.SaveChangesAsync();
                return contactEntity.Id;
            }
        }
        #endregion


        #region Save PhoneNumber
        public async Task<int?> PhoneNumberAsync(PhoneNumberEntity phoneNumberEntity)
        {
            if (phoneNumberEntity.PhoneNumber == null)
            {
                return null;
            }

            else
            {
                var phoneNumber = await context.PhoneNumbers.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumberEntity.PhoneNumber);

                if (phoneNumber != null)
                    return phoneNumber.Id;
                else
                    context.PhoneNumbers.Add(phoneNumberEntity);
                await context.SaveChangesAsync();
                return phoneNumberEntity.Id;
            }
        }
        #endregion

        #region All Issues
        public static async Task<IEnumerable<Issue>> GetAllAsync()
        {

            var issues = new List<Issue>();

            foreach (var issue in await context.Issues
            .Include(c => c.Contact)
            .Include(c => c.Comments)
            .ToListAsync())
            {
                var comments = new List<Comment>();

                foreach (var comment in issue.Comments)
                {
                    comments.Add(new Comment
                    {
                        Id = comment.Id,
                        IssueId = comment.IssueId,
                        _Comment = comment.Comment,
                        DateTime = comment.DateTime
                    });
                }

                issues.Add(new Issue
                {
                    Id = issue.Id,
                    ContactId = issue.ContactId,
                    FirstName = issue.Contact.FirstName,
                    LastName = issue.Contact.LastName,
                    Email = issue.Contact.Email,
                    PhoneNumber = issue.Contact.PhoneNumber,
                    Topic = issue.Topic,
                    Description = issue.Description,
                    Status = issue.Status,
                    DateTime = issue.DateTime,
                    Comments = comments
                });
            }

            return issues;
        }
        #endregion

        #region Get Specific Issue
        public static async Task<IEnumerable<Issue>> GetAsync(string email)
        {
            var selectedIssues = await context.Issues
                .Include(x => x.Contact)
                .Where(x => x.Contact.Email == email)
                .Select(x => new Issue
                {
                    FirstName = x.Contact.FirstName,
                    LastName = x.Contact.LastName,
                    Email = x.Contact.Email,
                    PhoneNumber = x.Contact.PhoneNumber,
                    Topic = x.Topic,
                    Description = x.Description,
                    Status = x.Status,
                    DateTime = x.DateTime
                })
                .ToListAsync();

            return selectedIssues;
        }
        #endregion

        #region Update Issue
        public static async Task UpdateAsync(Issue issue)
        {
            var selectedIssue = await context.Issues.FirstOrDefaultAsync(x => x.Topic == issue.Topic);

            if (selectedIssue != null) 
            { 
                selectedIssue.Status = issue.Status;
            }

            context.Update(selectedIssue);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Delete Issue
        public static async Task DeleteAsync(Issue issue)
        {
            var selectedIssue = await context.Issues.FirstOrDefaultAsync(x => x.Id == issue.Id);
            if (selectedIssue != null)
            {
                context.Remove(selectedIssue);
            }

            await context.SaveChangesAsync();
        }
        #endregion

        #region Save Comment
        public async Task SaveCommentAsync(CommentEntity commentEntity)
        {
            context.Comments.Add(commentEntity);
            await context.SaveChangesAsync();
        }
        #endregion

        #region Get Comments

        #endregion

        #region Delete Comment
        public static async Task DeleteCommentAsync(Comment comment)
        {
            var selectedComment = await context.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id);
            if (selectedComment != null)
            {
                context.Remove(selectedComment);
            }

            await context.SaveChangesAsync();
        }
        #endregion
    }
}