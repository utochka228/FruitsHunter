using System;
using Infrastructure.Products;
using UnityEngine;

namespace Infrastructure.Character
{
    public class CharacterHand : MonoBehaviour
    {
        public Action OnItemTaken;
        private void OnTriggerEnter(Collider other)
        {
            bool success = other.TryGetComponent<ProductHolder>(out var product);
            if (success == false)
                return;
            
            Debug.Log($"Product {product.AssignedProduct.Name} taken!");
            product.transform.SetParent(transform);
            
            OnItemTaken?.Invoke();
        }
    }
}
