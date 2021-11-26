using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ilovecode.EFCore.RepositoryBase
{
    public interface IRepositoryBase<TEntity>
       where TEntity : class

    {
        /// <summary>
        /// Listar registros baseados em uma entidade 
        /// </summary>
        /// <returns>Retorna uma lista de entidades</returns>
        
       IQueryable<TEntity> GetAll();
        /// <summary>
        /// Listar registros baseados em uma entidade com possibilidade de realizar filtros
        /// </summary>
        /// <param name="where">condição para obter entidade</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// Listar registros baseados em uma entidade respeitando filtros, podendo paginar os dados
        /// </summary>
        /// <param name="where">condição para obter entidade</param>
        /// <param name="skip">Pula quantidade de registros</param>
        /// <param name="take">Pega somente a quantidade de registros informada</param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where, int skip, int take);

        /// <summary>
        /// Obter entidade dada alguma condição
        /// </summary>
        /// <param name="where">condição para obter entidade</param>
        /// <returns>Retorna uma entidade</returns>
        TEntity GetBy(Func<TEntity, bool> where);


        /// <summary>
        /// Obter entidade dada alguma condição
        /// </summary>
        /// <param name="where">condição para obter entidade</param>
        /// <returns>Retorna uma entidade</returns>
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken=default);

        /// <summary>
        /// Verifica se existe registro baseada em alguma condição
        /// </summary>
        /// <param name="where">Condição para obter entidade</param>
        /// <returns>Retorna um boleano se existe registro baseada na condição informada</returns>
        bool Exists(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Verifica se existe registro baseada em alguma condição
        /// </summary>
        /// <param name="where">Condição para obter entidade</param>
        /// <returns>Retorna um boleano se existe registro baseada na condição informada</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);


        /// <summary>
        /// Adiciona uma nova entidade
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        /// <returns>Retorna a entidade adicionada</returns>
        void Add(TEntity entity);

        /// <summary>
        /// Adiciona uma nova entidade
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        /// <returns>Retorna a entidade adicionada</returns>
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);



        /// <summary>
        /// Adiciona uma lista de entidades
        /// </summary>
        /// <param name="entities">Lista de entidades a serem adicionadas</param>
        void AddCollection(IEnumerable<TEntity> entities);

        /// <summary>
        /// Adiciona uma lista de entidades
        /// </summary>
        /// <param name="entities">Lista de entidades a serem adicionadas</param>
        Task AddCollectionAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);



        /// <summary>
        /// Atualiza entidade
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        /// <returns>Retorna entidade atualizada</returns>
        void Update(TEntity entity);

        /// <summary>
        /// Exclui entidade
        /// </summary>
        /// <param name="entity">Entidade a ser excluída</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Excluí uma ou mais entidades
        /// </summary>
        /// <param name="entities">Lista de entidades a serem excluídas</param>
        void DeleteCollection(IEnumerable<TEntity> entities);

        /// <summary>
        /// Salva alterações
        /// </summary>
        void SaveChanges();

        void Dispose();
    }
}
