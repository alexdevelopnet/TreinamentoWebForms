using FrameworkDT.DL.Atributos;

namespace TreinamentoAlex.Model {
    //===============================================================================
   
    public class ItemCompraListagem : ItemCompra {

        //---------------------------------------------------------------------------
       
        public string Descricao { get; set; }
        //---------------------------------------------------------------------------
    
        public double Valor { get; set; }
        //---------------------------------------------------------------------------
        public double ValorTotalProduto {
            get {
                double dblValorTotal = Valor*Quantidade;
                return dblValorTotal;
            }
       //--------------------------------------------------------------------------
        }
    
}
    //===============================================================================
}
