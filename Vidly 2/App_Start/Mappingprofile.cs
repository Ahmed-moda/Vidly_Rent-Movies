using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly_2.Models;
using Vidly_2.tmp;

namespace Vidly_2.App_Start
{
    public class Mappingprofile:Profile
    {
        public Mappingprofile()
        {
            Mapper.CreateMap<Customer, tmpcustomer>();
            Mapper.CreateMap<tmpcustomer, Customer>();


            Mapper.CreateMap<Movie, tmpmovie>();
            Mapper.CreateMap<tmpmovie, Movie>();


            Mapper.CreateMap<Membership, tmpmembership>();
            Mapper.CreateMap<tmpmembership, Membership>();

            Mapper.CreateMap<Genre, tmpgenre>();
            Mapper.CreateMap<tmpgenre, Genre>();

            Mapper.CreateMap<List<Customer>, List<tmpcustomer>>();
            Mapper.CreateMap<List<Movie>, List<tmpmovie>>();

        }

    }
}