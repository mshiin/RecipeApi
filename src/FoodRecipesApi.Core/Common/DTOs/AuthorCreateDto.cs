using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodRecipesApi.Core.Common.DTOs
{
    public class AuthorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; }= string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        

    }
}