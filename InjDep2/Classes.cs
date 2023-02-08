using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjDep2
{
    // Nivel 1 - UMA GRANDE CLASSE
    // Nivel 2 - Várias classes com dependência forte
    //           Forte Acoplamento
    // Nivel 3 - Injeção de Dependencia
    //           Fraco Acoplamento

    public interface IBanco
    {
        void Conectar();
        void EnviarPix();
    }

    public interface IPublico
    {
        void AcessoGovBr();
    }

    public class Bradesco : IBanco
    {
        public void Conectar()
        {
            //
        }       

        public void EnviarPix()
        {
            //
        }
    }

    public class CEF : IBanco, IPublico
    {
        public void Conectar()
        {
            //
        }

        public void EnviarPix()
        {
            //
        }

        public void AcessoGovBr()
        {
            //
        }
    }

    public class Santander : IBanco
    {
        public void Conectar()
        {
            //
        }

        public void EnviarPix()
        {
            //
        }
    }

    public class Pagamentos
    {
        IBanco MeuBanco;

        // Constructor Injection Dependency
        public Pagamentos(IBanco Bk)
        {
            MeuBanco = Bk;
        }

        public void RealizarTransferencia()
        {
            if (MeuBanco is IPublico)
                ((IPublico)MeuBanco).AcessoGovBr();

            MeuBanco.Conectar();
            MeuBanco.EnviarPix();
        }

        // Method Injection Dependency
        //public void PagarContaAgora(IBanco A)
        //{
        //    A.EnviarPix();
        //}
    }



    public class MeuSistema
    {
        public void FechamentoDoMes()
        {
            Bradesco Bk1 = new Bradesco();
            Pagamentos Pag = new Pagamentos(Bk1);
            Pag.RealizarTransferencia();

            Santander Bk2 = new Santander();
            Pagamentos Pag2 = new Pagamentos(Bk2);
            Pag2.RealizarTransferencia();

        }
    }
}








