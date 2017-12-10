using KR.Business.Entities;
using KR.Business.Reports;
using System.Collections.Generic;


namespace KR.Business.Repositories
{
    public interface IZakazInfo<T, S>
    {
        IEnumerable<T> GetList();

        IEnumerable<T> GetList(List<S> zakaz);

        IEnumerable<T> GetList(string nameDesigner, string surnameDesigner,
                              string nameCustomer, string surnameCustomer, string price,
                              string startDate, string endDate);

        T GetbyId(int id);

        T Delete(int id);

        OrderReport GetReport(int id);

        OrderCommonDate GetOrderReport(string time);

        OrderExtraReport GetExtraReport(int time, int size);
    }
}