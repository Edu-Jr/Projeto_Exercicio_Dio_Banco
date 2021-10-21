using System;

namespace Bank_exercise
{
    public class Conta
    {
        private Tipo_conta TipoConta {get; set;}

        private double Saldo {get; set;}

        private double Credito {get; set;}
        
        private string Nome {get; set;}

        public Conta (Tipo_conta tipoConta, double saldo, double credito, string Nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = Nome;
        }

        public bool Sacar (double ValorSaque)
        {
            // validação saldo suficiente
            if(this.Saldo - ValorSaque < (this.Credito*-1))
            {
               Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.Saldo -= ValorSaque;

            Console.WriteLine(" O saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
          
        }
        public void Depositar (double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine(" O valor do Depósito da conta de {0} é {1}", this.Nome, this.Saldo);
            
        }
        public void Transferir (double ValorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(ValorTransferencia))
            {
            contaDestino.Depositar (ValorTransferencia);
            }
        }
        public override string ToString ()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | " ;
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
        
    }
}