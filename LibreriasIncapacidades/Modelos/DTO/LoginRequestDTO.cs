//using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiIncapacidades.Modelos.DTO
{
    public class LoginRequestDTO
    {
        //[Required]
        //[JsonProperty("username")]
        public string Username { get; set; }


        //[Required]
        //[JsonProperty("password")]
        public string Password { get; set; }
    }
}
