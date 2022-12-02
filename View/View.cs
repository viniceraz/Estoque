using Estoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.View
{
    internal class View
    {
        public int exibirOpcoes()
        {
            Console.WriteLine("Opções:");
            Console.WriteLine("0 - Listar Produtos");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Finalizar");
            try
            {
                int opcaoRetorno = int.Parse(Console.ReadLine() ?? "");

                if (opcaoRetorno < 0 || opcaoRetorno > 2)
                {
                    throw new Exception("Selecione de uma opção de 0 a 2");
                }

                return opcaoRetorno;
            }
            catch (FormatException)
            {

                Console.WriteLine("Formato inválido");
                return exibirOpcoes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return exibirOpcoes();
            }
        }

        public int exibirProdutos(List<Produto> produtos)
        {
           
            Console.WriteLine("Código |    Descrição    |   Valor   |   Estoque");
            foreach (Produto produto in produtos)
            {
                Console.WriteLine(produto.id + "   |    "+produto.descricao + "    |   " + produto.valor + "   |   " + produto.estoqueAtual);
            }
            int idProduto = -1;
            while (idProduto == -1)
            {
                Console.WriteLine("Informe o código do produto ou 0 (Zero) para voltar");
                int.TryParse(Console.ReadLine(), out idProduto);
            }
            return idProduto;

        }

        public int exibirProduto(Produto produto)
        {
            int opcao = 0;
            Console.WriteLine("Selecionado: " + produto.descricao);
            Console.WriteLine("Valor: " + produto.valor);
            Console.WriteLine("estoque: " + produto.estoqueAtual);
            while (opcao < 1 || opcao > 4) 
            {
                Console.WriteLine("1 - Entrada de Estoque | 2 - Saída Estoque | 3 - Sair | 4 - Excluir produto ");
                int.TryParse(Console.ReadLine(), out opcao);
            }
            return opcao;
        }

        internal Produto CadastrarProduto()
        {
            string? descricao = "";
            double valor = 0;
            int estoque = 0;

            Console.WriteLine("Cadastrar novo produto");

            while (descricao == "")
            {
                Console.WriteLine("Informe o nome do produto");
                descricao = Console.ReadLine();
            }


            while (valor <= 0)
            {
                Console.WriteLine("Informe o valor do produto");
                string? _valor = Console.ReadLine();
                double.TryParse(_valor, out valor);
            }

            while (estoque <= 0)
            {
                Console.WriteLine("Informe a quantidade de produto em estoque");
                string? _estoque = Console.ReadLine();
                int.TryParse(_estoque, out estoque);
            }
            Produto novoProduto = new Produto();
            novoProduto.descricao = descricao;
            novoProduto.valor = valor;
            novoProduto.estoqueAtual = estoque;

            return novoProduto;

        }

        internal int recebeEstoque()
        {
            int quantidade = 0;
            while (quantidade==0)
            {
                Console.WriteLine("Informe a quantidade");
                int.TryParse(Console.ReadLine(), out quantidade);
            }
            return quantidade;
        }
    }
}
