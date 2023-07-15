using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class TextureMover : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _speed = 2f;
        private Vector2 _offset;
        
        void Update()
        {
            if (_meshRenderer == null)
                return;

            _offset.x += Time.deltaTime * (_speed+1.1f);
            _meshRenderer.material.mainTextureOffset = _offset;
        }

        public void SetSpeed(float speed) => _speed = speed;
    }
}
