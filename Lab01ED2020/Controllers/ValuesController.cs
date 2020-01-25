using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab0ED2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab0ED2.Controllers
{

    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly static List<string> movieList = new List<string>();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Mostrar()
        {
            return new string[] { "PruebaVisual" };
        }
        [Route("MostrarPeliculas")]
        [HttpPost]       
        public void Post([FromBody] object movie)
        {
            string postMovie = JsonConvert.SerializeObject(movie);
            movieList.Add(postMovie);            
        }
        [Route("MostrarPeliculas")]
        [HttpGet]
        public string Get()
        {
            string showAll= null;
            if (movieList.Count == 0)
            {
                showAll = "No hay peliculas disponibles\n" + "Ingrese los siguientes campos en Postman:\n" +
                    "name, year y director";
            }
            if (movieList.Count < 10)
            {
                for (int i = 0; i < movieList.Count; i++)
                {
                    var movie = JsonConvert.DeserializeObject<MovieViewModel>(movieList[i]);
                    var show = "------------------------\n" + "Nombre: " + movie.name + "\n" + "Año: "
                     + movie.year + "\n" + "Director: " + movie.director + "\n" + "------------------------\n";
                    showAll += show;
                }
            }
            else
            {
                for (int i = movieList.Count-10; i < movieList.Count; i++)
                {
                    var movie = JsonConvert.DeserializeObject<MovieViewModel>(movieList[i]);
                    var show = "------------------------\n" + "Nombre: " + movie.name + "\n" + "Año: "
                     + movie.year + "\n" + "Director: " + movie.director + "\n" + "------------------------\n";
                    showAll += show;
                }
            }


            return showAll;
        }
    }
}
