using AlloyDemo.Models.Property;
using AlloyDemo.Models.ViewModels;
using EPiServer.ContentApi.Core.Serialization;

namespace AlloyDemo.Converter
{
    public class TestimonialItemListPropertyConvertor : IPropertyConverter
    {
        public IPropertyModel Convert(PropertyData propertyData, ConverterContext contentMappingContext)
        {
            return new TestimonialItemPropertyModel((PropertyList<TestimonialDetailModel>)propertyData);
        }
    }
}
