using AutoMapper;
using DaysAway.DataModel;
using DaysAway.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysAway
{
    class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Commitment, CommitmentViewModel>();
            Mapper.CreateMap<CommitmentViewModel, Commitment>();

        }
    }
}
