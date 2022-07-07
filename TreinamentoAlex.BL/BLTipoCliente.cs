using System.Collections.Generic;
using TreinamentoAlex.DL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.BL {
    public class BLTipoCliente {


        #region Inserir
        public int Iserir(TipoCliente tpcInserir) {
            DLTipoCliente clienteDL = new DLTipoCliente();

            int intIdTipo = clienteDL.Inserir(tpcInserir);

            return intIdTipo;
        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Atualizar
        public void Atualizar(TipoCliente tpcCliente) {
            DLTipoCliente clienteDL = new DLTipoCliente();
            clienteDL.Atualizar(tpcCliente);
        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Deletar
        public void Deletar(int intIdTipoCliente) {
            DLTipoCliente clienteDL = new DLTipoCliente();
            clienteDL.Deletar(intIdTipoCliente);

        }
        #endregion
        //--------------------------------------------------------------------------------------
        #region Listar

        public List<TipoCliente> Listar() {

            return new DLTipoCliente().Listar();
        }

        #endregion
        //--------------------------------------------------------------------------------------
        #region Obter

        public TipoCliente Obter(int IdTipoCliente) {

            return new DLTipoCliente().Obter(IdTipoCliente);

        }
        #endregion


    }
}

