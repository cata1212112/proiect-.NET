using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class Context : DbContext
    {
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostHasDescription> PostHasDescription { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<UserLikesPost> UserLikesPost { get; set; }
        public DbSet<UserCommentOnPost> UserCommentOnPost { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// 1:1 User Picture
            modelBuilder.Entity<ProfilePicture>()
                .HasOne(p => p.User)
                .WithOne(usr => usr.Picture)
                .HasForeignKey<User>(usr => usr.PictueID);
            /// 1:M User Post
            modelBuilder.Entity<User>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.User);

            /// M:N Post Descrption
            modelBuilder.Entity<PostHasDescription>()
                .HasKey(phd => new { phd.PostId, phd.DescriptionId });

            modelBuilder.Entity<PostHasDescription>()
                .HasOne<Post>(phd => phd.Post)
                .WithMany(post => post.PostHasDescriptionList)
                .HasForeignKey(phd => phd.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostHasDescription>()
                .HasOne(phd => phd.Description)
                .WithMany(desc => desc.PostHasDescriptionList)
                .HasForeignKey(phd => phd.DescriptionId)
                .OnDelete(DeleteBehavior.Restrict);


            /// M:N User Like Post
            modelBuilder.Entity<UserLikesPost>()
                .HasKey(ulp => new { ulp.UserId, ulp.PostId });

            modelBuilder.Entity<UserLikesPost>()
                .HasOne<User>(ulp => ulp.User)
                .WithMany(user => user.UserLikesPostList)
                .HasForeignKey(ulp => ulp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserLikesPost>()
                .HasOne<Post>(ulp => ulp.Post)
                .WithMany(post => post.UserLikesPostList)
                .HasForeignKey(ulp => ulp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            /// M:N User comment Post

            modelBuilder.Entity<UserCommentOnPost>()
                .HasKey(ucp => new { ucp.UserId, ucp.PostId });

            modelBuilder.Entity<UserCommentOnPost>()
                .HasOne<User>(ucp => ucp.User)
                .WithMany(user => user.UserCommentOnPostList)
                .HasForeignKey(ucp => ucp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCommentOnPost>()
                .HasOne<Post>(ucp => ucp.Post)
                .WithMany(post => post.UserCommentOnPostList)
                .HasForeignKey(ucp => ucp.PostId)
                .OnDelete(DeleteBehavior.Restrict);
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
