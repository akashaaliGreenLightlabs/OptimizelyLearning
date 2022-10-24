using AlloyDemo.Models.ViewModels;
using EPiServer.ContentApi.Core.Serialization.Models;

namespace AlloyDemo.Models.Property
{
    public class TestimonialItemPropertyModel : PropertyModel<IEnumerable<TestimonialDetailModel>, PropertyList<TestimonialDetailModel>>
    {

        public TestimonialItemPropertyModel(PropertyList<TestimonialDetailModel> type)
          : base(type)
        {
            Value = GetValues(type.List);
        }

        private IEnumerable<TestimonialDetailModel> GetValues(IList<TestimonialDetailModel> items)
        {
            return items.Select(x => new TestimonialDetailModel
            {
                PersonImage = x.PersonImage,
                PersonName = x.PersonName,
                Heading = x.Heading,
                ShortDescription = x.ShortDescription
                
            });
        }

    }
}
