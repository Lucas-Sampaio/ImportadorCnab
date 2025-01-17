﻿namespace ImportadorCNAB.Domain.seedWork;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}