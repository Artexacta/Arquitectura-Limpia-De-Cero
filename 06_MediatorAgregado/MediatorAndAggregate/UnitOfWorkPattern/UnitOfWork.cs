﻿using MediatorAndAggregate.DbContexts;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorAndAggregate.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
        private readonly IMediator _mediator;
        private int _transactionCounter;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(WriteDbContext context, 
            IMediator mediator, 
            ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mediator = mediator;
            _transactionCounter = 0;
            _logger = logger;
        }
        public async Task Commit()
        {
            _transactionCounter++;
            
            var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(x => !x.Consumed)
                .ToArray();

            foreach (DomainEvent domainEvent in domainEvents)
            {
                domainEvent.Consume();
                _logger.LogInformation($"[UNIT OF WORK] Se notifica el evento {domainEvent.GetType().ToString()}");
                await _mediator.Publish(domainEvent);
            }

            if (_transactionCounter == 1)
            {
                _logger.LogInformation("[UNIT OF WORK] Se hace el commit de todos los cambios");
                await this._context.SaveChangesAsync();
            } 
            else
            {
                _logger.LogInformation($"[UNIT OF WORK] Aquí no hay commit porque TXN counter es {_transactionCounter}");
                _transactionCounter--;
            }
        }
    }
}
