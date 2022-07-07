using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FrameworkDT.DL.SQL;
using TreinamentoAlex.BL;

namespace TreinamentoAlex.Model {
    //============================================================================
    public class BLItemCompra {
        //--------------------------------------------------------------------------
        #region Inserir

        public int Inserir(ItemCompra itemCompra) {
            int intId = Convert.ToInt32(new DataLayer<ItemCompra>().Inserir(itemCompra));
            return intId;
        }

        #endregion
        //--------------------------------------------------------------------------
        #region Atualizar

        public void Atualizar(ItemCompra itemCompra) {
            new DataLayer<ItemCompra>().Alterar(itemCompra);
        }

        #endregion
        //--------------------------------------------------------------------------
        #region Deletar

        public void Deletar(ItemCompra itemCompra) {
            new DataLayer<ItemCompra>().Deletar(itemCompra);
        }

        #endregion
        //--------------------------------------------------------------------------
        #region Listar

        public List<ItemCompra> Listar() {
            DataLayer<ItemCompra> dalItemCompra = new DataLayer<ItemCompra>();
            return dalItemCompra.Listar<List<ItemCompra>>();
        }
        #endregion
        //--------------------------------------------------------------------------
        #region Obter

        public ItemCompra Obter(int IntId) {
            return new DataLayer<ItemCompra>().Obter(IntId);
        }

        #endregion
        //------------------------------------------------------------------------
        #region VerificarEstoque
        public bool VerificarEstoque(int intIdProduto, int intQuantidadeCompra) {

            BLEstoque blEstoque = new BLEstoque();

            EstoqueListagem estoque = blEstoque.ObterEstoque(intIdProduto);


            if (intQuantidadeCompra <= estoque.Quantidade) {
                return true;
            }
            else {
                return false;
            }

        }
        #endregion
        //------------------------------------------------------------------------
    }
    //==============================================================================
}
