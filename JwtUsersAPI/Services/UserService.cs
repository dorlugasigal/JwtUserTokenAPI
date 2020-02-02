using AutoMapper;
using JwtUsersAPI.Data;
using JwtUsersAPI.Entities;
using JwtUsersAPI.Helpers;
using JwtUsersAPI.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtUsersAPI.Services
{
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;
        private readonly UsersContext _context;

        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, IRepository<User> repository)
        {
            //UsersContext context
            _mapper = mapper;
            _repository = repository;
            _context = null;//context;
            _appSettings = appSettings.Value;
        }

        public UserToReturn Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return _mapper.Map<UserToReturn>(user);
        }

        public async Task<List<UserToReturn>> GetAll()
        {
            var res = await _repository.GetAll();
            var ret = _mapper.Map<List<UserToReturn>>(res);
            return ret;
        }

        public async Task<UserToReturn> Get(int id)
        {
            var res = await _repository.Get(id);
            var ret = _mapper.Map<UserToReturn>(res);
            return ret;
        }

        public async Task<UserToReturn> Add(User entity)
        {
            var res = await _repository.Add(entity);
            var ret = _mapper.Map<UserToReturn>(res);
            return ret;
        }

        public async Task<bool> Update(User entity)
        {
            var ret = await _repository.Update(entity);
            return ret;
        }

        public async Task<UserToReturn> Delete(int id)
        {
            var res = await _repository.Delete(id);
            var ret = _mapper.Map<UserToReturn>(res);
            return ret;
        }

        public async Task<bool> UserExists(int id)
        {
            var res = await _repository.Get(id);
            return res != null;
        }
    }
}