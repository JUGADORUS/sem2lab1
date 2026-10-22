using DataAccessLayer;
using Model;
using Ninject.Modules;

namespace BusinesssLogic
{
    public class DapperConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<DrugBuyer>>().To<DapperRepository>().InSingletonScope();
        }
    }
}
