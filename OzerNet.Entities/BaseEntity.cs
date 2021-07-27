using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OzerNet.Entities.Users;

namespace OzerNet.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public User UpdatedByUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public User DeletedByUser { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        protected BaseEntity()
        {
            CreatedBy = null;
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
            DeletedDate = null;
            Active = true;
            Deleted = false;
        }
    }
}
