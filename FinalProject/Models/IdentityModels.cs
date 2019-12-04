﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.Enums;
using FinalProject.Models.TicketyModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        [MaxLength(10)]
        public virtual string Frist_Name { get; set; }
        
        public virtual string Last_Name { get; set; }
        public Gender gender { get; set; }
        public string ProfileImage { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<Match> Matches { get; set; }
        public System.Data.Entity.DbSet<Ticket> Tickets { get; set; }
        public System.Data.Entity.DbSet<Degree> Degrees { get; set; }
        public System.Data.Entity.DbSet<Staduim> Staduims { get; set; }
        public System.Data.Entity.DbSet<Team> Teams { get; set; }

        //public System.Data.Entity.DbSet<TicketProject.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}