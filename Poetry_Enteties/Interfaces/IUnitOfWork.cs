
using Interfaces;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Request> Requests { get; }
    public IRepository<Admin> Admins { get; }
    public IRepository<Author> Authors { get; }
    public IRepository<Category> Categories { get; }
    public IRepository<Verse> Verses { get; }


    int Save();
}
