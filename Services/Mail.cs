using System;
using System.Net;
using System.Net.Mail;

namespace SicWEB {
  public class Mail {
    public void enviaMalote(string status, DateTime data, string cidade, int numero, int percurso, int lacre, string resp, string remetente) {
      string destinatario = null;

      var logo = "https://i.imgur.com/1dxo46Z.png";

      if (cidade == "Curitiba") {
        destinatario = "vinicius.barboza@bellinatiperez.com.br";
      } else if (cidade == "Maringa") {
        destinatario = "pablo.silva@bellinatiperez.com.br";
      } else {
        destinatario = "dev.viniciusbarboza@gmail.com";
      }

      SmtpClient client = new SmtpClient();
      client.Host = "smtp.gmail.com";
      client.EnableSsl = true;
      client.Credentials = new NetworkCredential("malote.bellinati@gmail.com", "drcjuawvwwjszmdd");

      MailMessage mail = new MailMessage();
      mail.Sender = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios");
      mail.From = new MailAddress("malote.bellinati@gmail.com", "Sistema de Correios");
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


  }
}
