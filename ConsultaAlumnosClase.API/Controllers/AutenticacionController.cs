﻿using ConsultaAlumnosClase.API.Entities;
using ConsultaAlumnosClase.API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsultaAlumnos.API.Controllers
{
    [Route("api/autenticacion")]
    [ApiController]
    public class AutenticacionController : ControllerBase
{
        private readonly IConfiguration _config;
        private readonly IAutenticacionService _autenticacionService;

        public class AuthenticationRequestBody // Esta clase podría estar en un archivo aparte, pero como no es una entidad ni un DTO y solo se usa para el login podemos dejarla acá.
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
            public string? TipoUsuario { get; set; }
            }

        public AutenticacionController(IConfiguration config, IAutenticacionService autenticacionService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            this._autenticacionService = autenticacionService;
        }

        [HttpPost("autenticar")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody) //Enviamos como parámetro la clase que creamos arriba
        {
            //Paso 1: Validamos las credenciales
            var usuario = ValidarCredenciales(authenticationRequestBody); //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            if (usuario is null) //Si el la función de arriba no devuelve nada es porque los datos son incorrectos, por lo que devolvemos un Unauthorized (un status code 401).
                return Unauthorized();

            //Paso 2: Crear el token
            var claveDeSeguridad = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

            var credenciales = new SigningCredentials(claveDeSeguridad, SecurityAlgorithms.HmacSha256);

            //Los claims son datos en clave->valor que nos permite guardar data del usuario.
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", usuario.Id.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
            claimsForToken.Add(new Claim("given_name", usuario.Nombre)); //Lo mismo para given_name y family_name, son las convenciones para nombre y apellido. Ustedes pueden usar lo que quieran, pero si alguien que no conoce la app
            claimsForToken.Add(new Claim("family_name", usuario.Apellido)); //quiere usar la API por lo general lo que espera es que se estén usando estas keys.
            claimsForToken.Add(new Claim("role", authenticationRequestBody.TipoUsuario ?? "alumno")); //Debería venir del usuario

            var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credenciales);

            var tokenToReturn = new JwtSecurityTokenHandler() //Pasamos el token a string
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private Usuario? ValidarCredenciales(AuthenticationRequestBody parametrosAutenticacion)
        {
            return _autenticacionService.AutenticarUsuario(parametrosAutenticacion);
        }
    }
}
