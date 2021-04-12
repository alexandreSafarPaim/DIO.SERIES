using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository _repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOptions();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        ExcludeSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOptions();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadKey();

        }

        private static void ListSeries()
        {
            Console.Clear();
            Console.WriteLine("Listar séries...");
            var lista = _repository.List();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenuma série cadastrada");
            }
            else
            {
                Console.WriteLine("---------------Séries---------------");
                foreach (var serie in lista)
                {
                    Console.WriteLine($"#ID {serie.Id} - {serie.Title}{(serie.Excluded ? " - *Excluido*" : "")} ");
                }
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("Aperte uma tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        private static void InsertSerie()
        {
            Console.Clear();
            int gender = 0, year = 0;
            string title = "", description = "";

            Console.WriteLine("Escreva as informações da série que deseja inserir");

            SerieInfoInput(ref gender, ref title, ref description, ref year);

            Serie novaSerie = new Serie(id: _repository.NextId(),
                                    gender: (Gender)gender,
                                    title: title,
                                    year: year,
                                    description: description);

            _repository.Insert(novaSerie);

            Console.WriteLine();
            Console.WriteLine($"Série {novaSerie.Title} foi Incluida com sucesso");
            Console.WriteLine("Aperte uma tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        private static void UpdateSerie()
        {
            Console.Clear();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Serie oldSerie = _repository.ReturnId(idSerie);

            Console.WriteLine("As informações da serie selecionada são:");
            Console.WriteLine(oldSerie.ToString());

            Console.WriteLine();
            Console.WriteLine("--------Atualização--------");

            int gender = 0, year = 0;
            string title = "", description = "";

            SerieInfoInput(ref gender, ref title, ref description, ref year);

            Serie updatedSerie = new Serie(id: idSerie,
                                    gender: (Gender)gender,
                                    title: title,
                                    year: year,
                                    description: description);

            _repository.Update(idSerie, updatedSerie);

            Console.WriteLine();
            Console.WriteLine($"A série foi Atualizada com sucesso");
            Console.WriteLine("Aperte uma tecla para continuar");
            Console.ReadKey();
            Console.Clear();

        }

        private static void ExcludeSerie()
        {
            Console.Clear();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Serie serie = _repository.ReturnId(idSerie);

            if (serie.Excluded)
            {
                Console.WriteLine("");
                Console.WriteLine($"A série {serie.Title} já se encontra excluida");
                Console.WriteLine("Aperte uma tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("As informações da serie selecionada são:");
            Console.WriteLine(serie.ToString());
            Console.Write("Tem certeza que deseja excluir esta série? (S/N)");
            string exclude = Console.ReadLine().ToUpper();
            if (exclude == "S")
            {
                _repository.Delete(idSerie);

                Console.WriteLine($"Série {serie.Title} foi excluida com sucesso");
                Console.WriteLine("Aperte uma tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                return;
            }
        }

        private static void ViewSerie()
        {
            Console.Clear();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            Serie serie = _repository.ReturnId(idSerie);

            Console.WriteLine();
            Console.WriteLine("As informações da serie selecionada são:");
            Console.WriteLine(serie.ToString());
            Console.WriteLine("Aperte uma tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        private static string GetUserOptions()
        {
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine(
@"----------------------------
|| 1 - Listar séries      ||
|| 2 - Inserir nova série ||
|| 3 - Atualizar série    ||
|| 4 - Excluir série      ||
|| 5 - Visualizar série   ||
|| C - Limpar Tela        ||
|| X - Sair               ||
----------------------------");
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void SerieInfoInput(ref int gender, ref string title, ref string description, ref int year)
        {
            Console.WriteLine("----------Gêneros----------");
            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"    {i} - {Enum.GetName(typeof(Gender), i)}");
            }
            Console.WriteLine("---------------------------");
            Console.Write("Digite o gênero dentre as opções acima: ");
            gender = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            title = Console.ReadLine();

            Console.Write("Ano de Início: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            description = Console.ReadLine();
        }

    }
}
