﻿using InventoryManagement.Domain;
using InventoryManagement.Exceptions;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using InventoryManagement.Reposits;


    public class OrderService : IOrder
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _prodRepository;

        public OrderService(IRepository<Order> repository, IRepository<Product> prodRepository)
        {
            _repository = repository;
            _prodRepository = prodRepository;
        }

        public Guid AddOrder(PostOrder order)
        {
            var orderDetails = new Order()
            {
                CustomerId = order.CustomerId,
                Products = GetProductList(order.ProductIdAndQuantity, Guid.Empty),
                Status = "Placed"
            };
            _repository.Add(orderDetails);
            return orderDetails.Id;

        }

        public void DeleteOrder(Guid id)
        {
            var ord = _repository.Get(id);
            if (ord != null)
                _repository.Delete(ord);
            else throw new EntityNotFoundException("order not found");
        }



        private ICollection<OrderProduct> GetProductList(IDictionary<Guid, int> prodQuant, Guid id)
        {
            ICollection<OrderProduct> _prodQuant = new List<OrderProduct>();
            foreach (var productIdAndQuantity in prodQuant)
            {
                var productId = productIdAndQuantity.Key;
                var quantity = productIdAndQuantity.Value;
                if (quantity < 0 || quantity > _prodRepository.Get(productId).Quantity)
                {
                    throw new InsufficientInventoryException("Invalid quantity amount");
                }
                else
                {
                    _prodQuant.Add(new OrderProduct()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                    });
                    var prod = _prodRepository.Get(productId);
                    prod.Quantity -= quantity;
                    _prodRepository.Update(prod);
                }
            }
            return _prodQuant;

        }
    }


