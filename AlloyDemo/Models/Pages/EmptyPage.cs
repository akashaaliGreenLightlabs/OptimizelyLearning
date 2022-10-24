namespace AlloyDemo.Models.Pages
{

    [SiteContentType(
    GUID = "c60308c5-7913-4329-b006-2b3cf65290be",
    GroupName = Globals.GroupNames.Empty)]
    //[SiteImageUrl(Globals.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    [AvailableContentTypes(
    Availability = Availability.Specific,
    IncludeOn = new[] { typeof(StartPage) })]
    public class EmptyPage : StandardPage
    {
    }
}
