using Estoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Repositories
{
    internal class DataBase
    {
        private List<Produto> produtos;

        public DataBase()
        {
            produtos = new List<Produto>();

            Produto teste1 = new Produto()
            {
                descricao = "Teste 1",
                valor = 35.50,
                estoqueAtual = 10
            };

            Produto teste2 = new Produto()
            {
                descricao = "Teste 2",
                valor = 15,
                estoqueAtual = 3
            };
            Adicionar(teste1);
            Adicionar(teste2);


        }

        private int GetMaxId()
        {
            return produtos.Count > 0 ? produtos.Max(p => p.id) + 1 : 1;
        }

        public Produto Adicionar(Produto produto)
        {
            produto.id = GetMaxId();
            produtos.Add(produto);
            return produto;

        }
        public Produto Atualizar(Produto produto)
        {
            var _produto = produtos.Where(p => p.id == produto.id).FirstOrDefault();
            if (_produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            _produto.estoqueAtual = produto.estoqueAtual;

            return _produto;

        }
        public bool Excluir(Produto produto)
        {
            return produtos.Remove(produto);
        }


        public List<Produto> GetProdutos()
        {
            return produtos;
        }

        public Produto GetProduto(int id)
        {
            var produto = produtos.Where(p => p.id == id).FirstOrDefault();

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }

    }
}
