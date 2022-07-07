using System;
using System.Collections.Generic;
using FrameworkDT.DL.SQL;
using TreinamentoAlex.Model;

namespace TreinamentoAlex.BL {
    //=========================================================================
    public class BLFabricante {
        //---------------------------------------------------------------------
        #region Inserir

        public int Inserir(Fabricante fabricante) {
            int IntId = Convert.ToInt32(new DataLayer<Fabricante>().Inserir(fabricante));
            return IntId;
        }
        #endregion
        //---------------------------------------------------------------------
        #region Atualizar

        public void Atualizar(Fabricante fabricante) {
            new DataLayer<Fabricante>().Alterar(fabricante);
        }
        #endregion
        //---------------------------------------------------------------------
        #region Deletar

        public void Deletar(Fabricante fabricante) {
            new DataLayer<Fabricante>().Deletar(fabricante);
        }

        #endregion
        //---------------------------------------------------------------------
        #region Listar

        public List<Fabricante> Listar() {
          
            DataLayer<Fabricante> dalFabricante = new DataLayer<Fabricante>();
            
            return dalFabricante.Listar<List<Fabricante>>();
        }
        #endregion
        //---------------------------------------------------------------------
        #region Obter

        public Fabricante Obter(int intId) {
            return new DataLayer<Fabricante>().Obter(intId);

        }



        #endregion

    }
    //===========================================================================
}
