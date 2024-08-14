
namespace Jogo.Core
{
    public class Estatistica
    {
        static string  Diretorio = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        static string file = Path.Combine(Diretorio, "Data", "Estatistica.csv");

        public static void AdicionarEstatista(string resultado)
        {
            int vitoriasJogador = Resultados("Jogador", "Vitorias");
            int vitoriasComputador = Resultados("Computador", "Vitorias");
            int empatesJogador = Resultados("Jogador", "Empates");
            int derrotasJogador = Resultados("Jogador", "Derrotas");
            int derrotasComputador = Resultados("Computador", "Derrotas");
            int empatesComputador = Resultados("Computador", "Empates");

            try
            {
                if (File.Exists(file))
                {
                    string[] lines = File.ReadAllLines(file);
                    foreach (string line in lines)
                    {
                        string tipo = line.Split(',')[0];
                        string jogo = line.Split(',')[1];
                        string valor = line.Split(',')[2];


                        if (resultado == "Jogador")
                        {
                            if (tipo == "Jogador")
                                if (jogo == "Vitorias")
                                {
                                    vitoriasJogador++;
                                    derrotasComputador++;
                                }  
                        }
                        else if (resultado == "Computador")
                        {
                            if(tipo == "Computador")
                                if(jogo == "Vitorias")
                                {
                                    derrotasJogador++;
                                    vitoriasComputador++;
                                }
                        }
                        else if (resultado == "Empate")
                        {
                            if (tipo == "Jogador")
                            {
                                if (jogo == "Empates")
                                    empatesJogador++;
                            }
                            else if (tipo == "Computador")
                            {
                                if (jogo == "Empates")
                                    empatesComputador++;
                            }
                                
                        }
                    }
                }





                using (StreamWriter wr = new StreamWriter(file))
                {
                    wr.WriteLine("Tipo,Jogo,Valor");

                    wr.WriteLine($"Jogador,Vitorias,{vitoriasJogador}");
                    wr.WriteLine($"Jogador,Derrotas,{derrotasJogador}");
                    wr.WriteLine($"Jogador,Empates,{empatesJogador}");

                    wr.WriteLine($"Computador,Vitorias,{vitoriasComputador}");
                    wr.WriteLine($"Computador,Derrotas,{derrotasComputador}");
                    wr.WriteLine($"Computador,Empates,{empatesComputador}");
                }

            }catch(Exception ex)
            {
                   Console.WriteLine($"Erro ao salvar os dados! {ex.Message}");
            }
        }

        private static int Resultados(string tipo, string jogo)
        {
            
            using(var reader = new StreamReader(file))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if(values[0] == tipo && values[1] == jogo)
                    {
                        return int.Parse(values[2]);
                    }
                  
                }
            }

            return 0;
        }

        public static void GerarResultados()
        {
            int vitorias = Resultados("Jogador", "Vitorias");
            int derrotas = Resultados("Jogador", "Derrotas");
            int empates = Resultados("Jogador", "Empates");

            Console.WriteLine($"Vitorias: {vitorias}");
            Console.WriteLine($"Derrotas: {derrotas}");
            Console.WriteLine($"Empates: {empates}");
        }
    }
}