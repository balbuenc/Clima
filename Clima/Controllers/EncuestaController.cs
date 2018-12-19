using Clima.Models;
using Clima.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Clima.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Realizar(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
          
            if (id != null)
            {
                using (climaEntities db = new climaEntities())
                {
                    //IList<EncuestaPregunta> encuestaPreguntas = new List<EncuestaPregunta>();
                    var encuesta = new Encuesta();

                    var encuestas = (from ep in db.EncuestaPreguntas
                                     join e in db.Encuestas on ep.IdEncuesta equals e.IdEncuesta
                                     join tp in db.TipoPreguntas on ep.IdTipoPregunta equals tp.IdTipoPregunta
                                     where ep.IdEncuesta == id
                                     select new
                                     {
                                         ep.Id,
                                         ep.IdEncuesta,
                                         ep.IdAfirmacion,
                                         ep.IdSeleccionMultiple,
                                         ep.IdPregunta,
                                         e.Nombre,
                                         e.Descripcion,
                                         e.Activo,
                                         e.IdPeriodo,
                                         tp.IdTipoPregunta,
                                         tp.Tipo,
                                     })
                                     .OrderBy(e => e.Tipo)
                                     .ToList();

                    if (encuestas.Any())
                    {
                        var enc = encuestas.First();

                        // cargamos la encuesta
                        encuesta.IdEncuesta = enc.IdEncuesta;
                        encuesta.Descripcion = enc.Descripcion;
                        encuesta.Activo = enc.Activo;
                        encuesta.Nombre = enc.Nombre;
                        encuesta.IdPeriodo = enc.IdPeriodo;

                        foreach (var e in encuestas)
                        {
                            Cuestionario cuestionario = new Cuestionario();
                            
                            switch (e.Tipo.ToLower())
                            {
                                case "afirmaciones":
                                    var afir = (from a in db.Afirmaciones
                                                join ep in db.EncuestaPreguntas on a.IdAfirmacion equals ep.IdAfirmacion
                                                where ep.IdAfirmacion == e.IdAfirmacion
                                                select a).FirstOrDefault();

                                    var eval = db.EvaluacionAfirmaciones.ToList();

                                    if (afir != null)
                                    {
                                        cuestionario.IdCuestionario = afir.IdAfirmacion;
                                        cuestionario.Enunciado = afir.Enunciado;
                                        cuestionario.IdDimension = afir.IdDimension;
                                        if (eval.Any())
                                        {
                                            foreach (var item in eval)
                                            {
                                                cuestionario.OpcionesSeleccion.Add(new OpcionSeleccion
                                                {
                                                    Id = item.Evaluacion,
                                                    Descripcion = item.Descripcion
                                                });
                                            }
                                        }
                                    }

                                    break;
                                case "selección multiple":
                                    var selec = (from s in db.SeleccionMultiples
                                                 join ep in db.EncuestaPreguntas on s.IdSeleccionMultiple equals ep.IdSeleccionMultiple
                                                 where ep.IdSeleccionMultiple == e.IdSeleccionMultiple
                                                 select s).FirstOrDefault();

                                    if (selec != null)
                                    {
                                        if (selec != null)
                                        {
                                            cuestionario.IdCuestionario = selec.IdSeleccionMultiple;
                                            cuestionario.Enunciado = selec.Enunciado;
                                            cuestionario.IdDimension = selec.IdDimension;
                                            var opciones = db.OpcionesSeleccionMultiple.Where(o => o.IdSeleccionMultiple == selec.IdSeleccionMultiple).ToList();

                                            if (opciones.Any())
                                            {
                                                foreach (var item in opciones)
                                                {
                                                    cuestionario.OpcionesSeleccion.Add(new OpcionSeleccion
                                                    {
                                                        Id = item.IdSeleccionMultiple,
                                                        Descripcion = item.Valor
                                                    });
                                                }
                                            }
                                        }
                                    }

                                    break;
                                case "preguntas abiertas":
                                    var preg = (from p in db.Preguntas
                                                join ep in db.EncuestaPreguntas on p.IdPregunta equals ep.IdPregunta
                                                where p.IdPregunta == e.IdPregunta
                                                select p).FirstOrDefault();

                                    if (preg != null)
                                    {
                                        cuestionario.IdCuestionario = preg.IdPregunta;
                                        cuestionario.Enunciado = preg.Enunciado;
                                        cuestionario.IdDimension = preg.IdDimension;
                                        cuestionario.OpcionesSeleccion.Add(new OpcionSeleccion
                                        {
                                            Id = 0,
                                            Descripcion = "sin valor"
                                        });
                                    }
                                    break;
                            }

                            // cargamos los tipo de preguntas y sus cuestionarios
                            var TipoPregunta = new TipoPregunta
                            {
                                IdTipoPregunta = e.IdTipoPregunta,
                                Tipo = e.Tipo
                            };

                            var EncuestaPregunta = new EncuestaPregunta
                            {
                                Id = e.Id,
                                //Encuesta = encuesta,
                                TipoPregunta = TipoPregunta,
                                Cuestionario = cuestionario,
                                
                            };
                            
                            encuesta.EncuestaPreguntas.Add(EncuestaPregunta);
                        }

                    }
                   
                    return View(encuesta);

                }
            }

            return View();
        }

        // GET: Encuesta 
        [HttpPost]
        public ActionResult Realizar(Encuesta model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Error con los datos");
            //    return View(model);
            //}

            using (climaEntities db = new climaEntities())
            {
                var user = System.Web.HttpContext.Current.User.Identity.Name;

                foreach (var resultado in model.EncuestaPreguntas)
                {
                    Respuestas respuesta = new Respuestas();

                    respuesta.IdEncuesta = model.IdEncuesta;
                    respuesta.IdTipoPregunta = resultado.TipoPregunta.IdTipoPregunta;
                    respuesta.login = user;
                    respuesta.IdConsulta = resultado.Cuestionario.IdCuestionario;
                    if (resultado.Cuestionario.OpcionesSeleccion.Any())
                    {
                        respuesta.Respuesta = resultado.Cuestionario.OpcionesSeleccion.First().Respuesta;
                    }
                    else
                    {
                        respuesta.Respuesta = resultado.Cuestionario.SelectId.ToString();
                    }

                    db.Respuestas.Add(respuesta);
                    db.SaveChanges();
                }
            }

            //ViewData["resultado"] = "Realizado";

            return RedirectToAction("Index", "Home");
        }
    }
}