﻿using System.Timers;
using Api_Event.Context;
using Api_Event.Domains;
using Api_Event.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace Api_Event.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {

        private readonly Event_Context _context;

        public TipoDeUsuarioRepository(Event_Context context)
        {
            _context = context;
        }


        //Atualizar
        public void Atualizar(Guid Id, TipoDeUsuario tipoDeUsuario)
        {
            try
            {
                TipoDeUsuario tipoUsuarioBuscado = _context.TipoDeUsuario.Find(Id)!;

                if (tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoDeUsuario.TituloTipoUsuario;
                }

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }


        //Buscar Por Id
        public TipoDeUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.TipoDeUsuario.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Cadastrar
        public void Cadastrar(TipoDeUsuario novotipoDeUsuario)
        {
            try
            {
                _context.TipoDeUsuario.Add(novotipoDeUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Deletar
        public void Deletar(Guid Id)
        {
            try
            {
                TipoDeUsuario tipoDeUsuarioBuscado = _context.TipoDeUsuario.Find(Id)!;

                if (tipoDeUsuarioBuscado != null)
                {
                    _context.TipoDeUsuario.Remove(tipoDeUsuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Lista Tipo Evento
        public List<TipoDeUsuario> Listar()
        {
            try
            {
                List<TipoDeUsuario> listaTipoDeUsuario = _context.TipoDeUsuario.ToList();
                return listaTipoDeUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

