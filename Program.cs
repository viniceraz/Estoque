
using Estoque.Model;
using Estoque.Repositories;
using Estoque.View;

View MainView = new View();
DataBase dataBase = new DataBase();


int opcaoSelecionada = 0;

while (opcaoSelecionada != 2)
{
    opcaoSelecionada = MainView.exibirOpcoes();

    if (opcaoSelecionada == 0)
    {
        ListarProdutos();
    }

    if (opcaoSelecionada == 1)
    {
        CadastrarProduto();
    }

}

void CadastrarProduto()
{
    Produto produto = MainView.CadastrarProduto();
    dataBase.Adicionar(produto);
    Console.WriteLine("Produto cadastrado com sucesso");
}

void ListarProdutos()
{
    List<Produto> produtos = dataBase.GetProdutos();
    int idProdutoSelecionado;
    idProdutoSelecionado = MainView.exibirProdutos(produtos);
    if (idProdutoSelecionado != 0)
    {
        SelecionarProduto(idProdutoSelecionado);
    }
}

void SelecionarProduto(int idProdutoSelecionado)
{
    try
    {
        Produto produto = dataBase.GetProduto(idProdutoSelecionado);
        int opcaoProduto = MainView.exibirProduto(produto);
        if (opcaoProduto != 3)
        {
            if (opcaoProduto == 1)
            {
                EntradaDeEstoque(produto);
                opcaoProduto = MainView.exibirProduto(produto);

            }
            else if (opcaoProduto == 2)
            {
                SaidaDeEstoque(produto);
                opcaoProduto = MainView.exibirProduto(produto);
            } else if (opcaoProduto == 4)
            {
                ExcluirProduto(produto);
                ListarProdutos();
            }

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ExcluirProduto(Produto produto)
{
    dataBase.Excluir(produto);
    Console.WriteLine("Produto excluído com sucesso");
}

void EntradaDeEstoque(Produto produto)
{
    int quantidade = MainView.recebeEstoque();
    produto.estoqueAtual += quantidade;
    produto = dataBase.Atualizar(produto);
}

void SaidaDeEstoque(Produto produto)
{
    int quantidade = MainView.recebeEstoque();
    produto.estoqueAtual -= quantidade;
    produto = dataBase.Atualizar(produto);

}