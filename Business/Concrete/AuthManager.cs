using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByMail(userForLoginDto.Email);
            if (user.Data==null)
            {
                return new ErrorDataResult<User>(Messages.EmailInvalid);
            }
            
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,user.Data.PasswordHash,user.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.InvalidPassword);
            }
            return new SuccessDataResult<User>(user.Data, Messages.SuccessLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var result=BusinessRules.Run(CheckIfUserExist(userForRegisterDto.Email));
            if (result!=null)
            {
                return new ErrorDataResult<User>(Messages.ExistUser);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName=userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                Email=userForRegisterDto.Email,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserAdded);
            
        }
        private IResult CheckIfUserExist(string email)
        {
            if (_userService.GetByMail(email).Data!=null)
            {
                return new ErrorResult(Messages.ExistUser);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims=_userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.TokenCreated);

        }
    }
}
