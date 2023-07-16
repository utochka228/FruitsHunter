using System.Collections;
using System.Collections.Generic;
using Infrastructure.Input;
using Infrastructure.Products;
using UnityEngine;

namespace Infrastructure
{
    public class CameraCaster : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Character.CharacterController _characterController;
        private Camera _camera;
        void Start()
        {
            _camera = Camera.main;
            UserInput.OnScreenPressed += TryRaycastToProduct;
        }

        private void TryRaycastToProduct(Vector2 screenPos)
        {
            Ray ray = _camera.ScreenPointToRay(screenPos);
            Debug.DrawRay(ray.origin, (ray.direction - _camera.transform.position) * 10f);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _layerMask))
            {
                if (hit.transform.TryGetComponent<ProductHolder>(out var product) == false)
                    return;
                
                _characterController.TryGrabProduct(product);
            }
        }
    }
}
