using System;
using System.ComponentModel.DataAnnotations;

namespace SicWEB.Models {
  public class Malote {
    public int Id { get; set; }

    [Display(Name = "Numero do Malote:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public int Numero { get; set; }

    [Display(Name = "Percurso do Malote:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public int Percurso { get; set; }

    [Display(Name = "Numero do Lacre:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public int Lacre { get; set; }

    [Display(Name = "Cidade de Destino:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Cidade { get; set; }

    [Display(Name = "Remetente do Malote:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Remetente { get; set; }

    [Display(Name = "Status do Malote:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Status { get; set; }

    [Display(Name = "Ultima Atualizacao:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Atualizacao { get; set; }

    [Display(Name = "Data do Envio:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataEnvio { get; set; }

    [Display(Name = "Data do Recebimento:")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataRecebido { get; set; }

    [Display(Name = "Cidade de Origem:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string CidadeSaida { get; set; }

    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string NomeUser { get; set; }
  }
}
