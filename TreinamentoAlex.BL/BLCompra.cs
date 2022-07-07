using System;
using System.Collections.Generic;
using FrameworkDT.DL.SQL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.BL {
    public class BLCompra {

        #region Inserir

        public int Inserir(Compra compra) {
            DataLayer<Compra> dalCompra = new DataLayer<Compra>();
            
            int intId = Convert.ToInt32(dalCompra.Inserir(compra, null, TipoComando.Tabela));
            return intId;
        }

        #endregion

        //----------------------------------------------------------------------------------

        #region Atualizar

        public void Atualizar(Compra compra) {
            new DataLayer<Compra>().Alterar(compra);
        }

        #endregion

        //----------------------------------------------------------------------------------

        #region Deletar

        public void Deletar(int intId) {
             new DataLayer<Compra>().Deletar(intId);
        }

        #endregion

        //----------------------------------------------------------------------------------

        #region Listar

        public List<Compra> Listar(int id) {
            DataLayer<Compra> dalCompra = new DataLayer<Compra>();
            return dalCompra.Listar<List<Compra>>();
        }

        #endregion

        //----------------------------------------------------------------------------------

        #region Obter

        public Compra Obter(int intId) {
            return new DataLayer<Compra>().Obter(intId);
        }


        #endregion


    }

}

