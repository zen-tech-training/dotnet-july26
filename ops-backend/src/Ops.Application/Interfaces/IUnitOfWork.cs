using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }  //Property/ Field/ Attribute

        //Add your InterfcaeEntityRepository


        Task<int> SaveAsync();  // Method
        void Dispose();
    }
}