using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopigStore.Dto;
using ShopigStore.Model;

namespace ShopigStore.ProjectProfiles
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<UpdateUser,User>();
            CreateMap<UpdateItem,Item>();
            CreateMap<UpdateUserIntrust,User>();
        }
    }
}