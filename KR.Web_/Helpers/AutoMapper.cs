using AutoMapper;
using KR.Business.Entities;
using KR.DbEF;
using System.Collections.Generic;

namespace KR.Web_.Helpers
{
    public class AutoMapper
    {
        public static void Init()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, customer>().ForMember(x => x.land, opt => opt.Ignore());
                config.CreateMap<List<Customer>, List<customer>>();


                config.CreateMap<Designer, designer>().ForMember(x => x.zakaz, opt => opt.Ignore());
                config.CreateMap<List<Designer>, List<designer>>();


                config.CreateMap<Difficulties, difficulties>().ForMember(x => x.zakaz, opt => opt.Ignore());
                config.CreateMap<List<Difficulties>, List<difficulties>>();


                config.CreateMap<Work, work>().ForMember(x => x.zakaz, opt => opt.Ignore());
                config.CreateMap<List<Work>, List<work>>();


                config.CreateMap<Land, land>().ForMember(x => x.zakaz, opt => opt.Ignore())
                                              .ForMember(x => x.customer, opt => opt.Ignore());
                config.CreateMap<List<Land>, List<land>>();


                config.CreateMap<Zakaz, zakaz>().ForMember(x => x.designer, opt => opt.Ignore())
                                                     .ForMember(x => x.land, opt => opt.Ignore())
                                                     .ForMember(x => x.difficulties, opt => opt.Ignore())
                                                     .ForMember(x => x.work, opt => opt.Ignore());
                config.CreateMap<List<Zakaz>, List<zakaz>>();

                //config.CreateMap<Customer, customer>().ForMember(x => x.land, opt =>
                //opt.MapFrom(x => x.land));
            });
        }
    }
}