using System;
using AutoMapper;
using BloggerBits.Entities;
using BloggerBits.Models.Request;

namespace BloggerBits.Mappers;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<ContentRequest,Content>();
    }

}
