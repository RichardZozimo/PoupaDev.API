using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDev.API.Enums;

namespace PoupaDev.API.Entities
{
    public class Operacao
   {
       public Operacao(decimal valor, TipoOperacao tipo, int objetivoId)
       {
           Valor = valor;
           Tipo = tipo;
           ObjetivoId = objetivoId;
           DataOperacao = DateTime.Now;
       }
 
       public int Id { get; private set; }
       public decimal Valor { get; private set; }
       public TipoOperacao Tipo { get; private set; }
       public DateTime DataOperacao { get; set; }
       public int ObjetivoId { get; set; }
   }
}