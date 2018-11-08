using Clima.Models;
using Clima.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
                    IList<EncuestaPregunta> encuestaPreguntas = new List<EncuestaPregunta>();

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
                                     }).ToList();



                    if (encuestas.Any())
                    {
                        foreach (var e in encuestas)
                        {
                            Cuestionario cuestionario = new Cuestionario();

                            // cargamos la encuesta
                            var encuesta = new Encuesta
                            {
                                IdEncuesta = e.IdEncuesta,
                                Descripcion = e.Descripcion,
                                Activo = e.Activo,
                                Nombre = e.Nombre,
                                IdPeriodo = e.IdPeriodo,
                            };

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
                                                    IdSeleccion = item.Evaluacion,
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
                                                        IdSeleccion = item.IdSeleccionMultiple,
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
                                        cuestionario.IdCuestionario = preg.IdDimension;
                                        cuestionario.Enunciado = preg.Enunciado;
                                        cuestionario.IdDimension = preg.IdDimension;
                                        cuestionario.OpcionesSeleccion.Add(new OpcionSeleccion
                                        {
                                            IdSeleccion = 0,
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
                                Encuesta = encuesta,
                                TipoPregunta = TipoPregunta,
                                Cuestionario = cuestionario,
                            };

                            encuestaPreguntas.Add(EncuestaPregunta);
                        }
                    }

                    /*
                    select ep.IdEncuesta , e.Nombre as Encuesta, e.Descripcion , tp.IdTipoPregunta, tp.Tipo,
                    case
	                    when tp.Tipo = 'Afirmaciones' then a.Enunciado
	                    when tp.Tipo = 'Preguntas abiertas' then p.Enunciado
	                    when tp.Tipo = 'Selección multiple' then sm.Enunciado
                    end as Enunciado,
                    case
	                    when tp.Tipo = 'Afirmaciones' then (select nombre from dimensiones where IdDimension=  a.IdDimension)
	                    when tp.Tipo = 'Preguntas abiertas' then (select nombre from dimensiones where IdDimension=  p.IdDimension)
	                    when tp.Tipo = 'Selección multiple' then (select nombre from dimensiones where IdDimension=  sm.IdDimension)
                    end as Dimension
                    from EncuestaPreguntas ep
                    inner join Encuestas e on e.IdEncuesta = ep.IdEncuesta
                    inner join TipoPreguntas tp on tp.IdTipoPregunta = ep.IdTipoPregunta 
                    left outer join Afirmaciones a on a.IdAfirmacion = ep.IdAfirmacion
                    left outer join Preguntas p on p.IdPregunta = ep.IdPregunta 
                    left outer join SeleccionMultiples sm on ep.IdSeleccionMultiple = sm.IdSeleccionMultiple 
                    where ep.IdEncuesta = 1
                     */

                    return View(encuestaPreguntas);

                }
            }

            return View();
        }

        // GET: Encuesta
        [HttpPost]
        public ActionResult Realizar(IList<EncuestaPregunta> model)
        {
            return View();
        }
    }
}