using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using N63_HT1.Api.Entities;
using N63_HT1.Api.Entities.Common;

namespace N63_HT1.Api.Data;

internal class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public IFileSet<StorageFile, Guid> Files => Set<StorageFile, Guid>(nameof(Files));

    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
        OnSaveChanges += AddSoftDeletionDetails;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<Auditable> entityEntry) continue;

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.Id = Guid.NewGuid();

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.CreatedDate = DateTimeOffset.Now;

                if (entityEntry.State == FileEntityState.Modified)
                    entityEntry.Entity.ModifiedDate = DateTimeOffset.Now;

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
            }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddSoftDeletionDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<Auditable>
                    {
                        State: FileEntityState.Deleted
                    } entityEntry) continue;


                entityEntry.Entity.IsDeleted = true;
                entityEntry.Entity.DeletedDate = DateTimeOffset.Now;
                entityEntry.State = FileEntityState.MarkedDeleted;
            }

        return new ValueTask(Task.CompletedTask);
    }
}
