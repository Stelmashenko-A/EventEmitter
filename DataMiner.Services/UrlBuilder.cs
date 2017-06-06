namespace DataMiner.Services
{
    public class UrlBuilder
    {
        protected const string Template = "https://www.eventbrite.com/directory/json?page={0}&cat=&subcat=&format=&q=&loc=Worldwide&date=&start_date=&end_date=&is_paid=&sort=best&crt=regular";
        protected int Page;

        public UrlBuilder()
        {
            Page = 84;
        }
        public string GetNext()
        {
            Page++;
            return string.Format(Template, Page);
        }
    }
}