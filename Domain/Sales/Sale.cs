using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;

namespace CleanArchitecture.Domain.Sales
{
    public class Sale : IEntity
    {
        //this has private fields that are used to calculate and update quantities
        private int _quantity;
        private decimal _totalPrice;
        private decimal _unitPrice;

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;

                UpdateTotalPrice();
            }
        }

        public int Quantity
        {
            //This part obtains the quantity to be purchased from the frontend
            get { return _quantity; }
            set
            {
                //This is where the quanity is assigned to the property and a function that will change the price to reflect the quantity is called
                _quantity = value;
                
                UpdateTotalPrice();
            }
        }

        public decimal TotalPrice
        {
            //This part requests for the total prices and sets it as the value of this property
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        private void UpdateTotalPrice()
        {
            //This function is what is used to get the total price after multiplying the price and quantity.
            _totalPrice = _unitPrice * _quantity;
        }
    }
}
