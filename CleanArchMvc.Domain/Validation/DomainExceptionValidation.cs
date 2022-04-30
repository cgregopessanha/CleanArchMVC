using System;

namespace CleanArchMvc.Domain.Validation
{
    //classe para validar o Domain
    public class DomainExceptionValidation : Exception
    {
        //Construtor, que passa uma string de erro, seguido da mensagem de erro 
        public DomainExceptionValidation(string error) : base(error)
        { }

        public static void When(bool HasError, string error)
        {
            if (HasError) throw new DomainExceptionValidation(error);
        }
    }

}

