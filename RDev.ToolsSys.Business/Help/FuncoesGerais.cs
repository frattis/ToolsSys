using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace RDev.ToolsSys.Business.Help
{
   public class FuncoesGerais
    {
       /// <summary>
       /// Valida CPF
       /// </summary>
       /// <param name="cpf">CPF tipo String</param>
       /// <returns>True ou False</returns>
       public static bool ValidaCPF(string cpf)
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }

       /// <summary>
       /// Valida Data
       /// </summary>
       /// <param name="data">data String</param>
       /// <returns>True ou False</returns>
       public static bool ValidarData(string data)
       {
           DateTime resultado = DateTime.MinValue;
           return DateTime.TryParse(data.Trim(), out resultado);
       }
       #region Atributos/Propriedades/Enums/Constantes

       #region Lado enum
       /// <summary>
       /// Define da string que será tratado
       /// </summary>
       public enum Lado
       {
           /// <summary>
           /// Alinha o texto para a esquerda
           /// </summary>
           Esquerdo,
           /// <summary>
           /// Alinha o texto para a direita
           /// </summary>
           Direito
       }
       #endregion

       #region TipoData enum
       /// <summary>
       /// Define a formatação de uma data
       /// </summary>
       public enum TipoData
       {
           /// <summary>
           /// dd/MM/yyyy
           /// </summary>
           Data,
           /// <summary>
           /// MM/yyyy
           /// </summary>
           DataMesAno,
           /// <summary>
           /// yyyy-MM-dd
           /// </summary>
           DataAnoMesDia_Var,
           /// <summary>
           /// yyyy-MM-dd_hh24-mm-ss
           /// </summary>
           DataHoraAnoMesDia_Var,
           /// <summary>
           /// hh24:mm
           /// </summary>
           HoraMinutos,
           /// <summary>
           /// dd/MM/yyyy hh24:mm
           /// </summary>
           DataHora,
           /// <summary>
           /// hh24:mm:ss
           /// </summary>
           HoraSegundos,
           /// <summary>
           /// dd/MM/yyyy hh24:mm:ss
           /// </summary>
           DataHoraSegundos,
           /// <summary>
           /// dd/MM/yyyy hh24:mm:ss.ms
           /// </summary>
           DataHoraMilesimos,
           /// <summary>
           /// hh24:mm:ss.ms
           /// </summary>
           HoraSegundosMilesimos
       }
       #endregion

       /// <summary>
       /// Simbolo moeda corrente (Padrão = R$)
       /// </summary>
       public const string SimboloMoeda = "R$";

       #endregion

       /// <summary>
       /// Extrair a parte numérica de um texto. 
       /// </summary>
       /// <param name="texto">Texto que contém um número</param>
       /// <returns>Parte numérica do texto</returns>
       /// <example>
       /// <c>Transformador.ExtrairNumeroDecimal("Eu tenho R$222.222,22 na minha conta");</c><br></br>
       /// Resultado: 222222.22
       /// </example>
       public static string ExtrairNumeroDecimal(string texto)
       {
           string retValor;

           Regex reg;
           string pat = @"(([+-]?[\d\.]+)(\,\d+)?)|(([+-]?,\d+))";

           reg = new Regex(pat);
           Match m = reg.Match(texto);
           if (m.Groups.Count > 0)
           {
               retValor = m.Groups[0].Value;
               if (retValor.Length != 0)
                   if (m.Groups[1].Value.Length != 0)
                       return m.Groups[1].Value;
                   else
                       return m.Groups[4].Value;
           }
           return String.Empty;
       }

       /// <summary>
       /// Arredondar para cima.
       /// </summary>
       /// <param name="numero">numero.</param>
       /// <param name="casasDecimais">casas decimais.</param>
       /// <returns></returns>
       public static double ArredondarCima(double numero, int casasDecimais)
       {
           if (casasDecimais <= 0)
               return numero;
           double fator = Math.Pow(10, casasDecimais);
           return (Math.Ceiling(((numero * fator) + 0.4999999999)) / fator);
       }

       /// <summary>
       /// Extrair a parte numérica de um texto (sem separadores decimais). 
       /// </summary>
       /// <param name="texto">texto com numeros</param>
       /// <returns>Parte numérica do texto</returns>
       /// <example>
       /// <c>Transformador.ExtrairTodosNumerosContidos("1,2--12..12-12");</c><br></br>
       /// Resultado: 12121212
       /// </example>
       public static string ExtrairTodosNumerosContidos(string texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return String.Empty;
           var retorno = new StringBuilder();
           string pat = @"(^[+-]|^\d+\d*|\d+)";
           MatchCollection colecao = Regex.Matches(texto, pat);
           if (colecao.Count > 0)
           {
               for (int i = 0; i < colecao.Count; i++)
               {
                   retorno.Append(colecao[i].ToString());
               }
               return retorno.ToString();
           }
           else
               return String.Empty;
       }

       public static string ExtrairTodosNumerosContidos(string texto, int posicaoInicial)
       {
           return ExtrairTodosNumerosContidos(texto.Substring(posicaoInicial));
       }

       /// <summary>
       /// Extrai as variáveis contidas num texto qualquer
       /// </summary>
       /// <param name="texto">texto com numeros</param>
       /// <returns>Lista de variáveis</returns>
       /// <example>
       /// <c>Transformador.ExtrairListaVariaveis("abc_12 + 25 - ypf");</c><br></br>
       /// Resultado: {"abc_25", "ypf"}
       /// </example>
       public static List<string> ExtrairListaVariaveis(string texto)
       {
           return RegexExtrairCasamentos(texto, @"(\b[a-zA-Z_][a-zA-Z0-9_]*\b)");
       }

       /// <summary>
       /// Extrai uma lista de variáveis a partir de uma expressão regular
       /// </summary>
       /// <param name="texto">Texto</param>
       /// <param name="regEx">Expressão Regular</param>
       /// <example>
       /// <c>RegexExtrairGrupos("abcd", "(\w)+");</c><br></br>
       /// Resultado: {"a", "b", "c", "d"}
       /// </example>
       public static List<string> RegexExtrairGrupos(string texto, string regEx)
       {
           if (regEx == null)
               throw new ArgumentNullException("regEx");
           if (regEx.Length == 0)
               return null;
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return null;

           MatchCollection colecao = Regex.Matches(texto, regEx, RegexOptions.IgnoreCase);
           var listaRetorno = new List<string>();

           // Caso a regex não case, volta uma lista vazia
           if (colecao.Count == 0)
               return listaRetorno;

           for (int i = 0; i < colecao[0].Groups.Count; i++)
               listaRetorno.Add(colecao[0].Groups[i].Value);

           return listaRetorno;
       }

       /// <summary>
       /// Extrai uma lista de variáveis a partir de uma expressão regular
       /// </summary>
       /// <param name="texto">Texto</param>
       /// <param name="regEx">Expressão Regular</param>
       /// <example>
       /// <c>RegexExtrairCasamentos("a b c d", "\w+");</c><br></br>
       /// Resultado: {"a", "b", "c", "d"}
       /// </example>
       public static List<string> RegexExtrairCasamentos(string texto, string regEx)
       {
           return RegexExtrairCasamentos(texto, 0, regEx);
       }

       /// <summary>
       /// Extrai uma lista de variáveis a partir de uma expressão regular
       /// </summary>
       /// <param name="texto">Texto</param>
       /// <param name="grupoNumero">Grupo que irá retornar de cada casamento</param>
       /// <param name="regEx">Expressão Regular</param>
       /// <example>
       /// <c>RegexExtrairCasamentos("a b c d", "\w+");</c><br></br>
       /// Resultado: {"a", "b", "c", "d"}
       /// </example>
       public static List<string> RegexExtrairCasamentos(string texto, int grupoNumero, string regEx)
       {
           if (regEx == null)
               throw new ArgumentNullException("regEx");
           if (regEx.Length == 0)
               return null;
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return null;

           MatchCollection colecao = Regex.Matches(texto, regEx, RegexOptions.IgnoreCase);
           var listaRetorno = new List<string>();

           for (int i = 0; i < colecao.Count; i++)
               listaRetorno.Add(colecao[i].Groups[grupoNumero].Value);

           return listaRetorno;
       }

       /// <summary>
       /// Recebe uma data no formato DD/MM/AAAA HH:mm:SS
       /// </summary>
       /// <param name="texto">data no formato DD/MM/AAAA HH:mm:SS</param>
       /// <param name="tipo">Tipo de Data</param>
       /// <returns>
       /// Data formatada
       /// </returns>
       /// <example>
       /// 	<c>Transformador.FormatarDataBr("3/5/1960");</c><br></br>
       /// Resultado: 05/03/1960
       /// </example>
       public static string FormatarDataBr(string texto, TipoData tipo)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return String.Empty;


           const string pat = @"(0?[1-9]|[12][0-9]|3[01])\/(0?[1-9]|1[0-2])\/(19[0-9]{2}|2[0-9]{3}|\d{2})\s?(\d+)?:?(\d+)?:?(\d+)?\.?(\d+)?";
           var reg = new Regex(pat);
           Match m = reg.Match(texto);
           if (m.Length == 0)
               return texto;

           string dia = (m.Groups[1].Value.Length == 1) ? "0" + m.Groups[1].Value : m.Groups[1].Value;
           string mes = (m.Groups[2].Value.Length == 1) ? "0" + m.Groups[2].Value : m.Groups[2].Value;
           string ano = String.IsNullOrEmpty(m.Groups[3].Value) ? "00" : m.Groups[3].Value;
           string hora = String.IsNullOrEmpty(m.Groups[4].Value) ? "00" : m.Groups[4].Value;
           string minuto = String.IsNullOrEmpty(m.Groups[5].Value) ? "00" : m.Groups[5].Value;
           string segundo = String.IsNullOrEmpty(m.Groups[6].Value) ? "00" : m.Groups[6].Value;
           string milesimoSegundo = String.IsNullOrEmpty(m.Groups[7].Value) ? "000" : m.Groups[7].Value;

           switch (tipo)
           {
               case TipoData.Data:
                   return dia + "/" + mes + "/" + ano;
               case TipoData.DataMesAno:
                   return mes + "/" + ano;
               case TipoData.DataAnoMesDia_Var:
                   return ano + "-" + mes + "-" + dia;
               case TipoData.DataHoraAnoMesDia_Var:
                   return ano + "-" + mes + "-" + dia + "_" + hora + "-" + minuto + "-" + segundo;
               case TipoData.DataHora:
                   return dia + "/" + mes + "/" + ano + " " + hora + ":" + minuto;
               case TipoData.DataHoraSegundos:
                   return dia + "/" + mes + "/" + ano + " " + hora + ":" + minuto + ":" + segundo;
               case TipoData.DataHoraMilesimos:
                   return dia + "/" + mes + "/" + ano + " " + hora + ":" + minuto + ":" + segundo + "." + milesimoSegundo;
               case TipoData.HoraMinutos:
                   return hora + ":" + minuto;
               case TipoData.HoraSegundos:
                   return hora + ":" + minuto + ":" + segundo;
               case TipoData.HoraSegundosMilesimos:
                   return hora + ":" + minuto + ":" + segundo + "." + milesimoSegundo;
               default:
                   return "?" + texto;
           }
       }

       /// <summary>
       /// Recebe uma data no formato americano (MM/DD/YYYY) e formata no padrão brasileiro (DD/MM/AAAA).
       /// </summary>
       /// <param name="data">The data.</param>
       /// <param name="tipo">Tipo de Data</param>
       /// <returns>
       /// Data formatada no padrão brasileiro (DD/MM/AAAA).
       /// </returns>
       /// <example>
       /// 	<c>Transformador.FormatarDataBr("3/5/1960");</c><br></br>
       /// Resultado: 05/03/1960
       /// </example>
       public static string FormatarDataBr(DateTime? data, TipoData tipo)
       {
           if (data.HasValue)
           {
               return FormatarDataBr(data.Value.ToString("dd/MM/yyyy HH:mm:ss.fff"), tipo);
           }

           return string.Empty;
       }

       /// <summary>
       /// Recebe uma data no formato americano (MM/DD/YYYY) e formata no padrão brasileiro (DD/MM/AAAA).
       /// </summary>
       /// <param name="texto">Data no formato americano (MM/DD/YYYY)</param>
       /// <param name="tipo">Tipo de Data</param>
       /// <returns>
       /// Data formatada no padrão brasileiro (DD/MM/AAAA).
       /// </returns>
       /// <example>
       /// 	<c>Transformador.FormatarDataBr("3/5/1960");</c><br></br>
       /// Resultado: 05/03/1960
       /// </example>
       public static string FormatarDataFormatoAmericano(string texto, TipoData tipo)
       {
           DateTime dateTime;
           IFormatProvider formatoAmericano = CultureInfo.GetCultureInfo("en-US");
           return DateTime.TryParse(texto, formatoAmericano, DateTimeStyles.RoundtripKind, out dateTime) ? FormatarDataBr(dateTime, tipo) : FormatarDataBr(texto, tipo);
       }

       /// <summary>
       /// Formata o numero para inserção no SQL.
       /// </summary>
       /// <param name="texto">número vindo de um CSV</param>
       /// <returns></returns>
       public static string FormatarNumero_en_US(object numeroDecimal)
       {
           double num = 0;
           IFormatProvider formatoBrasileiro = CultureInfo.GetCultureInfo("pt-BR");
           IFormatProvider formatoAmericano = CultureInfo.GetCultureInfo("en-US");


           if (numeroDecimal.GetType().Name == "String")
               Double.TryParse(numeroDecimal.ToString(), NumberStyles.Float | NumberStyles.AllowThousands, formatoBrasileiro, out num);

           if (numeroDecimal.GetType().Name == "Double")
               num = (double)numeroDecimal;

           return num.ToString("0,000.00", formatoAmericano);
       }

       /// <summary>
       /// Recebe um numero e converte para somente uma vígula como separador decimal
       /// </summary>
       public static string FormatarNumeroSap(object numero)
       {
           string numeroAux = numero.ToString();
           numeroAux = numeroAux.Replace(",", "");
           numeroAux = numeroAux.Replace("-", "");
           numeroAux = numeroAux.Replace("(", "");
           numeroAux = numeroAux.Replace(")", "");
           numeroAux = numeroAux.Replace(".", ",");
           return numeroAux;
       }


       /// <summary>
       /// Recebe uma data no formato de banco de dados.
       /// </summary>
       /// <param name="texto">Data no formato de banco Ex: 2006-07-24T17:32:01.9870000-03:00</param>
       /// <param name="tipo">Tipo de retorno</param>
       /// <returns>Data formatada</returns>
       public static string FormatarDataSql(string texto, TipoData tipo)
       {
           List<string> regexExtrairGrupos = RegexExtrairGrupos(texto,
                                               @"^(\d+)-(\d+)-(\d+)t(\d+):(\d+):(\d+).(\d+)([+-]\d+):(\d+)$");

           return FormatarDataBr(
               new DateTime(
                   ObterNumeroInteiro(regexExtrairGrupos[1]), //ano
                   ObterNumeroInteiro(regexExtrairGrupos[2]), //mes
                   ObterNumeroInteiro(regexExtrairGrupos[3]), //dia
                   ObterNumeroInteiro(regexExtrairGrupos[4]), //hora
                   ObterNumeroInteiro(regexExtrairGrupos[5]), //minuto
                   ObterNumeroInteiro(regexExtrairGrupos[6]), //segundo
                   ObterNumeroInteiro(regexExtrairGrupos[7].TrimEnd('0'))) //milisegundo
                   , tipo);
       }

       /// <summary>
       /// Transforma segundos em horas, minutos e segundos
       /// </summary>
       /// <param name="tempo">Quantidade de segundos</param>
       /// <returns>00h 00min 00seg</returns>
       public static string FormatarSegundos(string tempo)
       {
           int horas, minutos, segundos;

           var retorno = new StringBuilder(String.Empty, 17);
           segundos = Int32.Parse(tempo, new CultureInfo("pt-BR"));
           horas = (segundos / 3600);
           if (horas > 0)
           {
               segundos = segundos - (horas * 3600);
               retorno.Append(horas.ToString());
               retorno.Append("h");
           }
           minutos = (segundos / 60);
           if (minutos > 0)
           {
               segundos = segundos - (minutos * 60);
               retorno.Append(" ");
               retorno.Append(minutos.ToString());
               retorno.Append("min");
           }
           if (segundos > 0)
           {
               retorno.Append(" ");
               retorno.Append(segundos.ToString());
               retorno.Append("s");
           }

           // em caso de zero
           if (horas == 0 && minutos == 0 && segundos == 0)
           {
               retorno.Append("0 s");
           }

           return retorno.ToString();
       }


       /// <summary>
       /// Formatar o RG (99.999.999-X)
       /// </summary>
       /// <param name="texto">Texto que contém um numero de RG</param>
       /// <param name="incluirDigitoVerificador"></param>
       /// <returns>RG formatado.</returns>
       /// <example>
       /// <c>Transformador.FormatarRg("34657482X");</c><br></br>
       /// Resultado: 34.657.482-X
       /// </example>
       public static string FormatarRg(string texto, bool incluirDigitoVerificador)
       {
           // só inclui digitos se a string for maior que 1
           if (texto.Length > 1 && incluirDigitoVerificador)
               return FormatarNumeroInteiro(texto.Substring(0, texto.Length - 1))
                   + "-"
                   + texto.Substring(texto.Length - 1, 1);

           // formata sem digito
           return FormatarNumeroInteiro(texto);
       }

       /// <summary>
       /// Formatar o CPF (##9.999.999-99).
       /// </summary>
       /// <param name="texto">Texto que contém um número de CPF</param>
       /// <returns>CPF formatado.</returns>
       /// <example>
       /// <c>Transformador.FormatarCpf("22159151888");</c><br></br>
       /// Resultado: 221.591.518-88
       /// </example>
       public static string FormatarCpf(string texto)
       {
           string numerosContidos = ExtrairTodosNumerosContidos(texto);
           var grupos = RegexExtrairGrupos(numerosContidos, @"^([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})$");

           if (grupos.Count != 5)
               return texto;

           return grupos[1]
          + "." + grupos[2]
          + "." + grupos[3]
          + "-" + grupos[4];
       }

       /// <summary>
       /// Formatar um CNPJ
       /// </summary>
       /// <param name="texto">Texto que contém um número de CNPJ</param>
       /// <returns>CNPJ formatado.</returns>
       /// <example>
       /// <c>Transformador.FormatarCnpj("XXXXXXXXXXXXXX");</c><br></br>
       /// Resultado: XX.XXX.XXX/XXXX-XX
       /// </example>
       public static string FormatarCnpj(string texto)
       {
           string numerosContidos = ExtrairTodosNumerosContidos(texto);
           var grupos = RegexExtrairGrupos(numerosContidos, @"^([0-9]{2})([0-9]{3})([0-9]{3})([0-9]{4})([0-9]{2})$");

           if (grupos.Count != 6)
               return texto;

           return grupos[1]
          + "." + grupos[2]
          + "." + grupos[3]
          + "/" + grupos[4]
          + "-" + grupos[5];
       }

       /// <summary>
       /// Decide qual formatação aplicar: CPF ou CNPJ conforme o tamanho do "numero" passado.
       /// </summary>
       /// <param name="cpfOuCnpj">CPF ou CNPJ não formatado</param>
       /// <returns>CPF ou CNPJ - formatado</returns>
       public static string FormatarCpfCnpj(string cpfOuCnpj)
       {
           string numerosContidos = ExtrairTodosNumerosContidos(cpfOuCnpj);
           return numerosContidos.Length == 11 ? FormatarCpf(cpfOuCnpj) : FormatarCnpj(cpfOuCnpj);
       }

       /// <summary>
       /// Formatar o CEP.
       /// </summary>
       /// <param name="texto">Cep</param>
       /// <returns>Texto com separador</returns>
       /// <example>
       /// <c>Transformador.FormatarCep("04725050");</c><br></br>
       /// Resultado: 04725-050
       /// </example>
       public static string FormatarCep(string texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return String.Empty;
           Regex reg;
           string pat = @"^(\d{5})(\d{3})$";
           texto = texto.Trim().PadRight(8, '0');
           if (texto.Length == 0)
               return "";
           reg = new Regex(pat);
           Match m = reg.Match(texto);
           int tamanho = m.Groups.Count;
           if (tamanho >= 2)
               return m.Groups[1].Value
                      + "-" + m.Groups[2].Value;
           else
               return String.Empty;
       }

       /// <summary>
       /// Formatar o número do telefone.
       /// </summary>
       /// <param name="texto">Telefone</param>
       /// <returns>Telefone formatado</returns>
       /// <example>
       /// <c>Transformador.FormatarTelefone("55247874");</c><br></br>
       /// Resultado: 5524-7874.
       /// </example>
       public static string FormatarTelefone(string texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.Length == 0)
               return String.Empty;
           return InserirSeparador(texto, "-", 4);
       }

       /// <summary>
       /// Formatar o código do DDD e o número do telefone
       /// </summary>
       /// <param name="ddd">DDD</param>
       /// <param name="telefone">Telefone</param>
       /// <returns>DDD e telefone formatados</returns>
       /// <c>Transformador.FormatarTelefone("11", "55247874");</c><br></br>
       /// Resultado: (11) 5524-7874.
       public static string FormatarTelefone(string ddd, string telefone)
       {
           if (ddd == null)
               throw new ArgumentNullException("ddd");
           if (telefone == null)
               throw new ArgumentNullException("telefone");
           if (ddd.Trim().Length == 0)
               return FormatarTelefone(telefone);
           return "(" + ddd + ") " + FormatarTelefone(telefone);
       }

       /// <summary>
       /// Formatar o DDD, telefone e ramal.
       /// </summary>
       /// <param name="ddd">Ddd</param>
       /// <param name="telefone">Telefone</param>
       /// <param name="ramal">Ramal</param>
       /// <returns>DDD, telefone e ramal formatados</returns>
       /// <example>
       /// <c>Transformador.FormatarTelefone("11", "55247874", "3068");</c><br></br>
       /// Resultado: (11) 5524-7874, ram. 3068
       /// </example>
       public static string FormatarTelefone(string ddd, string telefone, string ramal)
       {
           if (ddd == null)
               throw new ArgumentNullException("ddd");
           if (telefone == null)
               throw new ArgumentNullException("telefone");
           if (ramal == null)
               throw new ArgumentNullException("ramal");
           if (ramal.Trim().Length == 0)
               return FormatarTelefone(ddd, telefone);
           return "(" + ddd.Trim() + ") "
                  + FormatarTelefone(telefone.Trim())
                  + ", ram. "
                  + ramal.Trim();
       }

       /// <summary>
       /// Extrai e formata o DDD, telefone e ramal de um texto .
       /// </summary>
       /// <param name="dddTelefoneRamal">DDD, telefone e ramal.</param>
       /// <returns>DDD, telefone e ramal formatados</returns>
       /// <example>
       /// <c>Transformador.FormatarTelefone("55247874");</c><br></br>
       /// Resultado: 5524-7874<br></br>
       /// <c>Transformador.FormatarTelefone("11 55247874");</c><br></br>
       /// Resultado: (11) 5524-7874<br></br>
       /// <c>Transformador.FormatarTelefone("11 55247874 3068");</c><br></br>
       /// Resultado: (11) 5524-7874, ram. 3068
       /// </example>
       public static string ExtrairTelefone(string dddTelefoneRamal)
       {
           if (dddTelefoneRamal == null)
               throw new ArgumentNullException("dddTelefoneRamal");
           string ddd = "";
           string tel = "";
           string ram = "";

           dddTelefoneRamal = ExtrairTodosNumerosContidos(dddTelefoneRamal);

           if (dddTelefoneRamal.Length > 0)
           {
               if (dddTelefoneRamal.Length <= 8)
               {
                   return FormatarTelefone(dddTelefoneRamal);
               }
               else if (dddTelefoneRamal.Length <= 10)
               {
                   ddd = dddTelefoneRamal.Substring(0, 2);
                   tel = dddTelefoneRamal.Substring(2, dddTelefoneRamal.Length - 2);
                   return FormatarTelefone(ddd, tel);
               }
               else
               {
                   ddd = dddTelefoneRamal.Substring(0, 2);
                   tel = dddTelefoneRamal.Substring(2, 8);
                   ram = dddTelefoneRamal.Substring(10, dddTelefoneRamal.Length - 10);
                   return FormatarTelefone(ddd, tel, ram);
               }
           }
           else
               return String.Empty;
       }

       /// <summary>
       /// Insere separador da direita para esquerda.
       /// </summary>
       /// <param name="texto">Texto origem</param>
       /// <param name="separador">Separador</param>
       /// <param name="casas">Número de casas decimais</param>
       /// <returns>Texto com os separadores</returns>
       /// <example>
       /// <c>Transformador.InserirSeparador("123123123", ".", 3);</c><br></br>
       /// Resultado: 123.123.123<br></br>
       /// <c>Transformador.InserirSeparador("ABC", ", ", 2);</c><br></br>
       /// Resultado: A, BC
       /// </example>
       public static string InserirSeparador(string texto, string separador, int casas)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (separador == null)
               throw new ArgumentNullException("separador");

           var resposta = new StringBuilder();

           char[] lista = texto.ToCharArray();
           if (lista.Length > 0)
               resposta.Append(lista[0]);

           for (int i = 1; i < lista.Length; i++)
           {
               // -- Verifica a necessidade de inserir um separador
               if ((lista.Length - i) % casas == 0)
                   resposta.Append(separador);
               resposta.Append(lista[i]);
           }
           return resposta.ToString();
       }

       /// <summary>
       /// Formata um número inteiro incluíndo separadores de milhar.
       /// </summary>
       /// <param name="texto">Número</param>
       /// <returns>Número formatado</returns>
       /// <example>
       /// <c>Transformador.FormatarNumeroInteiro("1000");</c><br></br>
       /// Resultado: 1.000<br></br>
       /// <c>Transformador.FormatarNumeroInteiro("Total: R$ 1000"):</c><br></br>
       /// Resultado: 1.000
       /// </example>
       public static string FormatarNumeroInteiro(object texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.ToString().Length > 0)
           {
               string extrairTodosNumerosContidos = ExtrairTodosNumerosContidos(texto.ToString());
               if (extrairTodosNumerosContidos.Length > 0)
               {
                   //Verifica se possui sinal
                   if (extrairTodosNumerosContidos.Substring(0, 1) == "-" || extrairTodosNumerosContidos.Substring(0, 1) == "+")
                       return extrairTodosNumerosContidos.Substring(0, 1) +
                              InserirSeparador(extrairTodosNumerosContidos.Substring(1, extrairTodosNumerosContidos.Length - 1), ".", 3);
                   else
                       return InserirSeparador(extrairTodosNumerosContidos, ".", 3);
               }
               return texto.ToString();
           }
           else
               return String.Empty;
       }

       /// <summary>
       /// Formata um número inteiro incluíndo separadores de milhar, porém limita o tamanho.
       /// </summary>
       /// <param name="texto">Número</param>
       /// <param name="tamanho">Tamanho máximo da saída</param>
       /// <returns>Número formatado</returns>
       public static string FormatarNumeroInteiro(string texto, int tamanho)
       {
           return FormatarNumeroInteiro(texto).Substring(0,
                                                         (FormatarNumeroInteiro(texto).Length <= tamanho
                                                              ? FormatarNumeroInteiro(texto).Length
                                                              : tamanho));
       }

       ///// <summary>
       ///// Formata um número de ponto-flutuante, inserindo separadores de milhar.
       ///// </summary>
       ///// <param name="texto">Número</param>
       ///// <returns>Número formatado</returns>
       ///// <example>
       ///// <c>Transformador.FormatarNumeroDecimal("1000,99");</c><br></br>
       ///// Resultado: 1.000,99
       ///// </example>
       //public static string FormatarNumeroDecimal(string texto)
       //{
       //    return FormatarNumeroDecimal(texto);
       //    if (texto == null)
       //        throw new ArgumentNullException("texto");
       //    Regex reg;
       //    string pat = @"^([-+]?\d+)\,?(\d+)?$";
       //    if (texto.Length == 0)
       //        return texto;
       //    texto = texto.Trim();
       //    reg = new Regex(pat);
       //    Match m = reg.Match(texto);
       //    string parteinteira = FormatarNumeroInteiro(m.Groups[1].Value);
       //    if (parteinteira.Length == 0)
       //    {
       //        parteinteira = texto;
       //        return FormatarNumeroInteiro(texto);
       //    }
       //    else
       //    {
       //        if (m.Groups.Count >= 1)
       //            return FormatarNumeroInteiro(m.Groups[1].Value)
       //                   + "," + ((m.Groups[2].Value.Length == 0) ? ("00") : (m.Groups[2].Value));
       //        else
       //            return texto;
       //    }
       //}

       /// <summary>
       /// Formata o número com o numero de casas decimais preterido.
       /// </summary>
       /// <param name="num">número</param>
       /// <param name="qtdCasasDecimais">Quantidade de casas decimais</param>
       /// <param name="separadorMilhar">Indica de vai haver separador de milhar (ex: 1.000)</param>
       /// <param name="globalizacao">formato padrão = pt-BR</param>
       /// <returns>Número formatado</returns>
       /// <example>
       /// <c>Transformador.FormatarNumeroDecimal("1000,9", 2);</c><br></br>
       /// Resultado: 1.000,90
       /// </example>
       public static string FormatarNumeroDecimal(object num,
           int qtdCasasDecimais = 2,
           bool separadorMilhar = true,
           Globalizacao globalizacao = Globalizacao.pt_BR)
       {
           // obtém a mascara conforme a internacionalização
           string mascara = GetMascaraNumerica(separadorMilhar, qtdCasasDecimais, globalizacao);

           decimal numeroDecimal = 0;
           // extrai o numero não importando o tipo que veio
           if (num is string)
               numeroDecimal = ObterNumeroDecimal(num.ToString());
           else
               numeroDecimal = Convert.ToDecimal(num);

           // retorna o numero formatado
           return numeroDecimal.ToString(mascara, ObterFormatProvider(globalizacao));
       }


       /// <summary>
       /// Obtem máscara para utilizar no ToString para numero inteiro e decimal
       /// </summary>
       /// <param name="separadorMilhar">terá separador de milhar?</param>
       /// <param name="qtdCasasDecimais">quantidade de casas decimais</param>
       /// <param name="globalizacao">qual o formato internacional de resposta</param>
       /// <returns></returns>
       public static string GetMascaraNumerica(bool separadorMilhar, int qtdCasasDecimais = 2, Globalizacao globalizacao = Globalizacao.pt_BR)
       {
           var mascara = new StringBuilder();

           // o # é porque é opcional
           if (separadorMilhar)
               mascara.Append("#,##0");


           // é sempre ponto para separador de decimal, a resposta que varia conforme a cultura
           if (qtdCasasDecimais > 0)
           {
               mascara.Append(".");
               mascara.Append(PreencherVazio(String.Empty, "0", Lado.Direito, qtdCasasDecimais));
           }

           return mascara.ToString();
       }

       public static IFormatProvider ObterFormatProvider(Globalizacao globalizacao)
       {
           if (globalizacao == Globalizacao.en_US)
               return CultureInfo.GetCultureInfo("en-US");

           return CultureInfo.GetCultureInfo("pt-BR");
       }

       /// <summary>
       /// Permite preencher a quantidade de casas necessárias faltantes.
       /// </summary>
       /// <param name="texto">Texto de origem</param>
       /// <param name="textVazio">Texto que preenche o vazio</param>
       /// <param name="ladoDirEsq">Lado a ser preenchido. Esquerdo ou direito.</param>
       /// <param name="quantidade">Tamanho do destino</param>
       /// <returns>Texto com a quantidade de caracteres especificada</returns>
       /// <example>
       /// <c>PreencherVazio("123", "0", Lado.Esquerdo, 5);</c><br></br>
       /// Resultado: "00123"
       /// </example>
       public static string PreencherVazio(string texto, string textVazio, Lado ladoDirEsq, int quantidade)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (textVazio == null)
               throw new ArgumentNullException("textVazio");
           if (texto.Length == quantidade)
               return texto;
           else if (texto.Length > quantidade)
           {
               if (ladoDirEsq == Lado.Direito)
                   return texto.Substring(0, quantidade);
               else if (ladoDirEsq == Lado.Esquerdo)
                   return texto.Substring(texto.Length - quantidade, quantidade);
           }
           else if (texto.Length < quantidade)
           {
               if (ladoDirEsq == Lado.Direito)
                   return texto + RepetirString(textVazio, quantidade - texto.Length);
               else if (ladoDirEsq == Lado.Esquerdo)
                   return RepetirString(textVazio, quantidade - texto.Length) + texto;
           }
           return texto;
       }

       /// <summary>
       /// Zeros à esquerda
       /// </summary>
       /// <param name="texto">texto.</param>
       /// <param name="quantidade">quantidade.</param>
       /// <returns></returns>
       public static string ZeroEsquerda(string texto, int quantidade)
       {
           return PreencherVazio(texto, "0", Lado.Esquerdo, quantidade);
       }

       /// <summary>
       /// Repete uma string a quantidade especificada
       /// </summary>
       /// <param name="texto">Texto de origem</param>
       /// <param name="quantidade">Quantidade de repetições</param>
       /// <returns>Texto repetido</returns>
       private static string RepetirString(string texto, int quantidade)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           var retorno = new StringBuilder();
           if ((quantidade > 0) && (texto.Length > 0))
           {
               for (int i = 1; i <= quantidade; i++)
               {
                   retorno.Append(texto);
               }
               return retorno.ToString();
           }
           else
               return texto;
       }



       /// <summary>
       /// Formata um valor monetário com uma determinada quantidade de casas os decimais.
       /// </summary>
       /// <param name="texto">Valor</param>
       /// <param name="decimais">Numero de decimais. Os demais serão truncados!</param>
       /// <returns>Valor formatado</returns>
       /// <example>
       /// <c>Transformador.FormatarValorMonetario("123123,23123123", 2);</c><br></br>
       /// Resultado: R$ 123.123,23
       /// </example>
       public static string FormatarValorMonetario(object texto, int decimais)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           if (texto.ToString().Length > 0)
               return SimboloMoeda + " " + FormatarNumeroDecimal(texto, decimais);
           else
               return String.Empty;
       }

       /// <summary>
       /// Extrair um número contido em um texto.
       /// </summary>
       /// <param name="texto">Texto contendo o valor</param>
       /// <returns>Número inteiro</returns>
       /// <example>
       /// <c>Transformador.ObterNumeroInteiro("123.123,12");</c><br></br>
       /// Resultado: 12312312<br></br>
       /// <c>Transformador.ObterNumeroInteiro("1a2a3a4");</c><br></br>
       /// Resultado: 1234
       /// </example>
       public static int ObterNumeroInteiro(string texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           string valor = ExtrairTodosNumerosContidos(texto);
           if (valor.Length > 0)
               return Int32.Parse(ExtrairTodosNumerosContidos(texto), new CultureInfo("pt-BR"));
           else
               return 0;
       }

       public static Int64 ObterNumeroLong(string texto)
       {
           if (texto == null)
               throw new ArgumentNullException("texto");
           string valor = ExtrairTodosNumerosContidos(texto);
           if (valor.Length > 0)
               return Int64.Parse(ExtrairTodosNumerosContidos(texto), new CultureInfo("pt-BR"));
           else
               return 0;
       }

       /// <summary>
       /// Extrair um número contido em um texto.
       /// </summary>
       /// <param name="texto">Texto contendo o valor</param>
       /// <returns>Número inteiro</returns>
       /// <example>
       /// <c>Transformador.ObterNumeroInteiro("123.123,12");</c><br></br>
       /// Resultado: 12312312<br></br>
       /// <c>Transformador.ObterNumeroInteiro("1a2a3a4");</c><br></br>
       /// Resultado: 1234
       /// </example>
       public static int? ObterNumeroInteiroNull(string texto)
       {
           if (texto == null)
               return null;
           string valor = ExtrairTodosNumerosContidos(texto);
           if (valor.Length > 0)
               return Int32.Parse(ExtrairTodosNumerosContidos(texto), new CultureInfo("pt-BR"));
           else
               return null;
       }

       /// <summary>
       /// Obter booleano.
       /// </summary>
       /// <param name="texto">The texto.</param>
       /// <returns></returns>
       public static bool ObterBooleano(string texto)
       {
           texto = texto.Replace("&nbsp;", "");
           if (texto == "1"
               || texto.ToUpper() == "TRUE"
               || texto.ToUpper() == "VERDADEIRO")
               return true;
           if (texto == "0"
               || texto.ToUpper() == "FALSE"
               || texto.ToUpper() == "FALSO")
               return false;
           return (texto.Length > 0);
       }

       /// <summary>
       /// Extrair um número de ponto-flutuante contido em um texto.
       /// </summary>
       /// <param name="texto">Texto contendo o valor</param>
       /// <returns>Número de ponto-flutuante</returns>
       /// <example>
       /// <c>Transformador.ObterNumeroInteiro("123.123,12");</c><br></br>
       /// Resultado: 123123.12<br></br>
       /// <c>Transformador.ObterNumeroInteiro("1a2a3a4");</c><br></br>
       /// Resultado: 1.0
       /// </example>
       public static decimal ObterNumeroDecimal(string texto)
       {
           string valor = ExtrairNumeroDecimal(texto);

           if (!String.IsNullOrEmpty(valor))
               return Decimal.Parse(valor, new CultureInfo("pt-BR"));

           return 0;
       }

       /// <summary>
       /// Tenta extrair a data de um texto. Caso não consiga, retorna (DateTime?)null.
       /// </summary>
       /// <param name="texto">Texto contendo uma data</param>
       /// <returns>Data</returns>
       public static DateTime? ObterData(string texto)
       {
           DateTime dataRetornada;
           bool converteu = DateTime.TryParse(FormatarDataBr(texto, TipoData.Data), new CultureInfo("pt-BR"), DateTimeStyles.AssumeLocal, out dataRetornada);
           if (converteu)
               return dataRetornada;

           return null;
       }

       /// <summary>
       /// Tenta extrair a data de um texto. Caso não consiga, retorna (DateTime?)null.
       /// </summary>
       /// <param name="texto">Texto contendo uma data</param>
       /// <returns>Data</returns>
       public static DateTime? ObterDataHora(string texto)
       {
           DateTime dataRetornada;
           bool converteu = DateTime.TryParse(FormatarDataBr(texto, TipoData.DataHoraSegundos), new CultureInfo("pt-BR"), DateTimeStyles.AssumeLocal, out dataRetornada);
           if (converteu)
               return dataRetornada;

           return null;
       }

       /// <summary>
       /// Retorna apenas o nome da página de um endereço html
       /// </summary>
       /// <param name="texto">URL de alguma página</param>
       /// <returns>Nome da página</returns>
       /// <example>
       /// <c>Transformador.ExtrairPaginaUrl("http://localhost/MesaCredito/teste.aspx");</c><br></br>
       /// Resultado: "teste.aspx"
       /// </example>
       public static string ExtrairPaginaUrl(string texto)
       {
           return RegexExtrairGrupos(texto, @"^.*/(\w+(\.aspx?|\.html?|\.php)?)?\??.*$")[1];
       }

       /// <summary>
       /// Gera um dataSet a partir de uma string
       /// </summary>
       /// <param name="dados">string a ser passada. 
       /// Primeiro as colunas, depois os dados - "," separa os dados
       /// e "|" as linhas</param>
       /// <example>
       /// A seguinte string:
       /// 
       /// nomeCampo1,nomeCampo2|dado1,dado2|dado3,dado4
       /// _____________________________________________
       /// Gera o seguinte dataset:
       /// 
       /// nomeCampo1	nomeCampo2
       /// dado1		dado2
       /// dado3		dado4
       /// </example>
       /// <returns>Um DataSet!!</returns>
       public static DataTable GerarDataTable(string dados)
       {
           if (dados == null)
               throw new ArgumentNullException("dados");
           var dt = new DataTable("Linha");
           dt.Locale = CultureInfo.InvariantCulture;

           DataRow dr;
           string[] linhas = dados.Split('|');
           string[] colunas;

           // ** Tem mais de uma linha?
           if (linhas.Length < 2)
               return null;

           for (int i = 0; i < linhas.Length; i++)
           {
               if (i == 0)
               {
                   //Header
                   colunas = linhas[i].Split(',');
                   for (int j = 0; j < colunas.Length; j++)
                   {
                       dt.Columns.Add(colunas[j], Type.GetType("System.String"));
                   }
               }
               else
               {
                   //Popula as linhas
                   dr = dt.NewRow();
                   colunas = linhas[i].Split(',');
                   for (int j = 0; j < colunas.Length; j++)
                   {
                       dr[j] = colunas[j];
                   }
                   dt.Rows.Add(dr);
               }
           }
           return dt;
       }

       /// <summary>
       /// Retira caracteres que podem entrar em conflito em um alert ou tooltip
       /// </summary>
       /// <param name="texto">Texto com sujeiras [\r\n'"]</param>
       /// <returns>Texto sem sujeiras</returns>
       public static string PrepararTextoJavaScript(string texto)
       {
           string retorno = texto.Replace("\n", "\\n");
           retorno = retorno.Replace("'", "\\'");
           retorno = retorno.Replace("\"", "\\\"");
           retorno = retorno.Replace("\r", "\\r");
           return retorno;
       }

       /// <summary>
       /// Obtem um nome válido para o arquivo
       /// </summary>
       /// <param name="nome">Nome do arquivo</param>
       /// <returns>Nome do arquivo</returns>
       public static string PrepararNomeArquivo(string nome)
       {
           if (nome == null)
               return nome;

           //troca caracteres especiais por _
           nome = Regex.Replace(nome,
                                @"(\s|>|<|\||\?|\'|\""|#|!|\.|@|\$|%|\^|\&|\*|\|\>|\<|\(|\)|\-|\+|\=|\{|\}|\[|\]|\:|\;|\,|\.|\\|\/)",
                                "_");

           //retira _____ em sequencia
           nome = Regex.Replace(nome,
                    @"_{2,}",
                    "");

           return nome;
       }

       /// <summary>
       /// Transforma uma tabela em uma string
       /// </summary>
       /// <param name="dt">The dt.</param>
       /// <param name="separador">The separador.</param>
       /// <param name="cabecalho">if set to <c>true</c> [cabecalho].</param>
       /// <param name="nomeColunas">The nome colunas.</param>
       /// <returns></returns>
       public static string Table2Csv(DataTable dt, string[] nomeColunas = null, string separador = ";", bool cabecalho = true)
       {
           var sb = new StringBuilder();
           //Cria cabeçalho
           if (cabecalho)
           {
               if (nomeColunas != null && nomeColunas.Length > 0)
               {
                   for (int i = 0; i < nomeColunas.Length; i++)
                   {
                       sb.Append(nomeColunas[i]);
                       if (i < dt.Columns.Count - 1)
                           sb.Append(separador);
                   }
               }
               else
               {
                   for (int i = 0; i < dt.Columns.Count; i++)
                   {
                       sb.Append(dt.Columns[i].ColumnName);
                       if (i < dt.Columns.Count - 1)
                           sb.Append(separador);
                   }
               }
               sb.Append("\r\n");
           }
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
               {
                   sb.Append("\"");
                   sb.Append(dt.Rows[i].ItemArray[j].ToString().Trim());
                   sb.Append("\"");
                   if (j < dt.Rows[i].ItemArray.Length - 1)
                       sb.Append(separador);
               }
               if (i < dt.Rows.Count - 1)
                   sb.Append("\r\n");
           }
           return sb.ToString();
       }

       /// <summary>
       /// Conveter string para data.
       /// </summary>
       /// <param name="Valor">String a ser convertida</param>
       /// <returns>Data no formato yyyyMMdd. Se a conversão não for possível, retorna nulo</returns>
       public static DateTime? ConverterParaDateTimeAnoMesDia(string Valor)
       {
           try
           {
               return DateTime.ParseExact(Valor, "yyyyMMdd", new CultureInfo("en-US"));
           }
           catch
           {
               return null;
           }
       }
       /// <summary>
       /// Aplicar mascara usando o formato ##.###.### onde se utiliza do caracter
       /// (#) para simbolizar qualquer caracter do string e o separador '.','/' (ou seja qualquer um) para aplicação da máscara 
       /// </summary>
       /// <param name="mascara"></param>
       /// <param name="valor"></param>
       /// <returns></returns>
       public static string FormataString(string mascara, string valor)
       {
           string novoValor = String.Empty;
           int posicao = 0;


           for (int i = 0; mascara.Length > i; i++)
           {
               if (mascara[i] == '#')
               {
                   if (valor.Length > posicao)
                   {
                       novoValor = novoValor + valor[posicao];

                       posicao++;
                   }
                   else
                       break;
               }
               else
               {
                   if (valor.Length > posicao)
                       novoValor = novoValor + mascara[i];
                   else
                       break;
               }
           }
           return novoValor;
       }

       /// <summary>
       /// Retorna o atributo Description de cada elemento do enumerador.
       /// </summary>
       /// <param name="value">Enumerador</param>
       /// <returns>String</returns>
       public static string GetEnumDescription(Enum value)
       {
           FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

           if (fieldInfo == null)
           {
               return value.ToString();
           }

           DescriptionAttribute[] descriptionAttribute = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
           return (descriptionAttribute.Length > 0) ? descriptionAttribute[0].Description : value.ToString();
       }

       public static double ObterNumeroDouble(string texto)
       {
           string valor = ExtrairNumeroDecimal(texto);

           if (!String.IsNullOrEmpty(valor))
               return Double.Parse(valor, new CultureInfo("pt-BR"));

           return 0;
       }

       public static string TirarAcentos(string texto)
       {
           string textor = "";

           for (int i = 0; i < texto.Length; i++)
           {
               if (texto[i].ToString() == "ã") textor += "a";
               else if (texto[i].ToString() == "á") textor += "a";
               else if (texto[i].ToString() == "à") textor += "a";
               else if (texto[i].ToString() == "â") textor += "a";
               else if (texto[i].ToString() == "ä") textor += "a";
               else if (texto[i].ToString() == "é") textor += "e";
               else if (texto[i].ToString() == "è") textor += "e";
               else if (texto[i].ToString() == "ê") textor += "e";
               else if (texto[i].ToString() == "ë") textor += "e";
               else if (texto[i].ToString() == "í") textor += "i";
               else if (texto[i].ToString() == "ì") textor += "i";
               else if (texto[i].ToString() == "ï") textor += "i";
               else if (texto[i].ToString() == "õ") textor += "o";
               else if (texto[i].ToString() == "ó") textor += "o";
               else if (texto[i].ToString() == "ò") textor += "o";
               else if (texto[i].ToString() == "ö") textor += "o";
               else if (texto[i].ToString() == "ú") textor += "u";
               else if (texto[i].ToString() == "ù") textor += "u";
               else if (texto[i].ToString() == "ü") textor += "u";
               else if (texto[i].ToString() == "ç") textor += "c";
               else if (texto[i].ToString() == "Ã") textor += "A";
               else if (texto[i].ToString() == "Á") textor += "A";
               else if (texto[i].ToString() == "À") textor += "A";
               else if (texto[i].ToString() == "Â") textor += "A";
               else if (texto[i].ToString() == "Ä") textor += "A";
               else if (texto[i].ToString() == "É") textor += "E";
               else if (texto[i].ToString() == "È") textor += "E";
               else if (texto[i].ToString() == "Ê") textor += "E";
               else if (texto[i].ToString() == "Ë") textor += "E";
               else if (texto[i].ToString() == "Í") textor += "I";
               else if (texto[i].ToString() == "Ì") textor += "I";
               else if (texto[i].ToString() == "Ï") textor += "I";
               else if (texto[i].ToString() == "Õ") textor += "O";
               else if (texto[i].ToString() == "Ó") textor += "O";
               else if (texto[i].ToString() == "Ò") textor += "O";
               else if (texto[i].ToString() == "Ö") textor += "O";
               else if (texto[i].ToString() == "Ú") textor += "U";
               else if (texto[i].ToString() == "Ù") textor += "U";
               else if (texto[i].ToString() == "Ü") textor += "U";
               else if (texto[i].ToString() == "Ç") textor += "C";
               else textor += texto[i];
           }
           return textor;
       }

       public static decimal ObterNumeroDuasCasasDecimaisSemArredondamento(decimal numero)
       {
           return System.Math.Truncate(numero * 100) / 100;
       }

       public static string ConverterPrimeiraMinuscula(string texto)
       {
           var primeiraLetra = texto.Substring(0, 1);
           var resto = texto.Substring(1, texto.Length - 1);
           return primeiraLetra.ToLower() + resto;
       }

       public static string ConverterPrimeiraMaiuscula(string texto)
       {
           if (string.IsNullOrEmpty(texto))
               return texto;

           var primeiraLetra = texto.Substring(0, 1).ToUpper();
           var resto = texto.Substring(1, texto.Length - 1).ToLower();
           return string.Format("{0}{1}", primeiraLetra, resto);
       }

       /// <summary>
       /// Escreve A exceção com o stackTrace e todas as inner exception de dentro
       /// Enviar segundo parâmetro igual a false. o True é só para as chamadas recursivas
       /// </summary>
       /// <param name="ex">Exceção a tratar</param>
       /// <param name="isRecursive">Indica se haverá recursão</param>
       /// <returns>Texto com a exceção tratada</returns>
       public static string EscreverExcecaoCompleta(Exception ex, bool isRecursive)
       {
           StringBuilder exceptionString = new StringBuilder();

           if (isRecursive)
               exceptionString.AppendFormat("INNER EXCEPTION {0}<br>", Environment.NewLine);
           else
               exceptionString.AppendFormat("EXCEPTION {0}<br>", Environment.NewLine);

           if (ex != null)
           {
               exceptionString.AppendFormat("Exception Message:{0}{1}{2}", Environment.NewLine, ex.Message, Environment.NewLine);
               exceptionString.AppendFormat("<br><br>Stack Trace:{0}{1}{2}", Environment.NewLine, ex.StackTrace, Environment.NewLine);
               exceptionString.AppendFormat("<br><br>Source:{0}{1}{2}", Environment.NewLine, ex.Source, Environment.NewLine);

               //recurse into inner exceptions
               if (ex.InnerException != null)
               {
                   exceptionString.Append(String.Format("{0}{1}", EscreverExcecaoCompleta(ex.InnerException, true), Environment.NewLine));
               }
           }
           return exceptionString.ToString();
       }
       /// <summary>
       /// Escreve A exceção com o stackTrace e todas as inner exception de dentro
       /// Enviar segundo parâmetro igual a false. o True é só para as chamadas recursivas
       /// </summary>
       /// <param name="ex">Exceção a tratar</param>
       /// <param name="isRecursive">Indica se haverá recursão</param>
       /// <param name="includeStackTrace">Indica se vai incluir o stack trace</param>
       /// <returns>Texto com a exceção tratada</returns>
       public static string EscreverExcecaoCompleta(Exception ex, bool isRecursive, bool includeStackTrace)
       {
           var exceptionString = new StringBuilder();

           exceptionString.AppendFormat(isRecursive ? "INNER EXCEPTION {0}<br>" : "EXCEPTION {0}<br>", Environment.NewLine);

           if (ex != null)
           {
               exceptionString.AppendFormat("Exception Message:{0}{1}{2}", Environment.NewLine, ex.Message, Environment.NewLine);
               if (includeStackTrace) exceptionString.AppendFormat("<br><br>Stack Trace:{0}{1}{2}", Environment.NewLine, ex.StackTrace, Environment.NewLine);
               exceptionString.AppendFormat("<br><br>Source:{0}{1}{2}", Environment.NewLine, ex.Source, Environment.NewLine);

               //recurse into inner exceptions
               if (ex.InnerException != null && isRecursive)
               {
                   exceptionString.Append(String.Format("{0}{1}", EscreverExcecaoCompleta(ex.InnerException, true, includeStackTrace), Environment.NewLine));
               }
           }

           return exceptionString.ToString();
       }
       /// <summary>
       /// Escreve A exceção com o stackTrace e todas as inner exception de dentro
       /// Enviar segundo parâmetro igual a false. o True é só para as chamadas recursivas
       /// </summary>
       /// <param name="ex">Exceção a tratar</param>
       /// <param name="isRecursive">Indica se haverá recursão</param>
       /// <param name="includeStackTrace">Indica se vai incluir o stack trace</param>
       /// <param name="includeSource">Indica se vai incluir o source</param>
       /// <returns>Texto com a exceção tratada</returns>
       public static string EscreverExcecaoCompleta(Exception ex, bool isRecursive, bool includeStackTrace, bool includeSource)
       {
           var exceptionString = new StringBuilder();

           exceptionString.AppendFormat(isRecursive ? "INNER EXCEPTION {0}<br>" : "EXCEPTION {0}<br>", Environment.NewLine);

           if (ex != null)
           {
               exceptionString.AppendFormat("Exception Message:{0}{1}{2}", Environment.NewLine, ex.Message, Environment.NewLine);
               if (includeStackTrace) exceptionString.AppendFormat("<br><br>Stack Trace:{0}{1}{2}", Environment.NewLine, ex.StackTrace, Environment.NewLine);
               if (includeSource) exceptionString.AppendFormat("<br><br>Source:{0}{1}{2}", Environment.NewLine, ex.Source, Environment.NewLine);

               //recurse into inner exceptions
               if (ex.InnerException != null && isRecursive)
               {
                   exceptionString.Append(String.Format("{0}{1}", EscreverExcecaoCompleta(ex.InnerException, true, includeStackTrace, includeSource), Environment.NewLine));
               }
           }

           return exceptionString.ToString();
       }
       /// <summary>
       /// Monta um dicionário a partir de um Enum contendo na chave o atributo de descrição e no valor o int/string do item do Enum
       /// </summary>
       /// <typeparam name="T">Tipo de Enum a obter</typeparam>
       /// <returns></returns>
       public static Dictionary<string, int> ObterChaveValorEnum<T>()
       {
           var dicionario = new Dictionary<string, int>();

           var tipo = typeof(T);

           Array valores = Enum.GetValues(tipo);
           string[] nomes = Enum.GetNames(tipo);

           int i = 0;

           foreach (int valor in valores)
           {
               bool adicionaItem = true;

               var fieldInfo = tipo.GetField(nomes[i]);

               // Verifica se o enum possui o atributo [VisivelEnum(false)], se tiver, não adiciona.
               object[] customListBindableAttribute =
                   fieldInfo.GetCustomAttributes(typeof(ListBindableAttribute), false);

               if (customListBindableAttribute != null &&
                   customListBindableAttribute.Length > 0)
               {
                   var bindAttribute = customListBindableAttribute.First() as ListBindableAttribute;

                   if (!bindAttribute.ListBindable)
                   {
                       adicionaItem = false;
                   }
               }

               if (adicionaItem)
               {
                   DescriptionAttribute descAttribute;

                   object[] customDescriptionAttribute =
                       fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                   if (customDescriptionAttribute != null &&
                       customDescriptionAttribute.Length > 0)
                   {
                       descAttribute = customDescriptionAttribute.First() as DescriptionAttribute;
                   }
                   else
                   {
                       descAttribute = new DescriptionAttribute(nomes[i]);
                   }

                   dicionario.Add(descAttribute.Description, valor);
               }

               i++;
           }

           return dicionario;
       }
       /// <summary>
       /// Adiciona todos os valores de um Enum em lista.
       /// </summary>
       /// <typeparam name="T">Tipo de Enum a converter</typeparam>
       public static List<T> ConverterEnumParaList<T>() where T : struct
       {
           var lista = new List<T>();

           foreach (var valor in Enum.GetValues(typeof(T)))
           {
               T temp;

               if (Enum.TryParse(valor.ToString(), out temp))
                   lista.Add(temp);
           }

           return lista;
       }

       /// <summary>
       /// http://www.thereforesystems.com/fundamentals-deep-cloning-in-c/
       /// </summary>
       public static object DeepClone(object objeto)
       {
           object clone;
           using (var stream = new MemoryStream())
           {
               var formatter = new BinaryFormatter();            // Serialize this object            
               formatter.Serialize(stream, objeto); stream.Position = 0;            // Deserialize to another object            
               clone = formatter.Deserialize(stream);
           }
           return clone;
       }

       public static string ConverterCamelCase(string texto)
       {
           if (string.IsNullOrEmpty(texto))
               return texto;

           string[] palavras = texto.Split(' ');
           var resultado = new StringBuilder();
           int indiceUltimoItem = palavras.Length - 1;

           for (int i = 0; i < palavras.Length; i++)
           {
               resultado.Append(ConverterPrimeiraMaiuscula(palavras[i]));

               // se nao for ultimo
               if (i != indiceUltimoItem)
               {
                   resultado.Append(" ");
               }
           }

           return resultado.ToString();
       }

       public static DateTime PrepararDataInicial(DateTime dataInicial)
       {
           return new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, 0, 0, 0);
       }

       public static DateTime PrepararDataFinal(DateTime dataFinal)
       {
           return new DateTime(dataFinal.Year, dataFinal.Month, dataFinal.Day, 23, 59, 59);
       }

       public static DateTime? PrepararDataInicial(DateTime? dataInicial)
       {
           return (dataInicial.HasValue) ? new DateTime?(PrepararDataInicial(dataInicial.Value)) : null;
       }

       public static DateTime? PrepararDataFinal(DateTime? dataFinal)
       {
           return (dataFinal.HasValue) ? new DateTime?(PrepararDataFinal(dataFinal.Value)) : null;
       }

       public static string ObterTabelaHtmlChaveValorPor(Dictionary<string, string> chaveValor)
       {
           var detalhes = new StringBuilder();

           detalhes.Append("<table class='Tooltip'>");

           foreach (KeyValuePair<string, string> pair in chaveValor)
           {
               if (!String.IsNullOrWhiteSpace(pair.Value))
               {
                   detalhes.Append("<tr>");
                   detalhes.Append("<td>" + pair.Key + ":</td>");
                   detalhes.Append("<td>" + pair.Value + "</td>");
                   detalhes.Append("</tr>");
               }
           }

           detalhes.Append("</table>");

           return detalhes.ToString();
       }

       /// <summary>
       /// Recebe um array de strings contendo numeros e converte para um IList de inteiros
       /// </summary>
       /// <param name="stringDeInteiros"></param>
       /// <returns></returns>
       public static IList<int> ConverterParaListaDeInteiros(string[] stringDeInteiros)
       {
           return Array.ConvertAll(stringDeInteiros.Where(x => !string.IsNullOrEmpty(x)).ToArray(), Convert.ToInt32).ToList();
       }

       public static string FormatarVendaIdMesaDespachante(string vendaId)
       {
           try
           {
               return Convert.ToInt32(vendaId).ToString();
           }
           catch
           {
               return ExtrairTodosNumerosContidos(vendaId, 2);
           }
       }
    }

   public enum Globalizacao
   {
       pt_BR,
       en_US
   }
}