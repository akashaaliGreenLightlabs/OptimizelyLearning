using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.Blocks
{

    [SiteContentType(GUID = "141b83a7-8786-4595-a514-e744c215702a")]
    [SiteImageUrl]
    public class PromotionalBannerBlock  : SiteBlockData
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
        public virtual ContentReference MainImage { get; set; }


        [Display(Order = 3, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string Heading { get; set; }


        [Display(Order = 4, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string ShortDescription { get; set; }

        [Display(Order = 5, GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference PlayStoreButtonIcon { get; set; }


        [Display(Order = 6, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string PlayStoreButtonText { get; set; }


        [Display(Order = 7, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual Url PlayStoreButtonLink { get; set; }

        [Display(Order = 8, GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference AppStoreButtonIcon { get; set; }

        [Display(Order = 9, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string AppStoreButtonText { get; set; }


        [Display(Order = 10, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual Url AppStoreButtonLink { get; set; }
    }
}
