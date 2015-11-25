namespace Phase2Nandoso.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Phase2Nandoso.DAL.NandosoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Phase2Nandoso.DAL.NandosoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var employees = new List<Models.Employee> {
                new Models.Employee { EmployeeName = "Xizhe Qiu" },
                new Models.Employee { EmployeeName = "Vicky Liu" }
            };
            employees.ForEach(e => context.Employees.AddOrUpdate(p => p.EmployeeName, e));
            context.SaveChanges();

            var feedbacks = new List<Models.Feedback> {
                new Models.Feedback { CustomerName = "Andrew Nguyen", Comment = "That flame-chicken tastes and look so damn good!"},
                new Models.Feedback { CustomerName = "Anirudh Krishnamurthy", Comment = "The manager's not very friendly"}
                };
            feedbacks.ForEach(f => context.Feedbacks.AddOrUpdate(f));
            context.SaveChanges();

            var specials = new List<Models.Special> {
                new Models.Special { Dish = "Flame Grilled Whole Chicken", Price = 30 },
                new Models.Special { Dish = "10 KFC drumsticks but Better", Price = 20 }
            };
            specials.ForEach(s => context.Specials.AddOrUpdate(p => p.Dish, s));
            context.SaveChanges();

            var replies = new List<Models.Reply> {
                new Models.Reply{
                    EmployeeID = context.Employees.Single(e => e.EmployeeName == "Xizhe Qiu").ID,
                    FeedbackID = context.Feedbacks.Single(f => f.CustomerName == "Andrew Nguyen").ID,
                    Content = "Thank you for your feedback :)"
                }
            };
            foreach(Models.Reply r in replies)
            {
                var replyInDatabase = context.Replys.Where(
                    s => s.Employee.ID == r.EmployeeID &&
                         s.Feedback.ID == r.FeedbackID).SingleOrDefault();
                if (replyInDatabase == null)
                {
                    context.Replys.Add(r);
                }
            }

           context.SaveChanges();
        }
    }
}
