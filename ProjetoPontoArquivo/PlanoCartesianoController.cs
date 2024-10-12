using modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle
{
    public class PlanoCartesianoController
    {

        public ArrayList selecionarPontosPorSemiplano(int codigo)
        {
            ArrayList pontosSelecionados = new ArrayList();
            PlanoCartesianoDAO dao = new PlanoCartesianoDAO();
            ArrayList listaPontos = dao.obterTodos(1, true);

            // Filtra os pontos com base no código do semi-plano
            for (int i = 0; i < listaPontos.Count; i++)
            {
                PontoVO ponto = (PontoVO)listaPontos[i];

                switch (codigo)
                {
                    case 1: // Direita
                        if (ponto.X > 0)
                        {
                            pontosSelecionados.Add(ponto);
                        }
                        break;

                    case 2: // Esquerda
                        if (ponto.X < 0)
                        {
                            pontosSelecionados.Add(ponto);
                        }
                        break;

                    case 3: // Superior
                        if (ponto.Y > 0)
                        {
                            pontosSelecionados.Add(ponto);
                        }
                        break;

                    case 4: // Inferior
                        if (ponto.Y < 0)
                        {
                            pontosSelecionados.Add(ponto);
                        }
                        break;

                    default:
                        // Código inválido
                        break;
                }
            }

            return pontosSelecionados;
        }

        public ArrayList selecionarPontosSemiPlanoImpar()
        {
            ArrayList lista = null;
            PlanoCartesianoDAO dao = new PlanoCartesianoDAO();
            lista = dao.obterTodos(1, true);

            ArrayList pontosSemiPlanoImpar = new ArrayList();

            for (int i = 0; i < lista.Count; i++)
            {
                PontoVO objeto = (PontoVO)lista[i];

                double resultado = objeto.X * objeto.Y;
                if (resultado > 0)
                {
                    pontosSemiPlanoImpar.Add(objeto);
                }
            }
            return pontosSemiPlanoImpar;
        }

        public ArrayList selecionarPontosSemiPlanoPar()
        {
            ArrayList lista = null;
            PlanoCartesianoDAO dao = new PlanoCartesianoDAO();
            lista = dao.obterTodos(1, true);

            ArrayList pontosSemiPlanoPar = new ArrayList();

            for (int i = 0; i < lista.Count; i++)
            {
                PontoVO objeto = (PontoVO)lista[i];

                double resultado = objeto.X * objeto.Y;
                if (resultado < 0)
                {
                    pontosSemiPlanoPar.Add(objeto);
                }
            }
            return pontosSemiPlanoPar;
        }

        public ArrayList selecionarPontos(int tipoFigura)
        {
            ArrayList pontosSelecionados = new ArrayList();
            PlanoCartesianoDAO dao = new PlanoCartesianoDAO();
            ArrayList listaPontos = dao.obterTodos(1, true);

            // Filtra os pontos com base no código do semi-plano
            for (int i = 0; i < listaPontos.Count; i++)
            {
                PontoVO ponto = (PontoVO)listaPontos[i];

                if (ponto.TipoFigura == tipoFigura)
                {
                    pontosSelecionados.Add(ponto);
                }

            }

            return pontosSelecionados;

        }
    }
}