using Microsoft.EntityFrameworkCore;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using System.Reflection;

namespace ExaminationSystem.API.VerticalSlicing.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationship in modelBuilder.Model
                                            .GetEntityTypes()
                                            .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Choise> Choises { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<StudentAnswerQuestion> studentAnswerQuestions { get; set; }



    }
}
