﻿using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Contracts
{
    public interface IWorkOrderRepository : IRepositoryBase<WorkOrder>
    {
        object GetById(int ıd);
    }
}
