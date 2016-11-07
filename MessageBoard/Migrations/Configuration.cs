namespace MessageBoard.Migrations
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MessageBoardMigrationsConfiguration
        : DbMigrationsConfiguration<MessageBoard.Data.MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoard.Data.MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if (context.Topics.CountAsync().Result == 0)
            {
                var topic = new Topic()
                {
                    Title = "I like ASP.NET MVC",
                    Body = "It's making things easier",
                    Created = DateTime.UtcNow,
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "I love it too!",
                            Created = DateTime.Now
                        },
                         new Reply()
                        {
                            Body = "Me too!",
                            Created = DateTime.Now
                        },
                          new Reply()
                        {
                            Body = "Sucks",
                            Created = DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic);

                var anotherTopic = new Topic()
                {
                    Title = "I like Ruby too",
                    Body = "It's popular",
                    Created = DateTime.Now
                };

                context.Topics.Add(anotherTopic);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
            }
#endif
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
        }
    }
}
