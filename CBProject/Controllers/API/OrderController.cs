﻿using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class OrderController : ApiController, IDisposable
    {
        private readonly OrdersRepository _ordersRepository;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this._ordersRepository = unitOfWork.Orders;
        }

        // GET api/Order
        public async Task<IHttpActionResult> Get()
        {
            var orders = await this._ordersRepository.GetAllEmptyAsync();
            return Ok(orders);
        }

        // GET api/Order/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var order = await this._ordersRepository.GetEmptyAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // POST api/Order
        public async Task<IHttpActionResult> Post([FromBody] Order order)
        {
            if (order == null)
                return NotFound();
            this._ordersRepository.Add(order);
            await this._ordersRepository.SaveAsync();
            return Ok(order);
        }

        // PUT api/Order
        public async Task<IHttpActionResult> Put([FromBody] Order order)
        {
            if (order == null)
                return NotFound();
            this._ordersRepository.Update(order);
            await this._ordersRepository.SaveAsync();
            return Ok(order);
        }

        // DELETE api/Order/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id == null)
                return NotFound();
            await this._ordersRepository.DeleteAsync(id);
            await this._ordersRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Order/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._ordersRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Order/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._ordersRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ordersRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}