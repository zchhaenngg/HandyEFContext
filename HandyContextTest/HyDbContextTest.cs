using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HandyContextTest
{
    [TestClass]
    public class HyDbContextTest
    {
        void add()
        {
            using (var context = new MyContext { LoginId = "-1" })
            {
                context.LogEvent = new Handy.EF.Model.Entity.LogEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedTime = DateTime.UtcNow,
                    CreatedById = context.LoginId,
                    EventType = new Handy.EF.Model.System.LogEventType
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "unitTest",
                        CreatedTime = DateTime.UtcNow,
                        LastModifiedTime = DateTime.UtcNow
                    }
                };
                var entity = new hy_user
                {
                    Id = Guid.NewGuid().ToString(),
                    is_locked = false,
                    access_failed_times = 0,
                    name = "test1"
                };
                entity.hy_auth_roles.Add(new hy_auth_role
                {
                    Id = Guid.NewGuid().ToString(),
                    name = "test1 role"
                });
                context.Add(entity);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void SaveChangesAsync()
        {
            try
            {
                add();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
