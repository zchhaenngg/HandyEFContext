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
            using (var context = new MyContext())
            {
                var entity = new hy_user
                {
                    id = Guid.NewGuid().ToString(),
                    is_locked = false,
                    access_failed_times = 0,
                    name = "test1"
                };
                entity.hy_auth_roles.Add(new hy_auth_role
                {
                    id = Guid.NewGuid().ToString(),
                    name = "test1 role"
                });
                context.Add(entity);
                var t = context.SaveChangesAsync();
                t.Wait();
            }
        }

        [TestMethod]
        public void SaveChangesAsync()
        {
            try
            {
                Task.Factory.StartNew(() => 
                {
                    TaskStart(() =>
                    {
                        throw new ArgumentOutOfRangeException("xxx");
                    });
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void TaskStart(Action action)
        {
            var tsk = Task.Factory.StartNew(action);
            tsk.Wait();
        }
    }
}
