using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OzerNet.Entities.Users;

namespace OzerNet.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Uid { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Guid? CreatedBy { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual Guid? UpdatedBy { get; set; }
        public virtual User UpdatedByUser { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual Guid? DeletedBy { get; set; }
        public virtual User DeletedByUser { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool Deleted { get; set; }

        public BaseEntity()
        {
            Uid = Guid.NewGuid();
            CreatedBy = null;
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
            DeletedDate = null;
            Active = true;
            Deleted = false;
        }
    }
}
