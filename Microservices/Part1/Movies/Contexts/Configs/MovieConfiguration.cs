using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Models;

namespace Movies.Contexts.Configs;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
       
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
            .HasMaxLength(255) 
            .IsRequired(); 

        builder.Property(m => m.OriginalTitle)
            .HasMaxLength(255);

        builder.Property(m => m.Overview);

        builder.Property(m => m.ReleaseDate)
            .HasMaxLength(10);

        builder.Property(m => m.BackdropPath);

        builder.Property(m => m.PosterPath);

        builder.Property(m => m.OriginalLanguage)
            .HasMaxLength(10);

        builder.Property(m => m.GenreIds)
            .HasConversion(
                v => string.Join(",", v), 
                v => v.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray()
            );
        
        builder.HasIndex(m => m.Title).HasDatabaseName("IX_Movies_Title");
        builder.HasIndex(m => m.Popularity).HasDatabaseName("IX_Movies_Popularity");
    }
}