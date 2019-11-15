﻿using Fortnite_API.Endpoints;

using RestSharp;

namespace Fortnite_API
{
	public class FortniteApi
	{
		//private readonly IRestClient _client;
		public readonly CosmeticsEndpoints Cosmetics;
		public readonly ShopEndpoints Shop;
		public readonly NewsEndpoints News;

		public FortniteApi(string apiKey = null)
		{
			var _client = new RestClient("https://fortnite-api.com/")
			{
				UserAgent = "FortniteApi.Net (v1.0.0)",
				Timeout = 10 * 1000
			}.UseSerializer<JsonNetSerializer>();

			if (!string.IsNullOrWhiteSpace(apiKey))
			{
				_client.DefaultParameters.Add(new Parameter("x-api-key", apiKey, ParameterType.HttpHeader));
			}

			Cosmetics = new CosmeticsEndpoints(_client);
			Shop = new ShopEndpoints(_client);
			News = new NewsEndpoints(_client);
		}
	}
}