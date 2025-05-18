using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public bool isActive { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        public void Delete()
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetActive()
        {
            isActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetInactive()
        {
            isActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
