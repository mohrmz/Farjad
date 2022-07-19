using Farjad.Core.Domain.Entities;
using Farjad.Core.Domain.ValueObjects;
using System.Linq.Expressions;

namespace Farjad.Core.Contracts.Data.Commands;

/// <summary>
/// If the data is stored normally, this interface is used to determine the main operations in the data storage section.
/// </summary>
/// <typeparam name="TEntity">The class that is selected for storage</typeparam>
public interface ICommandRepository<TEntity> : IUnitOfWork
    where TEntity : AggregateRoot
{
    /// <summary>
    /// Deletes an object by id
    /// </summary>
    /// <param name="id">Identifier</param>
    void Delete(long id);

    /// <summary>
    /// Deletes an object along with all its children
    /// </summary>
    /// <param name="id">Identifier</param>
    void DeleteGraph(long id);

    /// <summary>
    /// Gets an object and deletes it from the database
    /// </summary>
    /// <param name="entity">Specifies domain entity added to the database.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Adds new data to the database
    /// </summary>
    /// <param name="entity">Specifies domain entity added to the database.</param>
    void Insert(TEntity entity);

    /// <summary>
    /// Adds new data to the database async
    /// </summary>
    /// <param name="entity">Specifies domain entity added to the database.</param>
    Task InsertAsync(TEntity entity);

    /// <summary>
    /// Finds and returns an object by ID from the database.
    /// </summary>
    /// <param name="id">Required object ID</param>
    /// <returns>A built instance of the object</returns>
    TEntity Get(long id);

    Task<TEntity> GetAsync(long id);

    TEntity Get(BusinessId businessId);

    Task<TEntity> GetAsync(BusinessId businessId);

    TEntity GetGraph(long id);

    Task<TEntity> GetGraphAsync(long id);

    TEntity GetGraph(BusinessId businessId);

    Task<TEntity> GetGraphAsync(BusinessId businessId);

    bool Exists(Expression<Func<TEntity, bool>> expression);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}