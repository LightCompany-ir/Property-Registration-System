using System.Globalization;

namespace OtaghMazandaran
{
    public static class DateConverter
    {
        public static string ToShamsi(this DateTime val)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}", pc.GetYear(val),
                pc.GetMonth(val), pc.GetDayOfMonth(val), val.Hour, val.Minute, val.Second);
        }
        public static string ToShamsiString(this DateTime val)
        {
            string[] month = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0:0000} {1} {2:00}", pc.GetYear(val),
                month[pc.GetMonth(val) - 1], pc.GetDayOfMonth(val));
        }
    }
}
