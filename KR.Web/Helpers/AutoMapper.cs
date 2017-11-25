using AutoMapper;
using KR.Business.Entities;
using KR.DbEF;
using System.Collections.Generic;

namespace KR.Web.Helpers
{
    public class AutoMapper
    {
        public static void Init()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, customer>().ForMember(x => x.land, opt => opt.Ignore()); ;
                config.CreateMap<List<customer>, List<Customer>>();
            });
        }
    }
}