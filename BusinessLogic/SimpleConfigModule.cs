using DataAccessLayer;
using Model;
using Ninject.Modules;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        private bool _isEntityFramework = true;

        /// <summary> Модуль конфигурации Ninject для настройки внедрения зависимостей через выбранный ORM.
        /// Связывает интерфейс репозитория с его реализацией на основе выбраннанного ORM в режиме Singleton.
        /// </summary>
        public override void Load()
        {
            if (_isEntityFramework)
            {
                Bind<IRepository<DrugBuyer>>().To<EntityRepository<DrugBuyer>>().InSingletonScope();
            }
            else
            {
                Bind<IRepository<DrugBuyer>>().To<DapperRepository>().InSingletonScope();
            }

            Bind<DrugStatisticsService>().ToSelf();
            Bind<IDrugLaboratory>().To<DrugLaboratory>();
        }

        /*
         * Диалог в хрущевке:
        — Пап, а кто твой любимый персонаж в аниме?
        — Тот мужик из «Атаки титанов».
        — Леви? Эрен?
        — Да нет, тот облысевший из гарнизона, который весь первый сезон сидел на стене, пил из фляги и жаловался на маленькую зарплату. 
        Вот это я понимаю, прописанный персонаж! 
        */
    }
}   
