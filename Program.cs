using System;

namespace CadastroSeries
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOptions = GetUserOptions();
            while (userOptions.ToUpper() != "X")
            {
                switch (userOptions)
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
                        DeleteSerie();
                        break;
                    case "5":
                        VisualizeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOptions = GetUserOptions();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            repository.Delete(indexSerie);
        }

        private static void VisualizeSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(indexSerie);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int indexSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputDescription = Console.ReadLine();

            Series updateSerie = new Series(Id: indexSerie,
                                         genero: (Gender)inputGender,
                                         titulo: inputTitle,
                                         ano: inputYear,
                                         descricao: inputDescription);

            repository.Update(indexSerie, updateSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listar séries:");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in list)
            {
                var exclude = serie.returExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitulo(), exclude ? "*Excluído*": "");
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string inputTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string inputDescription = Console.ReadLine();

            Series newSerie = new Series(Id: repository.ProximoId(),
                                         genero: (Gender)inputGender,
                                         titulo: inputTitle,
                                         ano: inputYear,
                                         descricao: inputDescription);
            repository.Insert(newSerie);
        }

        private static string GetUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Sistema de Séries");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Lista séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
