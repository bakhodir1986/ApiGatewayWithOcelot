using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Service_BLL
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }

        public Cart GetCartInfo(Guid id)
        {
            if (id == Guid.Empty) throw new Exception("Empty cart id");
            return _cartRepository.GetCartInfo(id);
        }
        public void AddCartItem(Guid cartId, Item item)
        {
            if ((cartId == Guid.Empty) || (item == null)) throw new Exception("Empty cart id");

            var cart = GetCartInfo(cartId);

            if (cart == null)
            {
                var newCartId = cartId;
                _cartRepository.AddCart(new Cart { Id = newCartId });
                _cartRepository.AddCartItem(newCartId, item);
            }

            _cartRepository.AddCartItem(cartId, item);
        }
        public void DeleteCartItem(Guid cartId, int itemId)
        {
            if ((cartId == Guid.Empty) || (itemId == 0)) throw new Exception("Empty cart id");
            _cartRepository.DeleteCartItem(cartId, itemId);
        }
        public IEnumerable<Item> GetCartInfoV2(Guid id)
        {
            if (id == Guid.Empty) throw new Exception("Empty cart id");
            return _cartRepository.GetCartInfoV2(id);
        }
    }
}
