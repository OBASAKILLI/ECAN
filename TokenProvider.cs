using ECAN_CRF.Context;
using ECAN_CRF.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECAN_CRF
{
    public class TokenProvider
    {
        private readonly AppDbcontext _context;

        public TokenProvider(AppDbcontext context)
        {
            _context = context;
        }
        public string LoginUser(string strUserName, string password)
        {
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(password);
            string encodedTxt = Convert.ToBase64String(encodedBytes);

            string username = strUserName;
            string pass = password;


            var user = _context.Users.SingleOrDefault(x => x.strUsername == username && x.strPassword == pass);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return null;

            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            var JWToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            var strusername = user.strUsername;
            return token;
        }
        private IEnumerable<Claim> GetUserClaims(Users user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.strId);
            claims.Add(_claim);
            _claim = new Claim(ClaimTypes.Role, user.strRole);
            claims.Add(_claim);

            if (user.strRole != "")
            {
                _claim = new Claim(user.strRole, user.strRole);
                claims.Add(_claim);
            }
            return claims.AsEnumerable<Claim>();
        }

    }
}
