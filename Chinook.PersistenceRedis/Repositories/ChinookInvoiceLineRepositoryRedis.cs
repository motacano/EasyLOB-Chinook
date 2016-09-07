﻿using Chinook.Data;
using EasyLOB.Persistence;

namespace Chinook.Persistence
{
    public class ChinookInvoiceLineRepositoryRedis : ChinookGenericRepositoryRedis<InvoiceLine>
    {
        #region Methods

        public ChinookInvoiceLineRepositoryRedis(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override void Join(InvoiceLine invoiceLine)
        {
            if (invoiceLine != null)
            {
                invoiceLine.Invoice = UnitOfWork.GetRepository<Invoice>().GetById(invoiceLine.InvoiceId);
                invoiceLine.Track = UnitOfWork.GetRepository<Track>().GetById(invoiceLine.TrackId);
            }
        }

        #endregion Methods
    }
}
