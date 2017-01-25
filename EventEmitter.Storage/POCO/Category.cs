using System;
using LinqToDB.Mapping;

namespace EventEmitter.Storage.POCO
{
    [Table(Name = "Category")]
    public class Category : IPoco
    {
        [PrimaryKey, Identity, Column(Name = "CategoryId")]
        public Guid Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Code")]
        public string Code { get; set; }

        [Column(Name = "Description")]
        public string Description { get; set; }
    }
}