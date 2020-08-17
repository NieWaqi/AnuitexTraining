﻿using AnuitexTraining.BusinessLogicLayer.Services;
using AnuitexTraining.BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AnuitexTraining.BusinessLogicLayer
{
    public static class Startup
    {
        public static void InitBusinessLogicLayerServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            DataAccessLayer.Startup.InitDataAccessLayerServices(services);
        }
    }
}