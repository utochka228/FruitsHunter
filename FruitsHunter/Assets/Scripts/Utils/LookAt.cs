using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Utils
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        void Update()
        {
            if (_target == null)
                return;
            
            transform.LookAt(_target);
        }
    }
}
