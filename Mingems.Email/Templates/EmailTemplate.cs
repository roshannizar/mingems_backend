using Mingems.Core.Models;
using Mingems.Shared.Core.Enums;
using System;
using System.Text;

namespace Mingems.Email.Templates
{
    public static class EmailTemplate
    {
        public static string GetHTMLOrder(Order order)
        {
            var sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Fabcart</title>
                    <style>
                        body{
                            background-color: #F6F6F6; 
                            margin: 0;
                            padding: 0;
                        }
                        h1,h2,h3,h4,h5,h6{
                            margin: 0;
                            padding: 0;
                        }
                        p{
                            margin: 0;
                            padding: 0;
                        }
                        .container{
                            width: 80%;
                            margin-right: auto;
                            margin-left: auto;
                        }
                        .brand-section{
                           background-color: #0d1033;
                           padding: 10px 40px;
                        }
                        .logo{
                            width: 50%;
                        }

                        .row{
                            display: flex;
                            flex-wrap: wrap;
                        }
                        .col-6{
                            width: 50%;
                            flex: 0 0 auto;
                        }
                        .text-white{
                            color: #fff;
                        }
                        .company-details{
                            float: right;
                            text-align: right;
                        }
                        .body-section{
                            padding: 16px;
                            border: 1px solid gray;
                        }
                        .heading{
                            font-size: 20px;
                            margin-bottom: 08px;
                        }
                        .sub-heading{
                            color: #262626;
                            margin-bottom: 05px;
                        }
                        table{
                            background-color: #fff;
                            width: 100%;
                            border-collapse: collapse;
                        }
                        table thead tr{
                            border: 1px solid #111;
                            background-color: #f2f2f2;
                        }
                        table td {
                            vertical-align: middle !important;
                            text-align: center;
                        }
                        table th, table td {
                            padding-top: 08px;
                            padding-bottom: 08px;
                        }
                        .table-bordered{
                            box-shadow: 0px 0px 5px 0.5px gray;
                        }
                        .table-bordered td, .table-bordered th {
                            border: 1px solid #dee2e6;
                        }
                        .text-right{
                            text-align: end;
                            padding-right: 10px;
                        }
                        .w-20{
                            width: 20%;
                        }
                        .float-right{
                            float: right;
                        }
                    </style>
                </head>
                <body>
            ");

            sb.Append(@"
                <div class='container'>
                    <div class='brand-section'>
                        <div class='row'>
                            <div class='col-6'>
                                <h1 class='text-white'>Mingems</h1>
                            </div>
                            <div class='col-6'>
                                <div class='company-details'>
                                    <p class='text-white'>100 Hatton Garden,</p>
                                    <p class='text-white'>London EC1N 8NX</p>
                                    <p class='text-white'>078 7867 8116/ 020 7405 2625</p>
                                </div>
                            </div>
                        </div>
                </div>
            ");

            sb.AppendFormat(@"<div class='body-section'>
                    <div class='row'>
                        <div class='col-6'>
                            <h2 class='heading'>Invoice No: {3}</h2>
                            <p class='sub-heading'>Order Date: {4}</p>
                            <p class='sub-heading'>Email Address: {2}</p>
                        </div>
                        <div class='col-6'>
                            <p class='sub-heading'>Full Name:  {0} {1}</p>
                            <p class='sub-heading'>Phone Number: {5}</p>
                            <p class='sub-heading'>Payment Mode: {6}</p>
                            <p class='sub-heading'>Payment Status: {7}</p>
                        </div>
                    </div>
                </div>
            ", order.Customer.FirstName,
            order.Customer.LastName,
            order.Customer.Email,
            order.RefId,
            order.TransactionDate,
            order.Customer.ContactNo,
            order.PaymentType == PaymentType.Card ? "Card Payment" : "Cash",
            order.OrderStatus == OrderStatus.Paid ? "Paid" : order.OrderStatus == OrderStatus.Pending ? "Pending" : "Cancelled");

            sb.Append(@"<div class='body-section'>
                <h3 class='heading'>Ordered Items</h3>
                <br>
                <table class='table-bordered'>
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th class='w-20'>Price(£)</th>
                            <th class='w-20'>Quantity</th>
                            <th class='w-20'>Grandtotal(£)</th>
                        </tr>
                    </thead>
                    <tbody>
            ");

            foreach (var item in order.OrderLines)
            {
                sb.AppendFormat(@"
                    <tr>
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                        <td>{3}</td>
                    </tr>
                ", item.Purchase.Name, Math.Round(item.SoldPrice, 2), item.Quantity, Math.Round(item.SoldPrice * item.Quantity, 2));
            }

            sb.AppendFormat(@"<tr>
                        <td colspan='3' class='text-right'>Sub Total(£) </td>
                        <td> {0}</td>
                    </tr>
                    <tr>
                        <td colspan='3' class='text-right'>Discount(£) </td>
                        <td> {1}</td>
                    </tr>
                    <tr>
                        <td colspan='3' class='text-right'>VAT(£) </td>
                        <td> {3}</td>
                    </tr>
                    <tr>
                        <td colspan='3' class='text-right'>Grand Total(£) </td>
                        <td> {2}</td>
                    </tr>
                </tbody>
            </table>
            <br>
        </div>

        <div class='body-section'>
            <p>&copy; Copyright 2022 - Mingems. All rights reserved. 
                <a href='https://www.mingems.co.uk/' class='float-right'>www.mingems.co.uk</a>
            </p>
        </div>      
    </div>      

</body>
</html>
", Math.Round(order.TotalAmount, 2), order.Discount, Math.Round(order.TotalAmount - order.Discount + order.VAT, 2), Math.Round(order.VAT, 2));

            return sb.ToString();
        }
    }
}
