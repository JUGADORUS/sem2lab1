using DataAccessLayer;
using Model;
using Ninject;

namespace BusinesssLogic
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel(bool useEntityFramework)
        {
            IKernel kernel = new StandardKernel();

            if (useEntityFramework)
            {
                kernel.Bind<IRepository<DrugBuyer>>().To<EntityRepository<DrugBuyer>>().InSingletonScope();
            }
            else
            {
                kernel.Bind<IRepository<DrugBuyer>>().To<DapperRepository>().InSingletonScope();
            }

            kernel.Bind<DrugLaboratory>().ToSelf();
            kernel.Bind<DrugStatisticsService>().ToSelf();

            return kernel;
        }
    }
}
