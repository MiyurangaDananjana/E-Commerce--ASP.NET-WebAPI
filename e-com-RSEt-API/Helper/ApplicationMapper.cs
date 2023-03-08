using AutoMapper;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ComputerManufacturer, ComputerManufacturer>();
        }
    }
}
