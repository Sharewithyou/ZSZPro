using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.Model.Models;
using ZSZ.Model.Models.DTO;

namespace ZSZ.AdminWeb.Config.AutoMapDir
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        {         
            base.CreateMap<T_AdminUsers, AdminUser>();

            base.CreateMap<AdminUser, T_AdminUsers>();
        }
    }
}