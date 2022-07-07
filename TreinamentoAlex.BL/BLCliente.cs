using System.Collections.Generic;
using TreinamentoAlex.DL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.BL {
  public  class BLCliente {

        #region Inserir
        public int Iserir(Cliente inserir) {
            DLCliente clienteDL = new DLCliente();

            int intId = clienteDL.Inserir(inserir);

            return intId;
        }
        #endregion
        //-------------------------------------------------------------------------------------
        #region Atualizar
        public void Atualizar(Cliente cliente) {
            
           new DLCliente().Atualizar(cliente);
        }
        #endregion
        //-------------------------------------------------------------------------------------
        #region Deletar
        public void Deletar(int intIdCliente) {
            DLCliente clienteDL = new DLCliente();
            clienteDL.Deletar(intIdCliente);

        }
        #endregion
        //-------------------------------------------------------------------------------------
        #region Listar
        public List<ClienteListagem> Listar() {
            /*
            DLCliente clienteDL = new DLCliente();
            List<Cliente> lstCliente = clienteDL.Listar();
            return lstCliente; */

            return new DLCliente().Listar();
        }
        #endregion
        //-------------------------------------------------------------------------------------
        #region Obter
        public Cliente Obter(int IdCliente) {

            return new DLCliente().Obter(IdCliente);

        }
        #endregion



    }
}


