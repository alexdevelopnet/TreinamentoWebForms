using System;
using System.Collections.Generic;
using FrameworkDT.DL;
using FrameworkDT.DL.SQL;
using TreinamentoAlex.Model;
using FrameworkDT.DL.Interface;

namespace TreinamentoAlex.BL {
    //==================================================================================
    public class BLEstoque {
        //------------------------------------------------------------------

        #region Inserir

        public int Inserir(Estoque estoque) {
            int intId = Convert.ToInt32(new DataLayer<Estoque>().Inserir(estoque));
            return intId;
        }

        #endregion

        //-----------------------------------------------------------------

        #region Atualizar

        public void Atualizar(Estoque estoque) {
            new DataLayer<Estoque>().Alterar(estoque);
        }

        #endregion

        //--------------------------------------------------------------------

        #region Listar

        public List<Estoque> Listar() {
            DataLayer<Estoque> dalEstoque = new DataLayer<Estoque>();
            return dalEstoque.Listar<List<Estoque>>();
        }

        //--------------------------------------------------------------------

        #endregion

        //-----------------------------------------------------------------

        #region ObterEstoque
        public EstoqueListagem ObterEstoque(int intIdProduto) {
            ParametroPesquisa parIdProduto = new ParametroPesquisa("Est_Pro_N_Id", intIdProduto, Comparador.Igual);
            DataLayer<EstoqueListagem> dalEstoque = new DataLayer<EstoqueListagem>();
            EstoqueListagem estRetorno = dalEstoque.Obter(new[] { parIdProduto });
            return estRetorno;
        }
        #endregion

        //-----------------------------------------------------------------

        #region Obter

        public Estoque Obter(int intId) {
            return new DataLayer<Estoque>().Obter(intId);

        }

        #endregion

        // -----------------------------------------------------------------

        #region SaidaDeProduto
        public void SaidaDeProduto(int intIdProduto, int intQuantidade) {

            Estoque estoque = Obter(intIdProduto);

            int intQuantidadeEmEstoque = estoque.Quantidade;
            ;

            int total = intQuantidadeEmEstoque - intQuantidade;

            estoque.Quantidade = total;

            Atualizar(estoque);

        }
        #endregion

        // -----------------------------------------------------------------

        #region EntradaDeProduto
        public void EntradaDeProduto(int intIdProduto, int intQuantidade) {

            Estoque estoque = Obter(intIdProduto);

            int intQuantidadeEmEstoque = estoque.Quantidade;
            ;

            int total = intQuantidadeEmEstoque + intQuantidade;

            estoque.Quantidade = total;

            Atualizar(estoque);
        }
        #endregion

        //==================================================================================

    }
}


