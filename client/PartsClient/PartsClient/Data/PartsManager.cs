﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PartsClient.Data;

public static class PartsManager
{
    // TODO: Add fields for BaseAddress, Url, and authorizationKey
    static readonly string BaseAddress = "URL GOES HERE";
    static readonly string Url = $"{BaseAddress}/api/";
    private static string authorizationKey;

    static HttpClient client;

    private static async Task<HttpClient> GetClient()
    {
        throw new NotImplementedException();
    }

    public static async Task<IEnumerable<Part>> GetAll()
    {
        throw new NotImplementedException();                
    }

    public static async Task<Part> Add(string partName, string supplier, string partType)
    {
        throw new NotImplementedException();
    }

    public static async Task Update(Part part)
    {
        throw new NotImplementedException();
    }

    public static async Task Delete(string partID)
    {
        throw new NotImplementedException();                        
    }
    private static async Task<HttpClient> GetClient()
    {
        if (client != null)
            return client;

        client = new HttpClient();

        if (string.IsNullOrEmpty(authorizationKey))
        {
            authorizationKey = await client.GetStringAsync($"{Url}login");
            authorizationKey = JsonSerializer.Deserialize<string>(authorizationKey);
        }

        client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
        client.DefaultRequestHeaders.Add("Accept", "application/json");

        return client;
    }
}
