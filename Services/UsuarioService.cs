﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Ploomers_Advogados.Data.Dtos;
using Ploomers_Advogados.Models;

namespace Ploomers_Advogados.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager,
            TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);
            if (!result.Succeeded)
                throw new ApplicationException("Falha ao cadastrar usuário");
        }

        public async Task<string> Login(LoginUsuarioDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded) throw new ApplicationException("Usuário não autenticado!");

            var usuario = _signInManager.UserManager.Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;

        }
    }
}
