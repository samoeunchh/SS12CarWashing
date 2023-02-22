﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS12CarWashing.Models;

namespace SS12CarWashing.Controllers
{
    public class SaleReportController : Controller
    {
        private readonly AppDbContext _context;

        public SaleReportController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<JsonResult> GetSale(string FromDate,string ToDate)
        {
            var fDate =DateTime.Parse(FromDate + " 00:00:00");
            var tDate = DateTime.Parse(ToDate + " 23:59:59");
            var sale = await (from s in _context.Sale
                              join c in _context.Customer
                              on s.CustomerId equals c.CustomerId
                              where s.IssueDate >= fDate && s.IssueDate <= tDate
                              select new SaleDTO
                              {
                                  SaleId = s.SaleId,
                                  CustomerName = c.CustomerName,
                                  InvoiceNumber = s.InvoiceNumber,
                                  IssueDate = s.IssueDate,
                                  Total = s.Total,
                                  Discount = s.Discount,
                                  GrandTotal = s.GrandTotal
                              }).ToListAsync();
            return Json(sale);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
