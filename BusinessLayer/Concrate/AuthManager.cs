using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Utilities.Hashing;
using EntityLayer.Concrete;
using EntityLayer.Dto;

namespace BusinessLayer.Concrate
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        //IWriterService _writerService;

        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
            //_writerService = writerService;
        }

        public bool Login(LoginDto loginDto)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.AdminUserName));
                var user = _adminService.GetAdmins();
                foreach (var item in user)
                {
                    if (HashingHelper.VerifyPasswordHash(loginDto.AdminUserName, loginDto.AdminPassword, item.AdminUserName, item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void Register(string userName, string password)
        {
            byte[] userNameHash, passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userName, password, out userNameHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = userNameHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                RoleId = 1
            };
            _adminService.Add(admin);
        }

        public bool WriterLogin(WriterLoginDto writerLoginDto)
        {
            throw new NotImplementedException();
        }

        public void WriterRegister(string mail, string password)
        {
            throw new NotImplementedException();
        }
    }

}
