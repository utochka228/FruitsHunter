using System;
using Infrastructure.Products;
using UnityEngine;

namespace Infrastructure.Gameplay
{
    public class Basket : MonoBehaviour
    {
        [SerializeField] private Transform[] _basketPoints;
        private int _currIndex = 0;
        
        public Action<Product> OnItemGathered;

        public void Gather(ProductHolder productInHand)
        {
            var index = _currIndex % _basketPoints.Length;
            _currIndex++;
            var point = _basketPoints[index];
            
            productInHand.transform.SetParent(point);
            productInHand.transform.position = Vector3.zero;
            
            OnItemGathered?.Invoke(productInHand.AssignedProduct);
        }
    }
}
