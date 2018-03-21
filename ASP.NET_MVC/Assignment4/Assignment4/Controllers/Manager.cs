using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment4.Models;

namespace Assignment4.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }
        public IEnumerable<InvoiceBase> InvoiceGetAll()
        {
            return Mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBase>>(ds.Invoices.OrderBy(I => I.CustomerId));
        }
        public InvoiceBase InvoiceGetById(int? id)
        {
            var idn = ds.Invoices.Find(id);

            return (idn == null) ? null : Mapper.Map<Invoice, InvoiceBase>(idn);
        }
        /*Associated Entities Definitions*/
        public InvoiceWithDetail InvoiceGetByIdWithDetail(int? id)
        {
            var o = ds.Invoices.Include("Customer.Employee")
                      .Include("InvoiceLines.Track.Album.Artist")
                      .Include("InvoiceLines.Track.MediaType")
                      .SingleOrDefault(t => t.InvoiceId == id);

            return (o == null) ? null : Mapper.Map<Invoice, InvoiceWithDetail>(o);
        }
        

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
    }
}