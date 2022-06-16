namespace CanteenCatering.Model
{
    public class WeeklyMenuModel
    {
        public string Day { get; set; }
        public string Soup { get; set; }
        public string MainDish { get; set; }

        public WeeklyMenuModel(string day, string soup, string mainDish)
        {
            Day = day;
            Soup = soup;
            MainDish = mainDish;
        }
    }
}
