using DocumentFormat.OpenXml.Spreadsheet;
using HiddenBattleship.BL.Models;

namespace HiddenBattleship.MVC.UI.Models
{
    public class Authenticate
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            return context == null ? true : context.Session.GetObject<Player>("player") != null;
        }
    }
}
