using MySqlConnector;

namespace BellinatiCorreio.Views.Home {

  //Retorna String de conexão
  public class Conexao {
    public string ConexaoDados() {
      var dados = "Server=192.168.0.26;Database=sicweb;Uid=root;Pwd=15031989;";

      return dados;
    }



    //Contador do numero de Correios cadastrados
    public int ContarCorreio() {
      int count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Correio");
          count = (int)(long)comando.ExecuteScalar();
        }
      }

      return count;
    }



    //Contador do numero de Malotes cadastrados
    public int ContarMalote() {
      int count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Malote");
          count = (int)(long)comando.ExecuteScalar();
        }
      }

      return count;
    }



    //Contador do numero de Azul cadastrados
    public int ContarAzul() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Correio where Tipo = 'Azul'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador do numero de AR cadastrados
    public int ContarAR() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Correio where Tipo = 'AR'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador do numero de Cartas cadastradas
    public int ContarCarta() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Correio where Tipo = 'Carta'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador do numero de Sedex cadastrados
    public int ContarSedex() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Correio where Tipo = 'Sedex'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador do numero de Malote pada Curitiba
    public int ContarCuritiba() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Malote where Cidade = 'Curitiba'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador do numero de Malote para Maringa
    public int ContarMaringa() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Malote where Cidade = 'Maringa'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador do numero de Malote para São Paulo
    public int ContarSP() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from Malote where Cidade = 'São Paulo'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Busca nome do usuario pelo CPF
    public string NomeUser(string nome) {
      using (var conexao = new MySqlConnection()) {

        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select nomeuser('" + nome + "')");
          nome = (string)comando.ExecuteScalar();
        }
      }
      return nome;
    }

    //Busca Cidade do usuario pelo CPF
    public string CidadeUser(string nome) {
      using (var conexao = new MySqlConnection()) {

        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select cidadeuser('" + nome + "')");
          nome = (string)comando.ExecuteScalar();
        }
      }
      return nome;
    }

    //Busca Cidade do usuario pelo CPF
    public string EmailUser(string nome) {
      using (var conexao = new MySqlConnection()) {

        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select emailuser('" + nome + "')");
          nome = (string)comando.ExecuteScalar();
        }
      }
      return nome;
    }

    //Contador de notificações
    public int ContarNotificacao() {
      int count;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select conta_notificacao()");
          count = (int)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de notificações
    public int ContarNotificacaoCitacao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from citacaocarta");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de notificações
    public int ContarNotificacaoCitacaoEdital() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from citacaoedital");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador de notificações
    public int ContarNotificacaoExpedicao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from expedicaonovomandado");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de notificações
    public int ContarExpedicaoMandadoCitacao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from expedicaomandadocitacao");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador de notificações
    public int ContarNotificacaoFiel() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from fieldepositario");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de notificações
    public int ContarNotificacaoInformarEndereco() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from informarendereco");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de notificações
    public int ContarNotificacaoInformarOrgao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from informarorgao");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador de notificações
    public int ContarNotificacaoJuntadaTermoCessao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from juntadatermocessao");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador de notificações
    public int ContarNotificacaoConversaoExecucao() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from conversaoexecucao");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }


    //Contador de notificações
    public int ContarNotificacaoConversaoExecucaoItau() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("Select count(*) from conversaoexecucaoitau");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de malotes atrasados
    public int MaloteAtrasado() {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select maloteatrasado()");
          count = (int)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de malotes atrasados
    public int MaloteUsuario(string nome) {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("SELECT count(*) FROM sicweb.malote where NomeUser = '" + nome + "'");
          count = (int)(long)comando.ExecuteScalar();
        }
      }
      return count;
    }

    //Contador de malotes atrasados
    public int MaloteAtrasadoUser(string nome) {
      var count = 0;
      using (var conexao = new MySqlConnection()) {
        conexao.ConnectionString = ConexaoDados();
        conexao.Open();

        using (var comando = new MySqlCommand()) {
          comando.Connection = conexao;
          comando.CommandText = string.Format("select maloteatrasadouser('" + nome + "')");
          count = (int)comando.ExecuteScalar();
        }
      }
      return count;
    }


  }

}
