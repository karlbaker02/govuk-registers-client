﻿using GovukRegistersApiClientNet.Enums;
using GovukRegistersApiClientNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GovukRegistersApiClientNet.Services
{
    public class RsfDownloadService : IRsfDownloadService
    {
        private readonly HttpClient _httpClient;

        public RsfDownloadService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Download(string register, Phase phase, int fromEntryNumber)
        {
            var uri = new Uri($"https://{register}.{(phase == Phase.ReadyToUse ? "register.gov.uk" : "alpha.openregister.org")}/download-rsf/{fromEntryNumber}");

            return await _httpClient.GetStringAsync(uri);
        }
    }
}
