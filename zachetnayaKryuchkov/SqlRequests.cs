

namespace zachetnayaKryuchkov
{
    static class SqlRequests
    {
        public static string AllTovar()
        {
            string request = "select * from tovar";
            return request;
        }

        public static string ALlSotrudniki()
        {
            string request = "select * from sotrudnik";
            return request;
        }

        public static string AllPostavshiki()
        {
            string request = "select * from postavshik";
            return request;
        }

        public static string Sklad()
        {
            string request = "select * from sklad";
            return request;
        }

        public static string BD1()
        {
            string request = "select TOVAR.kt, NaimT,naimp from TOVAR" +
                            " inner join SKLAD on SKLAD.KT = TOVAR.KT" +
                            " inner join POSTAVSHIK on POSTAVSHIK.KP = SKLAD.Kp";
            return request;
        }

        public static string BD2()
        {
            string request = "select kt, NaimT, fam from TOVAR as t "+
                "inner join SKLAD on SKLAD.KT = t.KT " +
                "inner join SOTRUDNIK on SOTRUDNIK.Ks = SKLAD.KS " +
                "where DataR in (" +
                "select Min(DataR) from TOVAR " +
                "inner join SKLAD on SKLAD.KT = TOVAR.KT " +
                "inner join SOTRUDNIK on SOTRUDNIK.Ks = SKLAD.KS " +
                "where TOVAR.NaimT = t.NaimT " +
                ") " +
                "group by naimT, Fam";

            return request;
        }

        public static string BD3()
        {
            string request = "select distinct naimT from tovar " +
                "inner join SKLAD on Sklad.KT = tovar.kt " +
                "where dateadd(DAY, srg, datap)< GETDATE() " +
                "group by naimt";

            return request;
        }

        public static string BD4()
        {
            string request = "select naimT, sum(obiem) as [объем] from SKLAD " +
                "inner join Tovar on tovar.kt = sklad.kt " +
                "group by naimt " +
                "having sum(obiem) = (select max(t.x) from(select sum(obiem) as x from SKLAD " +
                "inner join Tovar on tovar.kt = sklad.kt " +
                "group by naimt) as t) ";

            return request;
        }

        public static string BD5()
        {
            string request = "select KS, fam ,im ,otch, " +
                "(select count(KS) from SKLAD " +
                "where SKLAD.KS = SOTRUDNIK.KS and month(datap) = month(getdate())) as kol_vo " +
                "from SOTRUDNIK " +
                "order by kol_vo desc";

            return request;
        }

        public static string BD6()
        {
            string request = "select kp, naimP,sum(stoim)as vsego from SKLAD as c " +
                "join POSTAVSHIK on POSTAVSHIK.KP=c.KP " +
                "where Month(datap) = MONTH(Getdate()) " +
                "group by naimp ";

            return request;
        }

        public static string BD7()
        {
            string request = "select naimp, count(SKLAD.KP) as [всего поставок], sum(obiem) as [объем], sum(Stoim) as [на сумму] from SKLAD" +
                " inner join Postavshik on Postavshik.KP = SKLAD.KP" +
                " group by naimp";

            return request;
        }

        public static string BD8()
        {
            string request = "select datap, naimt, naimP from Sklad  inner join Tovar on TOvar.KT = SKLAD.KT inner join POSTAVSHIK on POSTAVSHIK.KP = SKLAD.KP";

            return request;
        }
    }
}
