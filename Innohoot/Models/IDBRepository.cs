﻿using Innohoot.Models;

using Microsoft.EntityFrameworkCore.Storage;

using System.Linq.Expressions;

namespace Innohoot.DataLayer
{

	public interface IDBRepository : IDisposable
	{
		public IQueryable<T> Get<T>(Guid id) where T : class, IEntity;
		public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
		public IQueryable<T> GetAll<T>() where T : class, IEntity;
		public Task<Guid> Add<T>(T item) where T : class, IEntity;
		public Task<T> Update<T>(T item) where T : class, IEntity;
		public Task<T> Delete<T>(T item) where T : class, IEntity;
		public Task<T> Delete<T>(Guid id) where T : class, IEntity;
		public Task<int> Save();
		public Task<IDbContextTransaction> BeginTransaction();
		public ApplicationContext Context { get; }
	}

}
