using System;
using System.Windows.Forms;

public class ListaSimples<Dado> where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro, ultimo, atual, anterior;

    int quantosNos;

    public ListaSimples()
    {
        primeiro = ultimo = null;
        quantosNos = 0;
    }

    public bool EstaVazia
    {
        get => primeiro == null;

        // get 
        // {
        //    if (primeiro == null)
        //       return true;
        //    return false;
        // }
    }
    public void InserirAposFim(Dado novoDado)
    {
        NoLista<Dado> novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;


        ultimo = novoNo;
        quantosNos++;
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)          // se a lista est� vazia, estamos
            ultimo = novoNo;    // incluindo o 1o e o �ltimo n�s!
        else
            novoNo.Prox = primeiro;

        primeiro = novoNo;
        quantosNos++;
    }

    public void ExibirNaTela()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }

    public void Listar(ListBox oListBox)
    {
        oListBox.Items.Clear(); // limpa o conte�do do listBox
        atual = primeiro;       // posiciona ponteiro no 1o n� da lista
        while (atual != null)   // percorre a lista ligada at� seu final
        {
            oListBox.Items.Add(atual.Info); // exibe os itens da lista ligada no listbox
            atual = atual.Prox;             // avan�a para o n� seguinte
        }
    }

}