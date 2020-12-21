// ReSharper disable VirtualMemberCallInConstructor
namespace TimeBox.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using TimeBox.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.PlannedTasks = new HashSet<PlannedTask>();
            this.Notes = new HashSet<Note>();
            this.BlogPosts = new HashSet<BlogPost>();
        }

        public string Name { get; set; }

        public virtual ICollection<PlannedTask> PlannedTasks { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
