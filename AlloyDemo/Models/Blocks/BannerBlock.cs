using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.Blocks
{
    [SiteContentType(GUID = "3a643215-548a-42c7-8496-aca7ef0cb29f")]
    [SiteImageUrl]
    public class BannerBlock : SiteBlockData
    {
        [Display(
                GroupName = SystemTabNames.Content,
                Order = 1
                )]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackGroundImage { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 2
           )]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Logo { get; set; }


        [Display(Order = 3, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string Heading { get; set; }


        [Display(Order = 4, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ShortDescription { get; set; }

        [Display(Order = 5, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ButtonText { get; set; }


        [Display(Order = 6, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual Url ButtonLink { get; set; }
    }
}
