using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using RDev.ToolsSys.Business.Help;

namespace System.Linq
{
    /// <summary>
    /// Todas os Extension Methods não pertencentes a tipos específicos
    /// </summary>
    public static class GeneralExtensions
    {
        /// <summary>
        /// Usa o Split, mas devolve um int array
        /// </summary>
        /// <param name="original">Texto a separar</param>
        /// <param name="delimiter">Delimitador</param>
        public static int[] SplitInt(this string original, string delimiter)
        {
            var temp = SplitToList(original, delimiter);
            if (temp.IsNullOrEmpty()) return null;

            List<int> retorno;

            try
            {
                retorno = new List<int>();
                temp.ToList().ForEach(item => retorno.Add(item.ToInt()));
            }
            catch (Exception)
            {
                return null;
            }

            return retorno.ToArray();
        }

        /// <summary>
        /// Cria uma IList separando o texto original usando o delimitador
        /// Se o texto for nulo ou em branco, devolve null
        /// </summary>
        /// <param name="original">Texto a separar</param>
        /// <param name="delimiter">Delimitador</param>
        public static IList<string> SplitToList(this string original, string delimiter)
        {
            if (string.IsNullOrWhiteSpace(original)) return null;

            var temp = original.Split(delimiter.ToCharArray());

            return temp.Count() <= 0 ? new List<string> { original } : temp.ToList();
        }


        /// <summary>
        /// Verifica se um número está entre o valor inicial ou final
        /// </summary>
        /// <param name="origem">Número a verificar</param>
        /// <param name="inicio">Número inicial</param>
        /// <param name="fim">Número final</param>
        /// <param name="Inclusive">Flag para indicar se o valor inicial e final também será considerado na verificação</param>
        public static bool Between(this int origem, int inicio, int fim, bool Inclusive = true)
        {
            return (Inclusive) ? (origem >= inicio) && (origem <= fim) : (origem > inicio) && (origem < fim);
        }

        /// <summary>
        /// Verifica se um número está entre o valor inicial ou final
        /// </summary>
        /// <param name="origem">Número a verificar</param>
        /// <param name="inicio">Número inicial</param>
        /// <param name="fim">Número final</param>
        /// <param name="Inclusive">Flag para indicar se o valor inicial e final também será considerado na verificação</param>
        public static bool Between(this decimal origem, decimal inicio, decimal fim, bool Inclusive = true)
        {
            return (Inclusive) ? (origem >= inicio) && (origem <= fim) : (origem > inicio) && (origem < fim);
        }

        /// <summary>
        /// Verifica se uma data está entre uma data inicial ou final
        /// </summary>
        /// <param name="origem">Data a verificar</param>
        /// <param name="inicio">Data inicial</param>
        /// <param name="fim">Data final</param>
        /// <param name="Inclusive">Flag para indicar se a data inicial e final também será considerado na verificação</param>
        public static bool Between(this DateTime origem, DateTime inicio, DateTime fim, bool Inclusive = true)
        {
            return (Inclusive) ? (origem >= inicio) && (origem <= fim) : (origem > inicio) && (origem < fim);
        }


        /// <summary>
        /// Verifica se um objeto é nulo
        /// </summary>
        /// <param name="obj">Objeto a Verificar</param>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }


        /// <summary>
        /// Retorna o valor de origem com o percentual informado já aplicado
        /// </summary>
        /// <param name="origem">Valor original</param>
        /// <param name="percentual">Percentual a aplicar. Para somar, use percentual positivo. Para subtrair, use percentual negativo</param>
        public static decimal Percent(this decimal origem, decimal percentual)
        {
            return origem + (origem * (percentual / 100));
        }

        /// <summary>
        /// Verifica se o valor está em uma variação percentual de tolerância a partir de um valor base
        /// </summary>
        /// <param name="origem">Valor a verificar</param>
        /// <param name="valorBase">Base de valor a aplicar o percentual de variação</param>
        /// <param name="percentual">Percentual de variação</param>
        public static bool IsInTolerance(this decimal origem, decimal valorBase, decimal percentual)
        {
            var absPercent = Math.Abs(percentual);
            var min = valorBase.Percent(absPercent * -1);
            var max = valorBase.Percent(absPercent);

            return origem.Between(min, max);
        }


        /// <summary>
        /// Retorna o valor passado convertido para int, se não oferecer conversão, retorna zero
        /// </summary>
        /// <param name="origem">valor de origem</param>
        public static int ToInt<T>(this T origem)
        {
            if (origem is Enum)
                return (int)(object)origem;

            int resultado;
            return origem.IsNull() || !int.TryParse(origem.ToString(), out resultado) ? 0 : resultado;
        }

        /// <summary>
        /// Retorna o valor passado convertido para decimal, se não oferecer conversão, retorna zero
        /// </summary>
        /// <param name="origem">valor de origem</param>
        public static decimal ToDecimal<T>(this T origem)
        {
            decimal resultado;

            if (origem.IsNull()) return 0;

            try
            {
                var strValue = origem.ToString();

                //Tratamento para retirar símbolo monetário
                strValue = strValue.Replace(NumberFormatInfo.CurrentInfo.CurrencySymbol, "");

                resultado = !decimal.TryParse(strValue, out resultado) ? 0 : resultado;
            }
            catch { return 0; }

            return resultado;
        }

        /// <summary>
        /// Retorna o valor passado convertido para long, se não oferecer conversão, retorna zero
        /// </summary>
        /// <param name="origem">valor de origem</param>
        public static long ToLong<T>(this T origem)
        {
            long resultado;

            if (origem.IsNull()) return 0;

            try
            {
                resultado = !long.TryParse(origem.ToString(), out resultado) ? 0 : resultado;
            }
            catch { return 0; }

            return resultado;
        }

        /// <summary>
        /// Retorna o valor passado convertido para bool, se não oferecer conversão, retorna false
        /// </summary>
        /// <param name="origem">valor de origem</param>
        public static bool ToBool<T>(this T origem)
        {
            bool resultado;
            return !(origem.IsNull() || !bool.TryParse(origem.ToString(), out resultado)) && resultado;
        }


        /// <summary>
        /// Retorna o valor passado convertido para int?, se não oferecer conversão, retorna null
        /// </summary>
        /// <param name="origem">valor de origem</param>
        public static int? ToNullableInt<T>(this T origem)
        {
            int resultado;
            return origem.IsNull() || !int.TryParse(origem.ToString(), out resultado) ? null : new int?(resultado);
        }

        /// <summary>
        /// Retorna o valor passado convertido para int?, se não oferecer conversão ou for igual ao valor de substituicao, retorna null
        /// </summary>
        /// <param name="origem">valor de origem</param>
        /// <param name="nullValue">Valor a considerar como nulo</param>
        public static int? ToNullableInt<T>(this T origem, int nullValue)
        {
            int resultado;
            return origem.IsNull() || !int.TryParse(origem.ToString(), out resultado) || resultado == nullValue ? null : new int?(resultado);
        }


        /// <summary>
        /// Converte a primeira letra da string para maiúscula
        /// </summary>
        /// <param name="origem">string a analisar</param>
        public static string CapitalizeFirst(this string origem)
        {
            if (string.IsNullOrWhiteSpace(origem))
                return string.Empty;

            var a = origem.ToCharArray();
            a[0] = char.ToUpper(a[0]);

            return new string(a);
        }


        /// <summary>
        /// Converte o boolean para "Sim" ou "Não"
        /// </summary>
        /// <param name="origem">boolean a analisar</param>
        public static string SimOuNao(this bool origem)
        {
            return origem ? "Sim" : "Não";
        }

        /// <summary>
        /// Verifica se uma string está contida em uma lista de itens de enum, como a funcao IN do T-SQL, buscando pelo atributo description
        /// </summary>
        /// <param name="source">String a verificar</param>
        /// <param name="list">Valores a comparar, separados por vírgula</param>
        public static bool InByEnumDescription(this string source, params Enum[] list)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (list.IsNullOrEmpty()) return false;

            return list.Any(t => t.GetDescription() == source);
        }

        /// <summary>
        /// Verifica se uma string está contida em uma lista de outras strings, como a funcao IN do T-SQL
        /// </summary>
        /// <param name="source">String a verificar</param>
        /// <param name="list">Valores a comparar, separados por vírgula</param>
        public static bool In(this string source, params string[] list)
        {
            if (string.IsNullOrWhiteSpace(source)) return false;
            if (list.IsNullOrEmpty()) return false;

            return list.Any(t => t == source);
        }
    }

    /// <summary>
    /// Extension Methods para Date e Time
    /// </summary>
    public static class DateAndTimeExtensions
    {
        private const int AnoMinimoSQL = 1753;

        /// <summary>
        /// Converte horas decimais para TimeSpan (tempo)
        /// </summary>
        /// <param name="time">Horas Decimais</param>
        public static TimeSpan ToTime(this decimal time)
        {
            var dTime = Convert.ToDouble(time) * 60;
            var dRef = new DateTime().AddMinutes(dTime);

            return dRef.TimeOfDay;
        }

        /// <summary>
        /// Converte um TimeSpan (tempo) para texto no formato HH:MM
        /// </summary>
        /// <param name="time">Hora a converter</param>
        public static string ToHHMMString(this TimeSpan time)
        {
            return string.Format("{0:00}:{1:00}", time.Hours, time.Minutes);
        }

        /// <summary>
        /// Converte uma hora decimal para texto no formato HH:MM
        /// </summary>
        /// <param name="decimalTime">Hora decimal a converter</param>
        public static string ToHHMMString(this decimal decimalTime)
        {
            return decimalTime.ToTime().ToHHMMString();
        }

        /// <summary>
        /// Converte uma hora em texto para horas em decimal
        /// </summary>
        /// <param name="stringTime">Hora a converter</param>
        public static decimal ToDecimalTime(this string stringTime)
        {
            return Convert.ToDecimal(TimeSpan.Parse(stringTime).TotalHours);
        }

        /// <summary>
        /// Verifica se a Data eh valida para o SQL Server (para evitar o erro )
        /// </summary>
        /// <param name="data">Data para verificar</param>
        /// <returns>Data verificada (exemplo: se o ano informado foi 1750, retorna 1753</returns>
        public static DateTime CheckDataSQL(this DateTime data)
        {
            int qtdeAno = 0;

            if (data.Year < AnoMinimoSQL)
                qtdeAno = AnoMinimoSQL - data.Year;

            return data.AddYears(qtdeAno);
        }

        /// <summary>
        /// Adiciona 23 horas, 59 minutos, 59 segundos e 999 milisegundos a data informada, para efeito de consulta no SQL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime AdicionaUltimaHora(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Retorna null se a data for igual à especificada ou realmente nula
        /// </summary>
        /// <param name="data">Data a Analisar</param>
        /// <param name="dateNull">Data a considerar nula</param>
        public static DateTime? NullIf(this DateTime? data, DateTime dateNull)
        {
            return data.GetValueOrDefault(dateNull) == dateNull ? null : data;
        }

        /// <summary>
        /// Retorna a string formatada de acordo com a cultura atual
        /// </summary>
        /// <param name="data">data a converter</param>
        /// <param name="format">formato de retorno</param>
        public static string ToStringCurrentCulture(this DateTime data, string format)
        {
            return data.ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Valida se o texto informado é uma hora válida
        /// </summary>
        /// <param name="time">texto a analisar</param>
        public static bool IsValidTime(this string time)
        {
            TimeSpan resultado;
            return TimeSpan.TryParse(time, out resultado);
        }

        /// <summary>
        /// Converte um texto em hora
        /// </summary>
        /// <param name="stringTime">Texto (hora) a converter</param>
        public static TimeSpan ToTimeSpan(this string stringTime)
        {
            TimeSpan resultado;

            if (!stringTime.IsValidTime()) return TimeSpan.Zero;
            if (!TimeSpan.TryParse(stringTime, out resultado)) return TimeSpan.Zero;

            return resultado;
        }
    }

    /// <summary>
    /// Extension Methods para coleções e seus derivados
    /// </summary>
    public static class ICollectionGenericExtensions
    {
        /// <summary>
        /// Remove um conjunto de itens de uma coleção
        /// </summary>
        /// <param name="source">Coleção a remover</param>
        /// <param name="itensToRemove">Itens a remover</param>
        public static void RemoveRange<T>(this ICollection<T> source, ICollection<T> itensToRemove)
        {
            foreach (var item in itensToRemove)
                source.Remove(item);
        }
    }

    /// <summary>
    /// Extension Methods para IEnumerable e seus derivados
    /// </summary>
    public static class IEnumerableGenericExtensions
    {
        /// <summary>
        /// Comparador genérico
        /// </summary>
        private class GenericComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, object> _uniqueCheckerMethod;

            public GenericComparer(Func<T, object> uniqueCheckerMethod)
            {
                _uniqueCheckerMethod = uniqueCheckerMethod;
            }

            public bool Equals(T x, T y)
            {
                return _uniqueCheckerMethod(x).Equals(_uniqueCheckerMethod(y));
            }

            public int GetHashCode(T obj)
            {
                return _uniqueCheckerMethod(obj).GetHashCode();
            }
        }

        /// <summary>
        /// Comparador genérico para campo
        /// </summary>
        private class GenericFieldComparer<T, F> where F : IEquatable<F>
        {
            private readonly Func<T, F> _uniqueCheckerMethod;

            public GenericFieldComparer(Func<T, F> uniqueCheckerMethod)
            {
                _uniqueCheckerMethod = uniqueCheckerMethod;
            }

            public bool Equals(T fieldToCompare, F fieldContent)
            {
                return fieldContent.Equals(_uniqueCheckerMethod(fieldToCompare));
            }

            public int GetHashCode(T obj)
            {
                return _uniqueCheckerMethod(obj).GetHashCode();
            }
        }

        /// <summary>
        /// Unifica uma lista de texto usando um delimitador
        /// </summary>
        /// <param name="original">Lista a unificar</param>
        /// <param name="delimiter">Delimitador</param>
        public static string JoinListToString(this IEnumerable<string> original, string delimiter)
        {
            var temp = String.Empty;

            if (original == null) return null;
            if (original.ToList().Count <= 0) return null;

            original.ToList().ForEach(i => temp += String.Concat(i, delimiter));
            string retorno = temp.TrimEnd(delimiter.ToCharArray());

            return retorno;
        }


        /// <summary>
        /// Verifica se uma lista é nula ou vazia
        /// </summary>
        /// <param name="source">Lista a verificar</param>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null) || (source.Count() <= 0);
        }

        /// <summary>
        /// Verifica se uma lista é nula ou vazia baseada em um campo
        /// </summary>
        /// <param name="source">Lista a verificar</param>
        /// <param name="field">Campo a verificar</param>
        /// <returns>Se algum campo na lista for nulo, retorna true</returns>
        public static bool IsAnyFieldNullOrEmpty<T, E>(this IEnumerable<T> source, Func<T, E> field) where T : class, new()
        {
            if (field == null)
                throw new ArgumentNullException("field", "O Campo a Verificar precisa ser informado.");

            var fieldList = from item in source.ToList() select new { tItem = field.Invoke(item) }.tItem;
            var retorno = from item in source where fieldList.IsNull() select item;

            return retorno.Count() > 0;
        }

        /// <summary>
        /// Unifica uma lista, baseada em um campo, de acordo com o delimitador
        /// </summary>
        /// <param name="source">Lista a unificar</param>
        /// <param name="stringField">Campo a considerar para unificação</param>
        /// <param name="delimiter">Delimitador</param>
        public static string JoinListToString<T>(this IEnumerable<T> source, Func<T, string> stringField, string delimiter)
        {
            return source.Select(stringField).JoinListToString(delimiter);
        }

        /// <summary>
        /// Procura um item em uma lista baseado em um campo
        /// </summary>
        /// <param name="source">Lista a procurar</param>
        /// <param name="field">Campo a verificar</param>
        /// <param name="valueToSearch">Valor a procurar no campo</param>
        public static T FindIn<T, E>(this IEnumerable<T> source, Func<T, E> field, E valueToSearch)
        {
            if (field == null)
                throw new ArgumentNullException("field", "O Campo a Verificar precisa ser informado.");

            if (valueToSearch.IsNull())
                throw new ArgumentNullException("valueToSearch", "O Valor a Buscar precisa ser informado.");

            return source.FirstOrDefault(x => field.Invoke(x).Equals(valueToSearch));
        }


        /// <summary>
        /// Realiza uma operação <see cref="Enumerable.Distinct{TSource}(System.Collections.Generic.IEnumerable{TSource})"/> com um comparador customizado, por exemplo, um campo da lista
        /// </summary>
        /// <param name="source">Lista a verificar</param>
        /// <param name="comparer">Comparador ou campo a utilizar</param>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, object> comparer)
        {
            return source.Distinct(new GenericComparer<T>(comparer));
        }


        /// <summary>
        /// Concatena um array de listas, não utilizando a lista de origem
        /// </summary>
        /// <param name="source">Lista de Origem (suporte)</param>
        /// <param name="lists">Listas a concatenar</param>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params IEnumerable<T>[] lists) where T : new()
        {
            return Concat(source, false, lists);
        }

        /// <summary>
        /// Concatena um array de listas, utilizando ou não a lista de origem
        /// </summary>
        /// <param name="source">Lista de Origem</param>
        /// <param name="addSelf">Indica se a lista de origem também será concatenada</param>
        /// <param name="lists">Listas a concatenar</param>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, bool addSelf, params IEnumerable<T>[] lists) where T : new()
        {
            var retorno = new List<T>();

            if (lists == null || lists.Count() <= 0)
                throw new ArgumentNullException("lists", "Nothing to concatenate.");

            if (addSelf)
            {
                if (source == null || source.Count() <= 0)
                    throw new ArgumentNullException("source", "No items found in source list to concatenate.");

                retorno.AddRange(source);
            }

            foreach (var list in lists)
                if (list != null && list.Count() > 0) retorno.AddRange(list);

            return retorno;
        }


        /// <summary>
        /// Agrupa uma Lista por um campo e retorna um dicionário onde a chave é esse campo e o valor é outro campo tipo int/decimal para somar
        /// </summary>
        /// <param name="source">Lista de Origem</param>
        /// <param name="fieldToGroup">Campo Chave</param>
        /// <param name="fieldToSum">Campo para somar (int ou decimal)</param>
        public static Dictionary<K, int> ToDictionarySum<K, T>(this IEnumerable<T> source, Func<T, K> fieldToGroup, Func<T, int> fieldToSum)
        {
            var retorno = new Dictionary<K, int>();

            if (source.IsNullOrEmpty()) return null;

            var agrupado = source.GroupBy(fieldToGroup.Invoke, fieldToSum.Invoke);
            if (agrupado.IsNullOrEmpty()) return null;

            agrupado.ToList().ForEach(i => retorno.Add(i.Key, i.Sum()));

            return retorno;
        }

        /// <summary>
        /// Agrupa uma Lista por um campo e retorna um dicionário onde a chave é esse campo e o valor é outro campo tipo int/decimal para somar
        /// </summary>
        /// <param name="source">Lista de Origem</param>
        /// <param name="fieldToGroup">Campo Chave</param>
        /// <param name="fieldToSum">Campo para somar (int ou decimal)</param>
        public static Dictionary<K, decimal> ToDictionarySum<K, T>(this IEnumerable<T> source, Func<T, K> fieldToGroup, Func<T, decimal> fieldToSum)
        {
            var retorno = new Dictionary<K, decimal>();

            if (source.IsNullOrEmpty()) return null;

            var agrupado = source.GroupBy(fieldToGroup.Invoke, fieldToSum.Invoke);
            if (agrupado.IsNullOrEmpty()) return null;

            agrupado.ToList().ForEach(i => retorno.Add(i.Key, i.Sum()));

            return retorno;
        }

        /// <summary>
        /// Retorna o primeiro da lista (executa um FirstOrDefault) ou uma nova instancia de T caso source seja nulo 
        /// </summary>
        /// <param name="source">Lista de Origem</param>
        public static T FirstOrNew<T>(this IEnumerable<T> source) where T : new()
        {
            return source.IsNullOrEmpty() ? new T() : source.FirstOrDefault();
        }

        /// <summary>
        /// Retorna o primeiro da lista (executa um FirstOrDefault) ou uma nova instancia de T caso source seja nulo 
        /// </summary>
        /// <param name="source">Lista de Origem</param>
        /// <param name="predicate">Filtro</param>
        public static T FirstOrNew<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : new()
        {
            return source.IsNullOrEmpty() ? new T() : predicate.IsNull() ? source.FirstOrDefault() : source.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Listar numero de registros em um IEnumerable. 
        /// <para>Motivo:</para>
        /// <para>IEnumerable não possui Count ou Length.</para>
        /// </summary>
        /// <param name="source">IEnumerable verificado.</param>
        /// <returns>Numero de itens no IEnumerable verificado</returns>
        public static int CountIEnumerable(this IEnumerable source)
        {
            if (source.IsNull()) return 0;

            //FIXME: poderia ser melhor este código.
            var numRegistros = 0;
            var e = source.GetEnumerator();

            while (e.MoveNext())
            {
                numRegistros++;
            }

            return numRegistros;
        }
    }

    /// <summary>
    /// Extension Methods para Enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Obtem o conteúdo do atributo "Description" do item da enum. Ver também Trans.<seealso cref="Trans.GetEnumDescription"/>
        /// </summary>
        /// <param name="element">Elemento da Enum a verificar</param>
        public static string GetDescription(this Enum element)
        {
            return FuncoesGerais.GetEnumDescription(element);
        }

        /// <summary>
        /// <para>Converte os elementos da enum informada para um Dicionário com os itens, onde: Key->Atributo Description, Value->int do valor da enum.</para>
        /// <para>Ver também Trans.<seealso cref="Trans.ObterChaveValorEnum{T}"/></para>
        /// </summary>
        /// <param name="origem">tem da enum para obter os itens e converter</param>
        public static Dictionary<string, int> ToDictionary<T>(this Enum origem)
        {
            return FuncoesGerais.ObterChaveValorEnum<T>();
        }

        /// <summary>
        /// Converte os elementos da enum informada para uma Lista
        /// </summary>
        /// <param name="origem">Item da enum para obter os itens e converter</param>
        public static List<T> ToList<T>(this Enum origem) where T : struct
        {
            return FuncoesGerais.ObterChaveValorEnum<T>().Values.Select(i => i.ToEnumValue<T>()).ToList();
        }

        /// <summary>
        /// Verifica se o item da enum existe na lista informada
        /// </summary>
        /// <param name="value">Valor a verificar</param>
        /// <param name="listToCompare">Lista a comparar</param>
        public static bool ExistsInList<T>(this Enum value, List<T> listToCompare)
        {
            if (value == null)
                throw new ArgumentNullException("value", "O campo a verificar não pode estar nulo.");

            if (listToCompare.IsNull())
                throw new ArgumentNullException("listToCompare", "Os valores a comparar precisam ser informados.");

            return listToCompare.Any(x => x.Equals(value));
        }

        /// <summary>
        /// Obtem o valor (int) de um elemento da Enum
        /// </summary>
        /// <param name="value">Elemento a verificar</param>
        public static int GetEnumValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }


        /// <summary>
        /// Obtem o elemento da enum baseado em seu valor numérico
        /// </summary>
        /// <param name="value">Valor a verificar</param>
        public static T ToEnumValue<T>(this int value) where T : struct
        {
            return ToEnumValue<T>(value.ToString());
        }

        /// <summary>
        /// Obtem o elemento da enum baseado em seu valor texto
        /// </summary>
        /// <param name="value">Valor a verificar</param>
        public static T ToEnumValue<T>(this string value) where T : struct
        {
            T resultado;

            Enum.TryParse(value, out resultado);

            return resultado;
        }

        /// <summary>
        /// Procura o elemento pelo conteúdo do atributo "Description"
        /// </summary>
        /// <param name="value">Valor a verificar</param>
        public static T? FindByEnumDescription<T>(this string value) where T : struct
        {
            int iResultado;
            var dicEnum = FuncoesGerais.ObterChaveValorEnum<T>();

            return dicEnum.TryGetValue(value, out iResultado) ? iResultado.ToEnumValue<T>() : new T?();
        }

        /// <summary>
        /// Verifica se um valor de enum está contido em uma lista de opçoes validas, como a funcao IN do T-SQL
        /// </summary>
        /// <param name="source">Enum a verificar</param>
        /// <param name="list">Valores a comparar, separados por vírgula</param>
        public static bool In(this Enum source, params Enum[] list)
        {
            if (source.IsNull()) return false;
            if (list.IsNullOrEmpty()) return false;

            return list.Any(t => t.GetEnumValue() == source.GetEnumValue());
        }
    }

    /// <summary>
    /// Extension methods para Dicionários
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adiciona um dicionário em outro
        /// </summary>
        /// <param name="source">Dicionário origem</param>
        /// <param name="dictionaryToAdd">Dicionário a adicionar</param>
        public static void AddRange<K, V>(this Dictionary<K, V> source, Dictionary<K, V> dictionaryToAdd)
        {
            if (source.IsNullOrEmpty()) return;
            if (dictionaryToAdd.IsNullOrEmpty()) return;

            foreach (var item in dictionaryToAdd)
                source.Add(item.Key, item.Value);
        }
    }
}

namespace System.Xml.Linq
{
    /// <summary>
    /// Extension Methods para Xml
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Verifica se um elemento é nulo ou vazio
        /// </summary>
        /// <param name="source">Elemento a verificar</param>
        public static bool IsNullOrEmpty(this XElement source)
        {
            return (source == null) || (source.IsEmpty);
        }
    }
}