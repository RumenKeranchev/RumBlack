using AutoMapper;

namespace RB.Common.Mapper
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}