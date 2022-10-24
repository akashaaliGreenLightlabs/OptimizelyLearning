using AlloyDemo.Models.ViewModels;
using EPiServer.Framework.Serialization;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;

namespace AlloyDemo.Models.Property
{
    [PropertyDefinitionTypePlugIn]
    
    public class TestimonialProperty : PropertyList<TestimonialDetailModel> 
    {

        public TestimonialProperty()
        {
            _objectSerializer = _objectSerializerFactory.Service.GetSerializer(KnownContentTypes.Json);
        }

        private Injected<IObjectSerializerFactory> _objectSerializerFactory;

        private readonly IObjectSerializer _objectSerializer;

        protected override TestimonialDetailModel ParseItem(string value) => _objectSerializer.Deserialize<TestimonialDetailModel>(value);



    }


}
