using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.Blocks
{
    [SiteContentType(GUID = "1f5f7ecf-91e0-4a58-879d-ebaa02536f51")]
    [SiteImageUrl]
    public class TextWithButtonBlock : SiteBlockData
    {

        [Display(Order = 1, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string Heading { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string SubHeading { get; set; }


        [Display(Order = 3, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ShortDescription { get; set; }

        [Display(Order = 4, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ButtonText { get; set; }


        [Display(Order = 5, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual Url ButtonLink { get; set; }
    }
}
