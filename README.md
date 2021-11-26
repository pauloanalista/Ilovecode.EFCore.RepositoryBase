# Ilovecode.EFCore.RepositoryBase
Fornece suporte a transações e os principais métodos para seus repositorios que utilizam Entity Framework Core.

Métodos disponíveis para seu repositório
- IQueryable<TEntity> GetAll();
- IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where);
- IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> where, int skip, int take);
- TEntity GetBy(Func<TEntity, bool> where);
- Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken=default);
- bool Exists(Expression<Func<TEntity, bool>> where);
- Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);
- void Add(TEntity entity);
- Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
- void AddCollection(IEnumerable<TEntity> entities);
- Task AddCollectionAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
- void Update(TEntity entity);
- void Delete(TEntity entity);
- void DeleteCollection(IEnumerable<TEntity> entities);
- void SaveChanges();

Métodos disponíveis para trabalhar com transação
- void BeginTransaction();
- Task BeginTransactionAsync(CancellationToken cancellationToken = default);
- void CommitTransaction();
- Task CommitTransactionAsync(CancellationToken cancellationToken=default);
- void RollbackTransaction();
- Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
- void SaveChanges();

## Instalação
Para instalar utilize o seguinte comando abaixo ou procure no Manage Nuget Packages
```sh
Install-Package Ilovecode.EFCore.RepositoryBase -Version 1.0.0
```
ou acesse pelo gerenciador de pacotes do Visual Studio e instale no projeto desejado.

| Package |  Version | Downloads |
| ------- | ----- | ----- |
| `Ilovecode.EFCore.RepositoryBase` | [![NuGet](https://img.shields.io/nuget/v/Ilovecode.EFCore.RepositoryBase.svg)](https://www.nuget.org/packages/Ilovecode.EFCore.RepositoryBase) | [![Nuget](https://img.shields.io/nuget/dt/Ilovecode.EFCore.RepositoryBase.svg)](https://nuget.org/packages/Ilovecode.EFCore.RepositoryBase) |

## Usando o pacote no projeto
Instale em seu projeto onde se encontra sua interface do repositório e onde se encontra sua classe concreta
 
### Interface do repositório

 ![image](https://user-images.githubusercontent.com/6010161/143608504-124c1c8f-00cf-4e9b-8972-2ec70e6054e1.png)

### Classe concreta do repositório

![image](https://user-images.githubusercontent.com/6010161/143608587-649bc678-ecd3-406a-a614-b5ef7b6a1352.png)

### Crud está pronto, basta usar os métodos disponíveis
- GetAll
- GetAllBy
- GetBy
- GetByAsync
- Exists
- ExistsAsync
- Add
- AddAsync
- AddCollection
- AddCollectionAsync
- Update
- Delete
- DeleteCollection
### Veja alguns exemplos
#### Adicionando uma entidade
```csharp
_repositoryUsuario.Add(usuario);
```
#### Atualizando uma entidade
```csharp
_repositoryUsuario.Update(usuario);
```
#### Excluindo uma entidade
```csharp
_repositoryUsuario.Delete(usuario);
```
#### Obtendo uma entidade
```csharp
Entities.Usuario usuario = _repositoryUsuario.GetBy(x=>x.Id== request.IdUsuario);
```
#### Verficando se uma entidade existe
```csharp
bool existe = _repositoryUsuario.Exists(x => x.Email == request.Email)
```


### Sugestões
Fique a vontade para enviar sugetões, a ideia é facilitar nosso trabalho.

# VEJA TAMBÉM
## Grupo de Estudo no Telegram
- [Participe gratuitamente do grupo de estudo](https://olha.la/ilovecode-telegram)

## Cursos e Treinamentos
- [Cursos Baratos](https://olha.la/udemy)
- [Cursos Indicados](https://olha.la/cursos)

## Fique ligado, acesse!
- [Blog ILoveCode](https://ilovecode.com.br)

## Novidades, cupons de descontos e cursos gratuitos
https://t.me/blogilovecode
