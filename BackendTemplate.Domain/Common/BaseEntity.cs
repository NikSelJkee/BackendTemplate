﻿namespace BackendTemplate.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
