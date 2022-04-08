using System;
using System.Linq;
using AutoMapper;
using BookStoreAPI.DbOperations;
using BookStoreAPI.Entities;
using BookStoreAPI.TokenOperations;
using BookStoreAPI.TokenOperations.Models;
using BookStoreWebApi.DBOperations;
using Microsoft.Extensions.Configuration;

namespace BookStoreAPI.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public string RefreshToken;
        public RefreshTokenCommand(IBookStoreDbContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public Token Handle()
        {
            User user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpirationDate > DateTime.Now);
            if (user is not null)
            {

                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpirationDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Refresh Token Bulunamadı");
            }
        }
    }
}