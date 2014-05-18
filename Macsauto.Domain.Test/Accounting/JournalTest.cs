using System;
using Macsauto.Domain.Accounting.Entities;
using NUnit.Framework;
using Type = Macsauto.Domain.Accounting.Entities.Type;

namespace Macsauto.Domain.Test.Accounting
{
    [TestFixture]
    public class JournalTest
    {
        private Account _cash;
        private Account _accountPayable;
        private Period _period;
        private FiscalYear _fiscalYear;

        [SetUp]
        public void SetUp()
        {
            _fiscalYear = new FiscalYear("FY2014", "Fiscal year 2014", DateTime.Now);
            _period = _fiscalYear.AddThreeMonthsPeriod("2014MAYJUL", DateTime.Now);

            _cash = new Account("10100", "Cash", AccountClassification.Asset);
            _accountPayable = new Account("21000", "Account Payable", AccountClassification.Liability);
        }

        [Test]
        public void Can_add_child_account()
        {
            var supplierPayable = new Account("210001", "Account Payable - Supplier", AccountClassification.Liability);

            _accountPayable.AddChild(supplierPayable);

            Assert.True(supplierPayable.Parent == _accountPayable);
        }

        [Test]
        public void Should_imbalance_exception()
        {
            var journal = new JournalEntry(_period, "TEST POST");

            journal.AddEntryItem(_cash, Type.Debit, 10000);
            journal.AddEntryItem(_accountPayable, Type.Credit, 5000);

            var ex = Assert.Throws<Exception>(journal.Post);
            Console.WriteLine(ex.Message);
        }

        [Test]
        public void Can_post()
        {
            var journal = new JournalEntry(_period, "TEST POST MASUK");

            journal.AddEntryItem(_cash, Type.Debit, 10000);
            journal.AddEntryItem(_accountPayable, Type.Credit, 10000);

            journal.Post();

            Assert.AreEqual(_cash.Balance(), 10000);
        }
    }
}