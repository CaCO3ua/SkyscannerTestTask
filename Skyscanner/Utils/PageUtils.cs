namespace Skyscanner.Utils
{
    class PageUtils
    {
        public static void NavigateTo(string url)
        {
            DriverUtils.GetDriver().Navigate().GoToUrl(url);
        }
    }
}
