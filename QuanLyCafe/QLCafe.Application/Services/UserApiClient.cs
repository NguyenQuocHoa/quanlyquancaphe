using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLCafe.Application.Models;
using RestSharp;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QLCafe.Application.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public UserApiClient(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            request.PassWord = EncodePassWord(request.PassWord);
            if (request.PassWord == null) return null;
            var jsonRequest = JsonConvert.SerializeObject(request);
            //var client = new RestClient(_configuration["UriAPI"]);
            //var requestBody = new RestRequest(Method.POST);
            //requestBody.AddHeader("content-type", "application/json");
            //requestBody.AddHeader("cache-control", "no-cache");
            //requestBody.AddHeader("accept", "");
            //requestBody.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);
            //IRestResponse response = await client.ExecuteAsync(requestBody);
            //return "value: " +response.Content ;

            var client = _httpClientFactory.CreateClient();
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(_configuration["UriAPI"]);
            var response = await client.PostAsync("api/login/Authenticate", httpContent);
             var token = await response.Content.ReadAsStringAsync();

            return token;
        }

        /*
         * mã hóa mật khẩu bằng base64
         * required input: minlenght >= 7
         */
        private string EncodePassWord(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input) && input.Length > 7) return null;
                Random rd = new Random();
                char[] specialCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890==+abcdefghijklmnopqrstuvwxyz".ToCharArray();
                var arrByteUnicode = Encoding.Unicode.GetBytes(input);
                var output = Convert.ToBase64String(arrByteUnicode);
                
                int amountSpecialCharacters = rd.Next(1, 9);
                int locationAdd = rd.Next(10, output.Length);
               
                for (int i = 0; i < amountSpecialCharacters; i++)
                {
                    int chars = rd.Next(0, specialCharacters.Length);
                    output= output.Insert(locationAdd, specialCharacters[chars].ToString());
                 
                }
                output += locationAdd;
                output = amountSpecialCharacters + output;
              
                return output;
            }
            catch
            {
                return null;
            }

        }

    }
}
