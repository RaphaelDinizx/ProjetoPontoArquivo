using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace modelo
{
    public class PlanoCartesianoDAO
    {
        public ArrayList obterTodos()
        {
            ArrayList lista = new ArrayList();
            lista.Add("José");
            lista.Add("Maria");
            lista.Add("João");
            return lista;
        }
        public ArrayList obterTodos(int tipoFigura)
        {
            ArrayList lista = new ArrayList();
            string linha = "";
            StreamReader rd = new StreamReader(@"registros.txt");
            while (!rd.EndOfStream)
            {
                linha = rd.ReadLine();
                lista.Add(linha);
            }
            return lista;
        }

        public ArrayList obterTodos(int tipo, bool flag)
        {
            ArrayList lista = new ArrayList();
            string linha = "";
            string[] tokens = null;
            PontoVO pontoVO = null;

            StreamReader rd = new StreamReader(@"registros.txt");
            while (!rd.EndOfStream)
            {
                linha = rd.ReadLine();
                tokens = linha.Split(";");
                try
                {
                    pontoVO = new PontoVO(int.Parse(tokens[0]), int.Parse(tokens[1]), tokens[2], double.Parse(tokens[3]), double.Parse(tokens[4]));
                    lista.Add(pontoVO);
                }
                catch (Exception e)
                {
                    
                }                
            }
            return lista;
        }
    }
}
