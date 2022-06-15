﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public interface IInfoService
    {
        Task<IEnumerable<ClientItem>> GetTopClients();
        Task<IEnumerable<SdkItem>> GetSdks();
    }
}