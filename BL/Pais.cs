﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.KGarciaProgramacionNCapasEntities conntext=new DL_EF.KGarciaProgramacionNCapasEntities())
                {
                    var query = conntext.PaisGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = obj.IdPais;
                            pais.Nombre = obj.Nombre;
                            result.Objects.Add(pais);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
    }
}
