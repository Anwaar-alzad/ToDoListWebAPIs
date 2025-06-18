using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyPilot.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyPilot.DAL.Configuration
{
    internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
    
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(t => t.Description)
                .IsRequired(false)
                .HasMaxLength(150);

        
    }
    }
}
