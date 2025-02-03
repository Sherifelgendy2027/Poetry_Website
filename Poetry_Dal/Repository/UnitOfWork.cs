//using Data;
//using Interfaces;
//using Models;
using Data;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class UnitOfWork : IUnitOfWork
{
    protected PoetrydbContext _context;
    public UnitOfWork(PoetrydbContext context)
    {
        _context = context;
        Admins = new Repository<Admin>(_context);
        Authors = new Repository<Author>(_context);
        Categories = new Repository<Category>(_context);
        Requests = new Repository<Request>(_context);
        Verses = new Repository<Verse>(_context);

    }
    public IRepository<Admin> Admins { get; }
    public IRepository<Author> Authors { get; }
    public IRepository<Category> Categories { get; }
    public IRepository<Request> Requests { get; }
    public IRepository<Verse> Verses { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
