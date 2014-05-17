using System;
using System.Collections.Generic;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// A FiscalYear (or financial year) corresponds to twelve months for a company.
    /// The fiscal year is divided into monthly or three-monthly accounting periods.
    /// </summary>
    public class FiscalYear : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime ClosedOn { get; set; }
        public virtual IList<Period> Periods { get; set; }
    }
}