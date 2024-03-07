using lvife.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vlife.Data.Mapping
{
    public class VideoOwnerMapping : IEntityTypeConfiguration<VideoOwner>
    {
        public void Configure(EntityTypeBuilder<VideoOwner> builder)
        {
            builder.ToTable("PROPRIETARIO_VIDEO");
            builder.HasKey(x => x.idOwnerVideo);

            builder.Property(x => x.idOwnerVideo).HasColumnName("ID_PROPRIETARIO_VIDEO");
            builder.Property(x => x.name).HasColumnName("NOME");
        }

    }
}

        
        