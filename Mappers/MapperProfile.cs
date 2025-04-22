using System;
using AutoMapper;
using BloggerBits.Entities;
using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Auth.Request;
using BloggerBits.Entities.Auth;
using BloggerBits.DTOS.Auth.Response;

namespace BloggerBits.Mappers;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<ContentRequest,Content>();
        CreateMap<RegistrationRequest, User>();
        CreateMap<User,LoginResponse>();
    }

}
