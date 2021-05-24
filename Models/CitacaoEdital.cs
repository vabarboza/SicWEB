﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Models {
  public class CitacaoEdital {
    public int Id { get; set; }

    [Display(Name = "Autos:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Autos { get; set; }

    [Display(Name = "Contrato:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public Int64 Contrato { get; set; }

    [Display(Name = "Vara:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Vara { get; set; }

    [Display(Name = "Comarca:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Comarca { get; set; }

    [Display(Name = "Estado:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Estado { get; set; }

    [Display(Name = "Banco:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Banco { get; set; }

    [Display(Name = "Réu:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Reu { get; set; }

    [Display(Name = "O.A.B:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Oab { get; set; }

    [Display(Name = "Data de Cadastro:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string Data { get; set; }

    [Display(Name = "Usuario:")]
    [Required(ErrorMessage = "Campo de preenchimento obrigatório!")]
    public string NomeUser { get; set; }
  }
}