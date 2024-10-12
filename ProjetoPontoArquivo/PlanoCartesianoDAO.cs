using modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProjetoPontoArquivo;

namespace modelo
{
    public class PlanoCartesianoDAO : IfcDAOAb
    {
        private List<PontoVO> memoria;

        public PlanoCartesianoDAO()
        {
            memoria = new List<PontoVO>();
            carregarDados();
        }

        // Método para carregar dados do arquivo para a memória
        public void carregarDados()
        {
            memoria.Clear();  // Limpar a memória atual antes de carregar novamente

            // Certifique-se de que o arquivo existe antes de tentar abri-lo
            if (!File.Exists(@"registros.txt"))
            {
                // Se não existir, você pode criar um arquivo vazio
                using (File.Create(@"registros.txt")) { }
                Console.WriteLine("Arquivo 'registros.txt' criado.");
                return; // Sai do método se o arquivo não existir
            }

            StreamReader rd = new StreamReader(@"registros.txt");
            string linha;
            while ((linha = rd.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(linha)) // Verifica se a linha não está vazia
                {
                    string[] tokens = linha.Split(';');

                    // Verifica se há tokens suficientes
                    if (tokens.Length >= 5)
                    {
                        try
                        {
                            PontoVO ponto = new PontoVO(
                                int.Parse(tokens[0]),
                                int.Parse(tokens[1]),
                                tokens[2],
                                double.Parse(tokens[3]),
                                double.Parse(tokens[4])
                            );
                            memoria.Add(ponto);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Formato inválido na linha: {linha}. Erro: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao processar a linha: {linha}. Erro: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida, menos de 5 tokens: {linha}");
                    }
                }
            }
            rd.Close(); // Feche o StreamReader após a leitura
        }

        // Implementação do método obterTodos
        public ArrayList obterTodos()
        {
            ArrayList lista = new ArrayList();

            foreach (PontoVO ponto in memoria)
            {
                lista.Add(ponto);
            }

            return lista;
        }

        public ArrayList obterTodos(int tipoFigura)
        {
            ArrayList listaFiltrada = new ArrayList();
            foreach (PontoVO ponto in memoria)
            {
                if (ponto.TipoFigura == tipoFigura)
                {
                    listaFiltrada.Add(ponto);
                }
            }
            return listaFiltrada;
        }

        // Implementação do método obterTodos com filtro por tipoFigura e flag
        public ArrayList obterTodos(int tipoFigura, bool flag)
        {
            return obterTodos(tipoFigura); // Chama o método anterior com o mesmo tipoFigura
        }

        // Implementação do método inserir
        public void inserir(PontoVO pontoVO)
        {
            // Adicionar o novo ponto na memória
            memoria.Add(pontoVO);
            // Marcar como "dirty" (modificado)
            salvar();
        }

        // Implementação do método pesquisar
        public PontoVO pesquisar(PontoVO pontoVO)
        {
            foreach (PontoVO ponto in memoria)
            {
                if (ponto.Equals(pontoVO))
                {
                    return ponto;
                }
            }
            return null;
        }

        // Implementação do método alterar
        public void alterar(PontoVO pontoVO)
        {
            for (int i = 0; i < memoria.Count; i++)
            {
                if (memoria[i].Codigo == pontoVO.Codigo)
                {
                    memoria[i] = pontoVO; // Atualizar o objeto
                    salvar(); // Marcar como "dirty" e salvar no arquivo
                    break;
                }
            }
        }

        // Implementação do método excluir
        public void excluir(PontoVO pontoVO)
        {
            for (int i = 0; i < memoria.Count; i++)
            {
                if (memoria[i].Codigo == pontoVO.Codigo)
                {
                    memoria.RemoveAt(i);
                    salvar(); // Marcar como "dirty" e salvar no arquivo
                    break;
                }
            }
        }

        // Método para salvar os dados no arquivo (Dirty Object)
        private void salvar()
        {
            using (StreamWriter writer = new StreamWriter(@"registros.txt", false))
            {
                foreach (PontoVO ponto in memoria)
                {
                    string linha = $"{ponto.Codigo};{ponto.TipoFigura};{ponto.Descricao};{ponto.X};{ponto.Y}";
                    writer.WriteLine(linha);
                }
            }
        }
    }
}
