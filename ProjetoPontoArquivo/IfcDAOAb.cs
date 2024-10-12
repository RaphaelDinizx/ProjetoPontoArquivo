using modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPontoArquivo
{
    internal interface IfcDAOAb
    {
        ArrayList obterTodos();
        ArrayList obterTodos(int tipoFigura);
        void inserir(PontoVO pontoVO);
        PontoVO pesquisar(PontoVO pontoVO);
        void alterar(PontoVO pontoVO);
        void excluir(PontoVO pontoVO);
    }
}
