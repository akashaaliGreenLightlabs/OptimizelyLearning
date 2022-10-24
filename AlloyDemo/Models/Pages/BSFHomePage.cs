using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.Pages
{
    [ContentType(
      GUID = "73a17bfd-1616-4f20-b3a4-428c4d54359b",
      GroupName = Globals.GroupNames.BSFHome)]
    [AvailableContentTypes(
    Availability.Specific,
    IncludeOn = new[] { typeof(StartPage) })
        ]
    public class BSFHomePage : PageData
    {
        [Display(
      GroupName = SystemTabNames.Content,
      Order = 320)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}
