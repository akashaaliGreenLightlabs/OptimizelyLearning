using EPiServer.Cms.Shell.Json.Internal;
using EPiServer.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlloyDemo.Models.ViewModels
{
    public class TestimonialDetailModel
    {
        [Display(Order = 1, GroupName = SystemTabNames.Content)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        
        public virtual ContentReference PersonImage { get; set; }

        [Display(Order = 2, GroupName = SystemTabNames.Content)]
       

        public virtual string PersonName { get; set; }


        [Display(Order = 3, GroupName = SystemTabNames.Content)]
        

        public virtual string Heading { get; set; }

        [Display(Order = 4, GroupName = SystemTabNames.Content)]
        
        public virtual string ShortDescription { get; set; }
    }
}
