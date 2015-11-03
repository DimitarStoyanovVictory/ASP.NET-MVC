namespace Twitter.Web.Infrastructure.Mapping
{
    using AutoMapper;

    public interface ICustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}