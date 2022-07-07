using System;
using System.Collections.Generic;
using FrameworkDT.DL;
using FrameworkDT.DL.Interface;
using FrameworkDT.DL.SQL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.BL {
    //===================================================================
    public class BLProdutos {

        #region Inserir

        public int Inserir(Produto produto) {
            int IntId = Convert.ToInt32(new DataLayer<Produto>().Inserir(produto));

            Estoque estoque  = new Estoque();
            estoque.Id = IntId;
            estoque.Quantidade = 0;
            BLEstoque blEstoque = new BLEstoque();
            blEstoque.Inserir(estoque);

            return IntId;
        }

        #endregion
        //------------------------------------------------------------------
        #region Atualizar

        public void Atualizar(Produto produto) {
            new DataLayer<Produto>().Alterar(produto);
        }

        #endregion
        //------------------------------------------------------------------
        #region Deletar

        public void Deletar(Produto produto) {
            new DataLayer<Produto>().Deletar(produto);
        }

        #endregion
        //------------------------------------------------------------------
        #region Listar
        public List<Produto> Listar() {
       
            DataLayer<Produto> dalProdutos = new DataLayer<Produto>();

            return dalProdutos.Listar<List<Produto>>();
        }

        
        #endregion
        //-----------------------------------------------------------------
        #region
        public List<ItemCompraListagem> ListarItensCompra(int intIdCompra) {
            ParametroPesquisa parIdCompra = new ParametroPesquisa("Ite_Com_N_Id", intIdCompra, Comparador.Igual);
            DataLayer<ItemCompraListagem> dalProdutos = new DataLayer<ItemCompraListagem>();
            List<ItemCompraListagem> lstTemp = dalProdutos.Listar<List<ItemCompraListagem>>(new[] {parIdCompra});
            return lstTemp;
        }

        #endregion
        //------------------------------------------------------------------
        #region Obter

        public Produto Obter(int intId) {

            return new DataLayer<Produto>().Obter(intId);
        }
        #endregion
        //-----------------------------------------------------------------

    }

    //===================================================================
}


