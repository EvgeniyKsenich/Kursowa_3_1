using KR.Business.Entities;
using KR.Business.Reports;
using System.Collections.Generic;


namespace KR.Business.Repositories
{
    public interface IZakazInfo<T, S>
    {
        IEnumerable<T> GetList();

        IEnumerable<ZakazInfo> GetList(List<S> zakaz);

        IEnumerable<ZakazInfo> GetList(string nameDesigner, string surnameDesigner,
                              string nameCustomer, string surnameCustomer, string price,
                              string startDate, string endDate);

        ZakazInfo GetbyId(int id);

        ZakazInfo Delete(int id);

        OrderReport GetReport(int id);

        OrderCommonDate GetOrderReport(string time);
        

    }
}