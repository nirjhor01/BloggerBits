using System;
using AutoMapper;
using BloggerBits.Entities;
using BloggerBits.DTOS.Requests;
using BloggerBits.DTOS.Auth.Request;
using BloggerBits.Entities.Auth;
using BloggerBits.DTOS.Auth.Response;
using BloggerBits.DTOS.Responses.Contents;

namespace BloggerBits.Mappers;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        //Content
        CreateMap<ContentRequest,Content>();
        CreateMap<Content, ContentResponse>();

        //Auth
        CreateMap<RegistrationRequest, User>();
        CreateMap<User,LoginResponse>();
    }

}
