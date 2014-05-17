using System;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// Period is a part of accounting <see cref="FiscalYear">FiscalYear</see>.
    /// A period usually consists of one or three months in a single <see cref="FiscalYear">FiscalYear</see>
    /// </summary>
    public class Period : Entity
    {
        private readonly FiscalYear _fiscalYear;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        public Period(FiscalYear fiscalYear, DateTime startDate, DateTime endDate, string code) : base(code)
        {
            _fiscalYear = fiscalYear;
            _startDate = startDate;
            _endDate = endDate;
        }

        public virtual FiscalYear FiscalYear
        {
            get { return _fiscalYear; }
        }

        public virtual DateTime StartDate
        {
            get { return _startDate; }
        }

        public virtual DateTime EndDate
        {
            get { return _endDate; }
        }
    }
}