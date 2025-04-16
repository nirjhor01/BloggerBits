using System;
using AutoMapper;
using BloggerBits.Entities;
using BloggerBits.DTOS.Requests;

namespace BloggerBits.Mappers;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<ContentRequest,Content>();
    }

}
