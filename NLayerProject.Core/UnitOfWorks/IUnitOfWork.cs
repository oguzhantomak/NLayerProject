using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Repositories;

namespace NLayerProject.Core.UnitOfWorks
{
    internal interface IUnitOfWork
    {
        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        /// <summary>
        /// CommitAsync, implement ettiğimiz zaman SaveChanges metodunu çağıracak.
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        void Commit();
    }
}
