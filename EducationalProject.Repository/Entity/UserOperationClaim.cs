﻿using EducationalProject.Repository.Abstract;

namespace EducationalProject.Repository.Entity
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
