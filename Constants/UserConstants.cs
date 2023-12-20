using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Controllers;

namespace Jwt.Constants
{
    public class UserConstants
    {
        public static List<UserModel> users = new List<UserModel>()
        {
            new UserModel() { Username="dalarcon", Password ="admin123", Rol= "Administrador", EmailAdrress= "dalarcon@", FirstName="Danilo", LastName="Alarcon Lopez"},
            new UserModel() { Username="maiculrico", Password ="culito", Rol= "Vendedor", EmailAdrress= "@", FirstName="Maira", LastName="Culo Rico"},
            new UserModel() { Username="fertetas", Password ="tetazas", Rol= "Gerente", EmailAdrress= "@", FirstName="Fernanda", LastName="Medias Tetas"},
        };


    }
}