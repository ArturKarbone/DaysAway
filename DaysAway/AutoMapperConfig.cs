using AutoMapper;
using DaysAway.DataModel;
using DaysAway.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
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
           // Mapper.Configuration.ConstructServicesUsing(ServiceLocator.Current.GetInstance);           
            Mapper.Configuration.ConstructServicesUsing(x => ServiceLocator.Current.GetInstance(x,Guid.NewGuid().ToString()));            
            
            Mapper.CreateMap<Commitment, CommitmentViewModel>()
                .ConstructUsingServiceLocator();
                   
            Mapper.CreateMap<CommitmentViewModel, Commitment>();
        }
    }
}
