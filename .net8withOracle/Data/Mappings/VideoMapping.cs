using lvife.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vlife.Data.Mapping
{
    public class VideoMapping : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("VIDEO");
            builder.HasKey(x => x.idVideo);

            builder.Property(x => x.idVideo).HasColumnName("ID_VIDEO");
            builder.Property(x => x.videoName).HasColumnName("NOME_VIDEO");
            builder.Property(x => x.creationDateVideo).HasColumnName("DATA_CRIACAO_VIDEO");
            builder.Property(x => x.storedLocation).HasColumnName("LOCAL_ARMAZENADO");
            builder.Property(x => x.duration).HasColumnName("DURACAO");
            builder.Property(x => x.oldPublicLink).HasColumnName("PUBLIC_LINK_OLD");
            builder.Property(x => x.currentPublicLink).HasColumnName("PUBLIC_LINK_ATUAL");
            builder.Property(x => x.possuiThumb).HasColumnName("POSSUI_THUMB");
            builder.Property(x => x.corruptedVideo).HasColumnName("VIDEO_CORROMPIDO");
            builder.Property(x => x.videoNotFound).HasColumnName("VIDEO_NAO_ENCONTRADO");
            builder.Property(x => x.idOwnerVideo).HasColumnName("ID_PROPRIETARIO_VIDEO");
            builder.Property(x => x.publicVideo).HasColumnName("PUBLIC_VIDEO");
            
            builder.HasOne(x => x.videoOwner).WithMany().HasForeignKey(s => s.idOwnerVideo); 
        }
    }
}

        
        