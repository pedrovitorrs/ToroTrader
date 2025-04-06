using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Domain.Entities.Base;

namespace ToroTrader.Application.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Guid userId, Guid productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity > 0 ? quantity : throw new ArgumentNullException(nameof(Quantity));
        }

        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public OrderStatus Status { get; private set; } = OrderStatus.Pendente;
        public string ErrorMessage { get; private set; }

        public User User { get; private set; } = null!;
        public Product Product { get; private set; } = null!;

        public void SetError(string message)
        {
            Status = OrderStatus.Erro;
            ErrorMessage = message;
        }
    }

    public enum OrderStatus
    {
        Pendente,
        Concluido,
        Cancelado,
        Erro
    }
}
