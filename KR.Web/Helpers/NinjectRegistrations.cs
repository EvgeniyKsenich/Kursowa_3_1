using KR.Business.Entities;
using KR.Business.Repositories;
using KR.DbEF.Repositories;
using Ninject.Modules;

namespace KR.Web.Helpers
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDesigner<Designer>>().To<DesignerRepositories>();
        }
    }
}