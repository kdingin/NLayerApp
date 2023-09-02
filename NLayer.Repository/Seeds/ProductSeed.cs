using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Product { Id=1, CategoryId=1, Name="Kurşun Kalem",Price=200,Stock=20, CreatedDate=DateTime.Now},
            new Product { Id = 2, CategoryId = 1, Name = "Mürekkep Kalem", Price = 200, Stock = 20, CreatedDate =DateTime.Now },
            new Product { Id = 3, CategoryId = 1, Name = "Uçlu Kalem", Price = 200, Stock = 20, CreatedDate = DateTime.Now }
            );
        }
    }
}
