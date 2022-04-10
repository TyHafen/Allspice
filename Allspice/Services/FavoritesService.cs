using System;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _favoritesRepo;

        public FavoritesService(FavoritesRepository favoritesRepo)
        {
            _favoritesRepo = favoritesRepo;
        }

        internal Favorite Create(Favorite favoriteData)
        {
            return _favoritesRepo.Create(favoriteData);
        }

        internal string Remove(int id, Account userInfo)
        {
            Favorite favorite = _favoritesRepo.GetById(id);
            if (favorite.AccountId != userInfo.Id)
            {
                throw new Exception("not yours to delete");
            }
            return _favoritesRepo.Remove(id);
        }

    }
}