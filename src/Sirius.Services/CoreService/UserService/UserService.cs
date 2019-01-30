﻿using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.Models;
using Sirius.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sirius.Services.CoreService
{
    public class UserService : BaseService, IUserService
    {
        private readonly IAppLogger<UserService> _logger;
        private readonly IMainRepository<User> _userRepository;
        private readonly IMainRepository<UserRole> _userRoleRepository;
        private readonly IMainRepository<Claim> _claimRepository;
        private readonly IMainRepository<RoleClaim> _roleClaimRepository;

        public UserService(IAppLogger<UserService> logger
            , IMainRepository<User> userRepository
            , IMainRepository<UserRole> userRoleRepository
            , IMainRepository<Claim> claimRepository
            , IMainRepository<RoleClaim> roleClaimRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _claimRepository = claimRepository;
            _roleClaimRepository = roleClaimRepository;
        }

        public OperationResult<List<User>> GetUsers()
        {
            return Execute<List<User>>(_logger, result =>
           {
               result.Item = _userRepository.Items;
           });
        }

        public OperationResult<User> GetUserById(int id)
        {
            return Execute<User>(_logger, result =>
            {
                result.Item = _userRepository.Items.FirstOrDefault(x => x.Id == id);
            });
        }

        public OperationResult<User> GetUserByUserName(string userName)
        {
            return Execute<User>(_logger, result =>
            {
                result.Item = _userRepository.Items.FirstOrDefault(x => x.UserName == userName);
            });
        }

        public List<Claim> GetClaims(int userId)
        {
            var claimsQuery = from ur in _userRoleRepository.Table
                              join rc in _roleClaimRepository.Table on ur.RoleId equals rc.RoleId
                              join c in _claimRepository.Table on rc.ClaimId equals c.Id
                              where ur.UserId == userId
                              select c;
            return claimsQuery.ToList();
        }

        public bool IsPermitted(string lastChanged)
        {
            return true;
        }
    }
}