using AlloyDemo.Models.ViewModels;
using EPiServer.ContentApi.Core.Serialization;

namespace AlloyDemo.Converter
{
    public class ListPropertyConvertorProvider : IPropertyConverterProvider
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListPropertyConvertorProvider"/> class.
        /// List property convertor provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ListPropertyConvertorProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// The provider which has higher order will be called first to see if it handles specified <see cref="PropertyData" /> type
        /// </summary>
        public int SortOrder => 1000;

        /// <summary>
        /// Determines if provider supports specified <paramref name="propertyData" /> type and if so returns a matching
        /// <see cref="IPropertyConverter" /> instance. If <paramref name="propertyData" /> is not supported return null
        /// </summary>
        /// <param name="propertyData">instance of <see /> to resolve <see /> for</param>
        /// <returns>A matching <see /> or null if <paramref name="propertyData" /> is not supported by the provider</returns>
        public IPropertyConverter Resolve(PropertyData propertyData)
        {
            return propertyData switch
            {
                PropertyList<TestimonialDetailModel> => _serviceProvider.GetService<TestimonialItemListPropertyConvertor>(),
                _ => null,
            };
        }
    }
}
