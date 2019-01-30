using Sirius.Core;
using Sirius.Core.Models;
using Sirius.Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Sirius.Entities;
using Sirius.Core.Data;
using System.Linq;
using System.Security.Claims;
using Sirius.Core.Constants;
using System.IdentityModel.Tokens.Jwt;
using Sirius.Core.AppConfig;
using Microsoft.IdentityModel.Tokens;
using Sirius.Data;

namespace Sirius.Services.CoreService
{
    public class AppAuthenticationService : BaseService, IAppAuthencticationService
    {
        private readonly IAppLogger<AppAuthenticationService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IMainRepository<User> _userRepository;

        public AppAuthenticationService(IAppLogger<AppAuthenticationService> logger
            , IHttpContextAccessor httpContextAccessor
            , IUserService userService
            , IMainRepository<User> userRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _userRepository = userRepository;
        }

        public OperationResult<User> Login(LoginModel loginModel)
        {
            return Execute<User>(_logger, result =>
             {
                 var user = _userService.GetUserByUserName(loginModel.UserName)?.Item;
                 if (user == null)
                 {
                     result.SetError("Kullanici bulunamadi");
                     return;
                 }
                 if (user.Password != loginModel.Password)
                 {
                     result.SetError("Hatali Sifre");
                     return;
                 }

                 var userClaims = _userService.GetClaims(user.Id);
                 var claims = new List<System.Security.Claims.Claim>();
                 claims.Add(new System.Security.Claims.Claim(ClaimTypes.Name, user.Id.ToString()));
                 claims.AddRange(userClaims.Select(x => new System.Security.Claims.Claim(GeneralConst.ClaimName, x.Name)).ToList());

                 ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "SiriusApp");
                 ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                 _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();
             });
        }

        public OperationResult<User> LoginFromWebApi(LoginModel loginModel)
        {
            return Execute<User>(_logger, result =>
            {
                var user = _userService.GetUserByUserName(loginModel.UserName)?.Item;

                if (user == null)
                {
                    result.SetError("Kullanici bulunamadi");
                    return;
                }
                if (user.Password != loginModel.Password)
                {
                    result.SetError("Hatali Sifre");
                    return;
                }

                var userClaims = _userService.GetClaims(user.Id);
                var claims = new List<System.Security.Claims.Claim>();
                claims.Add(new System.Security.Claims.Claim(ClaimTypes.Name, user.Id.ToString()));
                claims.AddRange(userClaims.Select(x => new System.Security.Claims.Claim(GeneralConst.ClaimName, x.Name)).ToList());



                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SiriusCore.Instance.AppConfig.WebApiSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(Convert.ToDouble(SiriusCore.Instance.AppConfig.WebApiSettings.Expires));

                var token = new JwtSecurityToken(issuer: null
                    , audience: null
                    , claims: claims
                    , expires: expires
                    , signingCredentials: creds
                );
                user.Token = new JwtSecurityTokenHandler().WriteToken(token);
                result.Item = user;


                //// authentication successful so generate jwt token
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.UTF8.GetBytes(ApplicationConfiguration.Instance.WebApiSettings.SecretKey);
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(claims),
                //    Expires = DateTime.UtcNow.AddMinutes(ApplicationConfiguration.Instance.WebApiSettings.Expires),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                //};
                //var token = tokenHandler.CreateToken(tokenDescriptor);
                //user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;

               

            });
        }

        public OperationResult LogOut()
        {
            return Execute(_logger, result =>
             {
                 _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
             });
        }
    }
}
