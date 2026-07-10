//File path: Ops.Application/Interfaces/IUnitOfWork.cs
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }  //Property/ Field/ Attribute
        IUserRepository Users { get; }
        //Add your InterfcaeEntityRepository


        Task<int> SaveAsync();  // Method
        void Dispose();
    }
}