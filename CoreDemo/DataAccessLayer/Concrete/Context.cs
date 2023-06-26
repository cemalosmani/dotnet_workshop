using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=CoreBlogDb;" +
                "Encrypt=false;TrustServerCertificate=True;" +
                "User Id=sa;Password=mZ0*Q&r2$8uF");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.AuthorSender)
                .HasForeignKey(z => z.MessageSenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.AuthorReceiver)
                .HasForeignKey(z => z.MessageReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
