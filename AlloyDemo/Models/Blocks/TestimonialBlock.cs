using AlloyDemo.Converter;
using AlloyDemo.Models.ViewModels;
using EPiServer.Cms.Shell.Json.Internal;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace AlloyDemo.Models.Blocks
{

    [SiteContentType(GUID = "2770fe81-bdcc-4513-b5d5-22323f0df0ce")] // BEST PRACTICE TIP: Always assign a GUID explicitly when creating a new block type
    [SiteImageUrl] // Use site's default thumbnail
    public class TestimonialBlock  : SiteBlockData
    {
        [Display(Order = 1, GroupName = SystemTabNames.Content)]
        [Required]
        public virtual string Heading { get; set; }

        [Display(
               GroupName = SystemTabNames.Content,
               Order = 2
               )]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TestimonialDetailModel>))]
        public virtual IList<TestimonialDetailModel> TestimonialList { get; set; }
    }
}
