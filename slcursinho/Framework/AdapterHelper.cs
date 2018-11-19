using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Data
{
    public class AdapterHelper
    {

        public static IDbTransaction IniciarTransacao(ref object adp)
        {
            return IniciarTransacao(ref adp, IsolationLevel.ReadUncommitted);
        }

        public static IDbTransaction IniciarTransacao(ref object adp, IsolationLevel nivel)
        {
            Type tipo = adp.GetType();
            var conexao = ObterConexao(ref adp);

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            var transacao = conexao.BeginTransaction(nivel);

            ConfigurarTransacao(ref adp, ref transacao);

            return transacao;

        }


        public static IDbConnection ObterConexao(ref object adp)
        {
            var tipo = adp.GetType();
            var propriedadeConexao = tipo.GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);
            var conexao = (IDbConnection)propriedadeConexao.GetValue(adp, null);

            return conexao;
        }

        public static void ConfigurarTransacao(ref object adp, ref IDbTransaction transacao)
        {
            var tipo = adp.GetType();
            var propriedadeCommand = tipo.GetProperty("CommandCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var commands = (IDbCommand[])propriedadeCommand.GetValue(adp, null);

            foreach (var command in commands)
            {
                command.Transaction = transacao;
            }

            ConfigurarConexao(ref adp, transacao.Connection);

        }

        public static void ConfigurarConexao(ref object adp, IDbConnection conexao)
        {
            var tipo = adp.GetType();
            var propriedadeConexao = tipo.GetProperty("Connection", BindingFlags.NonPublic | BindingFlags.Instance);
            propriedadeConexao.SetValue(adp, conexao, null);
        }

    }
}

