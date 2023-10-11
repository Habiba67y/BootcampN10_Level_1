using System.Linq.Expressions;
using ToDoList.Data;
using ToDoList.Entities;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services;

public class ToDoService: IToDoService
{
    private readonly IDataContext _dataContext;

    public ToDoService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<ToDo> Get(Expression<Func<ToDo, bool>> predicate) =>
        _dataContext.ToDos.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<ToDo>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var toDos = _dataContext.ToDos.Where(toDo => ids.Contains(toDo.Id));
        return new ValueTask<ICollection<ToDo>>(toDos.ToList());
    }

    public async ValueTask<ToDo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dataContext.ToDos.FindAsync(id, cancellationToken);

    public async ValueTask<ToDo> CreateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.ToDos.AddAsync(toDo, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return toDo;
    }

    public async ValueTask<ToDo> UpdateAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundToDo = await GetByIdAsync(toDo.Id) ?? throw new InvalidOperationException("ToDo not found");

        foundToDo.Name = toDo.Name;
        foundToDo.Description = toDo.Description;
        foundToDo.CreatedAt = toDo.CreatedAt;
        foundToDo.UserId = toDo.UserId;

        await _dataContext.ToDos.UpdateAsync(foundToDo, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();
        return foundToDo;
    }

    public async ValueTask<ToDo> DeleteAsync(ToDo toDo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(toDo.Id, saveChanges, cancellationToken);
    }

    public async ValueTask<ToDo> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundToDo = await GetByIdAsync(id) ?? throw new InvalidOperationException("ToDo not found");

        await _dataContext.ToDos.RemoveAsync(foundToDo, cancellationToken);
        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return foundToDo;
    }
}
