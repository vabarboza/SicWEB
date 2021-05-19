using System;
using System.Net;
using System.Net.Mail;

namespace SicWEB {
  public class Mail {
    public void enviaMalote(string status, DateTime data, string cidade, int numero, int percurso, int lacre, string resp, string remetente) {
      string destinatario = null;

      var logo = "https://i.imgur.com/1dxo46Z.png";

      if (cidade == "Curitiba") {
        destinatario = "ricardo.zinke@bellinatiperez.com.br";
      } else if (cidade == "Maringa") {
        destinatario = "pablo.silva@bellinatiperez.com.br";
      } else if (cidade == "São Paulo") {
        destinatario = "lucelia.ribeiro@bellinatiperez.com.br";
      }

      SmtpClient client = new SmtpClient {
        Host = "smtp.gmail.com",
        EnableSsl = true,
        Credentials = new NetworkCredential("malote.bellinati@gmail.com", "drcjuawvwwjszmdd")
      };

      MailMessage mail = new MailMessage {
        Sender = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios"),
        From = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios")
      };
      mail.CC.Add(new MailAddress(remetente, "Sistema de Correios"));
      mail.To.Add(new MailAddress(destinatario));
      mail.Subject = "[E-mail Automático] Notificação de Malote Enviado";
      mail.Body = "<p><strong>Notificação de novo malote.</strong></p><ul>" +
        "<li><strong> Status do envio:</strong> " + status + " </li>" +
        "<li><strong> Malote enviado dia:</strong> " + data + " </li>" +
        "<li><strong> Cidade de destino:</strong> " + cidade + " </li>" +
        "<li><strong> Numero do malote:</strong> " + numero + " </li>" +
        "<li><strong> Percurso do malote:</strong> " + percurso + " </li>" +
        "<li><strong> Numero do lacre:</strong> " + lacre + " </li>" +
        "<li><strong> Responsavel pelo envio:</strong > " + resp + " </li></ul>" +
        "<p> Para maiores informações entrar em contato com o remetente.</p>" +
        "<p> Favor não responder este E-Mail.</p>" +
        "<p><img src=" + logo + " /></p>";
      mail.IsBodyHtml = true;
      mail.Priority = MailPriority.High;

      try {
        client.Send(mail);
      }
      catch (Exception erro) {

      } finally {
        mail = null;
      }
    }

    public void atualizaMalote(string status, DateTime data, string cidade, int numero, int percurso, int lacre, string resp, string remetente) {
      string destinatario = null;

      var logo = "https://i.imgur.com/1dxo46Z.png";

      if (cidade == "Curitiba") {
        destinatario = "ricardo.zinke@bellinatiperez.com.br";
      } else if (cidade == "Maringa") {
        destinatario = "pablo.silva@bellinatiperez.com.br";
      } else if (cidade == "São Paulo") {
        destinatario = "lucelia.ribeiro@bellinatiperez.com.br";
      }

      SmtpClient client = new SmtpClient {
        Host = "smtp.gmail.com",
        EnableSsl = true,
        Credentials = new NetworkCredential("malote.bellinati@gmail.com", "drcjuawvwwjszmdd")
      };

      MailMessage mail = new MailMessage {
        Sender = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios"),
        From = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios")
      };
      mail.CC.Add(new MailAddress(remetente, "Sistema de Correios"));
      mail.To.Add(new MailAddress(destinatario));
      mail.Subject = "[E-mail Automático] Notificação de Atualização Malote Enviado";
      mail.Body =
        "<p><strong>Atualização de malote.</strong></p>" +
        "<p> Houve uma atualização de status no envio de um malote.</p>" +
        "<ul>" +
        "<li><strong> Status do envio:</strong> " + status + " </li>" +
        "<li><strong> Malote enviado dia:</strong> " + data + " </li>" +
        "<li><strong> Cidade de destino:</strong> " + cidade + " </li>" +
        "<li><strong> Numero do malote:</strong> " + numero + " </li>" +
        "<li><strong> Percurso do malote:</strong> " + percurso + " </li>" +
        "<li><strong> Numero do lacre:</strong> " + lacre + " </li>" +
        "<li><strong> Responsavel pelo envio: </strong>" + resp + " </li>" +
        "</ul>" +
        "<p> &nbsp;</p>" +
        "<p><em> Para maiores informações entrar em contato com o remetente.</em></p>" +
        "<p><strong> Favor não responder este E-Mail.</strong></p>" +
        "<p><img src = " + logo + " /></p> ";

      mail.IsBodyHtml = true;
      mail.Priority = MailPriority.High;

      try {
        client.Send(mail);
      }
      catch (Exception erro) {

      } finally {
        mail = null;
      }
    }

  }

}
