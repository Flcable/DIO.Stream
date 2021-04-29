using System;
using DIO.Stream.Classes;

namespace DIO.Stream
{
    class Program
    {
        static SerieRepositorio reposerie = new SerieRepositorio();
        static FilmeRepositorio repofilme = new FilmeRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "S1":
                        ListarSeries();
                        break;

                    case "S2":
                        InserirSerie();
                        break;

                    case "S3":
                        AtualizarSerie();
                        break;

                    case "S4":
                        ExcluirSerie();
                        break;

                    case "S5":
                        VisualizarSerie();
                        break;

                     case "F1":
                        ListarFilme();
                        break;

                    case "F2":
                        InserirFilme();
                        break;

                    case "F3":
                        AtualizarFilme();
                        break;

                    case "F4":
                  //      ExcluirFilme();
                        break;

                    case "F5":
                  //      VisualizarFilme();
                        break;


                    case "C":
                        Console.Clear();
                        break; 

                    default:
                        throw new ArgumentOutOfRangeException();                   
                }
                opcaoUsuario = ObterOpcaoUsuario();  
            }
            Console.WriteLine("Obrigado por utilizar o nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = reposerie.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "**Excluido**" : ""));
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série: ");

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: reposerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            reposerie.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digte o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            reposerie.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine("");

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

             reposerie.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = reposerie.RetornaPorId(indiceSerie);

            Console.Write(serie); 
        }

        ////////////////////////////////////////////////////////////////Filmes////////////////////////////////////////////

        //Listar Filmes
         private static void ListarFilme()
        {
            Console.WriteLine("Listar filmes");
            var lista = repofilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "**Excluido**" : ""));
            }

        }

        // Inserir Filmes

         private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme: ");

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repofilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repofilme.Insere(novoFilme);

        }

        // Atualizar Filmes

        private static void AtualizarFilme()
        {
             Console.WriteLine("Inserir novo filme: ");
              int indiceFilme = int.Parse(Console.ReadLine());

            foreach ( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repofilme.Atualiza(indiceFilme, atualizaFilme);
            Console.WriteLine("");

        }

        // Excluir Filmes

         private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

             repofilme.Exclui(indiceFilme);
        }

        // Visualizar Filmes
         private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repofilme.RetornaPorId(indiceFilme);

            Console.Write(filme); 
        }





         private static string ObterOpcaoUsuario()
        {
             Console.WriteLine();
             Console.Write("#"); Console.Write("############################"); Console.WriteLine("#");
             Console.Write("#"); Console.Write("############################"); Console.WriteLine("#");
             Console.Write("# ");Console.WriteLine("DIO Streams a seu dispor!!! #");
             Console.Write("# ");Console.WriteLine("Informe a opção desejada:  #");
             Console.Write("# ");Console.WriteLine("                           #");

             Console.Write("# ");Console.WriteLine("S1 - Listar série          #");
             Console.Write("# ");Console.WriteLine("S2 - Inserir nova série    #");
             Console.Write("# ");Console.WriteLine("S3 - Atualizar série       #");
             Console.Write("# ");Console.WriteLine("S4 - Excluir série         #");
             Console.Write("# ");Console.WriteLine("S5 - Visualizar série      #");
             Console.Write("# ");Console.WriteLine("                           #");


             Console.Write("#"); Console.Write("**************************"); Console.WriteLine("  #");
             Console.Write("# ");Console.WriteLine("                           #");


             Console.Write("# ");Console.WriteLine("F1 - Listar filme          #");
             Console.Write("# ");Console.WriteLine("F2 - Inserir novo filme    #");
             Console.Write("# ");Console.WriteLine("F3 - Atualizar filme       #");
             Console.Write("# ");Console.WriteLine("F4 - Excluir filme         #");
             Console.Write("# ");Console.WriteLine("F5 - Visualizar filme      #");
             Console.Write("# ");Console.WriteLine("                           #");

             Console.Write("# ");Console.WriteLine("C - Limpar a tela          #");
             Console.Write("# ");Console.WriteLine("X - Sair                   #");
             Console.Write("# ");Console.WriteLine("                           #");
             Console.Write("#"); Console.Write("############################"); Console.WriteLine("#");
             Console.Write("#"); Console.Write("############################"); Console.WriteLine("#");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
