namespace ShoppingCart.Domain
{
    public class AuditableEntity : BaseEntity
    {
        public AuditableEntity()
        {
            CreatedDateUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the auditable entity creted by
        /// </summary>
        public long? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the auditable entity update by
        /// </summary>
        public long? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the auditable entity creted date utc
        /// </summary>
        public DateTime? CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the auditable entity update date utc
        /// </summary>
        public DateTime? UpdatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the auditable entity creted role id
        /// </summary>
        public long? CreatedRoleId { get; set; }

        /// <summary>
        /// Gets or sets the auditable entity update role id 
        /// </summary>
        public long? UpdatedRoleId { get; set; }
    }
}