using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationsConfiguration 
        : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if(context.Topics.CountAsync().Result == 0)
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
        }
    }
}