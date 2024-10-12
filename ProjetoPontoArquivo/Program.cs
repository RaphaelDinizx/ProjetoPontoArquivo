using modelo;
using System.Collections;
using controle;

namespace visao
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Início do Main");
            PlanoCartesianoDAO objetoPc1 = new PlanoCartesianoDAO();

            ArrayList lista = objetoPc1.obterTodos();

            Console.WriteLine("Imprime o código hard code");
            // Lê imprime os elementos hard coded
            for (int i=0; i<lista.Count; i++)
            {
                string objeto = (string) lista[i];
                Console.WriteLine(objeto);

            }

            // Lê imprime os elementos do arquivo
            lista = objetoPc1.obterTodos(1);
            Console.WriteLine("Imprime as linhas do arquivo");

            for (int i = 0; i < lista.Count; i++)
            {
                string objeto = (string)lista[i];
                Console.WriteLine(objeto);
            }

            // Lê imprime os objetos do tipo PontoVO
            lista = objetoPc1.obterTodos(1, true);
            Console.WriteLine("Imprime todos os pontos do arquivo");

            for (int i = 0; i < lista.Count; i++)
            {
                PontoVO objeto = (PontoVO) lista[i];
                Console.WriteLine(objeto);
            }

            // Lê imprime os pontos do semiplano ímpar
            PlanoCartesianoController objetoController = new PlanoCartesianoController();
            lista = objetoController.selecionarPontosSemiPlanoImpar();

            Console.WriteLine("Imprime todos os pontos do semi plano ímpar");

            for (int i = 0; i < lista.Count; i++)
            {
                PontoVO objeto = (PontoVO) lista[i];
                Console.WriteLine(objeto);
            }


            PlanoCartesianoDAO dao = new PlanoCartesianoDAO();

            // Inserir um novo ponto
            PontoVO novoPonto = new PontoVO(6, 1, "Novo Ponto", 10.5, -5.3);
            dao.inserir(novoPonto);

            // Pesquisar um ponto
            PontoVO pontoPesquisado = dao.pesquisar(new PontoVO(6));
            Console.WriteLine("Ponto Pesquisado: " + pontoPesquisado);

            // Alterar um ponto
            pontoPesquisado.Descricao = "Ponto Alterado";
            dao.alterar(pontoPesquisado);

            // Excluir um ponto
            dao.excluir(new PontoVO(6));

            Console.WriteLine("Operações concluídas.");


            Console.WriteLine("Fim do Main");
        }
    }
}
