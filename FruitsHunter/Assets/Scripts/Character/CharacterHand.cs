using System;
using Infrastructure.Gameplay;
using Infrastructure.Products;
using UnityEngine;

namespace Infrastructure.Character
{
    public class CharacterHand : MonoBehaviour
    {
        public Action OnItemTaken;

        private ProductHolder _productInHand;
        
        private void OnTriggerEnter(Collider other)
        {
            CheckProduct(other);
            CheckBasket(other);
        }

        private void CheckBasket(Collider other)
        {
            bool success = other.TryGetComponent<Basket>(out var basket);
            if (success == false)
                return;

            basket.Gather(_productInHand);
            
            _productInHand = null;
        }

        private void CheckProduct(Collider other)
        {
            bool success = other.TryGetComponent<ProductHolder>(out var product);
            if (success == false)
                return;

            if (_productInHand != null)
                return;

            Debug.Log($"Product {product.AssignedProduct.Name} taken!");
            product.transform.SetParent(transform);
            product.transform.localPosition = Vector3.zero;

            _productInHand = product;

            OnItemTaken?.Invoke();
        }
    }
}
