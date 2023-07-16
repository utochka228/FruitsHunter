using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Products
{
    [CreateAssetMenu(menuName = "Create conveyor product", fileName = "Product")]
    public class Product : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
    }
}
