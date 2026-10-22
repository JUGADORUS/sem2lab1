using DataAccessLayer;
using Model;
using Ninject.Modules;

namespace BusinesssLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<DrugBuyer>>().To<EntityRepository<DrugBuyer>>().InSingletonScope();
        }
    }
}
