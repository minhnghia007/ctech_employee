using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectApiCompanyCTECH.MainEntitites.EntityConfigurations
{
    public abstract class BaseEntityMapperClass<TEntity> : BaseEntityMapperClassBase<TEntity, int>
       where TEntity : class, IAggregateRoot<int>
    {
        // public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        // {
        // }
    }

    public abstract class BaseEntityMapperClassBase<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IAggregateRoot<TId>
        where TId : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
    public abstract class BaseEntityMapper<TEntity> : BaseEntityMapperClass<TEntity>, IEntityTypeConfiguration<TEntity>
        where TEntity : class, IAggregateRoot
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
