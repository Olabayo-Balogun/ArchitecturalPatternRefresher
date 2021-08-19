using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using NUnit.Framework;

namespace CleanArchitecture.Domain.Sales
{
    //The attribute below communicates with NUnit that this is a test that should be run
    [TestFixture]
    public class SaleTests
    {
        //These private fields are entities to be used in the test
        private Sale _sale;
        private Customer _customer;
        private Employee _employee;
        private Product _product;

        //These are setup and verification values that will also be used during the test
        private const int Id = 1;
        private static readonly DateTime Date = new DateTime(2001, 2, 3);
        private const decimal UnitPrice = 1.00m;
        private const int Quantity = 1;

        //The setup attribute tells NUnit to run this block of code first everytime the test is run
        [SetUp]
        public void SetUp()
        {
            _customer = new Customer();

            _employee = new Employee();

            _product = new Product();

            _sale = new Sale();
        }

        //The test attribute is what is used to tell NUnit that this is a unit test.
        [Test]
        public void TestSetAndGetId()
        {
            _sale.Id = Id;

            Assert.That(_sale.Id,
                Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            _sale.Date = Date;

            Assert.That(_sale.Date,
                Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetCustomer()
        {
            _sale.Customer = _customer;

            Assert.That(_sale.Customer,
                Is.EqualTo(_customer));
        }

        [Test]
        public void TestSetAndGetEmployee()
        {
            _sale.Employee = _employee;

            Assert.That(_sale.Employee,
                Is.EqualTo(_employee));
        }

        [Test]
        public void TestSetAndGetProduct()
        {
            _sale.Product = _product;

            Assert.That(_sale.Product,
                Is.EqualTo(_product));
        }

        [Test]
        public void TestSetAndGetUnitPrice()
        {
            _sale.UnitPrice = UnitPrice;

            Assert.That(_sale.UnitPrice, 
                Is.EqualTo(UnitPrice));
        }

        [Test]
        public void TestSetAndGetQuantity()
        {
            _sale.Quantity = Quantity;

            Assert.That(_sale.Quantity,
                Is.EqualTo(Quantity));
        }

        [Test]
        public void TestSetUnitPriceShouldRecomputeTotalPrice()
        {
            _sale.Quantity = Quantity;

            _sale.UnitPrice = 1.23m;

            Assert.That(_sale.TotalPrice, 
                Is.EqualTo(1.23));
        }

        [Test]
        public void TestSetQuantityShouldRecomputeTotalPrice()
        {
            _sale.UnitPrice = UnitPrice;

            _sale.Quantity = 2;

            Assert.That(_sale.TotalPrice, 
                Is.EqualTo(2.00m));
        }
    }
}
