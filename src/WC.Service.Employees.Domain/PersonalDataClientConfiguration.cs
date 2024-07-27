﻿using Microsoft.Extensions.Configuration;
using WC.Service.PersonalData.gRPC.Client;

namespace WC.Service.Employees.Domain;

public class PersonalDataClientConfiguration : IPersonalDataClientConfiguration
{
    private readonly Lazy<string> _baseUrl;

    public PersonalDataClientConfiguration(
        IConfiguration config)
    {
        _baseUrl = new Lazy<string>(() => config.GetValue<string>("PersonalDataService:Url") ??
                                          throw new InvalidOperationException(
                                              "Personal data REST API service URL must be specified"));
    }

    public string GetBaseUrl()
    {
        return _baseUrl.Value;
    }
}
