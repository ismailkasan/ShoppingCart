using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Domain
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }
        /// <summary>
        /// Gets or sets the base entity id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the base entity IsDeletd for soft delete
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
