using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Macsauto.Domain.Accounting.Entities
{
    /// <summary>
    /// A FiscalYear (or financial year) corresponds to twelve months for a company.
    /// The fiscal year is divided into monthly or three-monthly accounting periods.
    /// </summary>
    public class FiscalYear : Entity, IAggregateRoot
    {
        private readonly IList<Period> _periods;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private String _name;
        private DateTime? _closedOn;

        public FiscalYear(String code, String name, DateTime startDate) : base(code)
        {
            _name = name;
            _startDate = startDate;
            _endDate = _startDate.AddYears(1);
            _periods = new List<Period>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
        }

        public DateTime? ClosedOn
        {
            get { return _closedOn; }
        }

        public IList<Period> Periods
        {
            get { return new ReadOnlyCollection<Period>(_periods); }
        }

        public void Close()
        {
            _closedOn = DateTime.Now;
        }

        public bool IsClosed()
        {
            return _closedOn != null;
        }

        public Period AddPeriod(String code, DateTime startDate, int durationInMonth)
        {
            var endDate = startDate.AddMonths(durationInMonth);

            if (IsClosed())
                throw new Exception(@"Cannot add new period to a closed fiscal year");

            if (startDate < _startDate || endDate > _endDate)
                throw new Exception(@"Period must be between fiscal year time scope");

            if (_periods.Any(x => startDate > x.EndDate && endDate < x.StartDate))
                throw new Exception(@"Period is overlap");

            var period = new Period(code, this, startDate, endDate);

            _periods.Add(period);

            return period;
        }

        public Period AddOneMonthPeriod(String code, DateTime startDate)
        {
            return AddPeriod(code, startDate, 1);
        }

        public Period AddThreeMonthsPeriod(String code, DateTime startDate)
        {
            return AddPeriod(code, startDate, 3);
        }
    }
}