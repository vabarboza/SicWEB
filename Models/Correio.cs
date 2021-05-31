using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Models {
  public class Correio {
    public int Id { get; set; }

    [Display(Name = "Status do Correio:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Status { get; set; }


    [Display(Name = "Data do Envio:")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataEnvio { get; set; } = DateTime.Now;


    [Display(Name = "Tipo do Correio:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Tipo { get; set; }


    [Display(Name = "Destinatario do Correio:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Destinatario { get; set; }


    [Display(Name = "Cidade de Destino:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Cidade { get; set; }


    [Display(Name = "Remetente do Correio:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Remetente { get; set; }


    [Display(Name = "Setor do Remetente:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Setor { get; set; }


    [Display(Name = "Ultima Atualizacao:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Atualizacao { get; set; }


  }
}