using System;
using Infrastructure.Products;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infrastructure.LevelTasks
{
    public class TaskGenerator : MonoBehaviour
    {
        [SerializeField] private int _minItemRequiredCount = 1;
        [SerializeField] private int _maxItemRequiredCount = 6;
        [SerializeField] private Product[] _gameProducts;
        
        private LevelTask _levelTask;

        public Action<LevelTask> OnTaskGenerated;
        
        void Start()
        {
            GenerateLevelTask();
        }

        private void GenerateLevelTask()
        {
            int itemsAmount = _gameProducts.Length;
            _levelTask.Item = new TaskItem[itemsAmount];
            for (int i = 0; i < itemsAmount; i++)
            {
                int requiredCount = Random.Range(_minItemRequiredCount, _maxItemRequiredCount);
                _levelTask.Item[i].TaskProduct = _gameProducts[i];
                _levelTask.Item[i].RequiredCount = requiredCount;
            }

            OnTaskGenerated?.Invoke(_levelTask);
        }

        [Serializable]
        public struct LevelTask
        {
            public TaskItem[] Item;
        }
        [Serializable]
        public struct TaskItem
        {
            public Product TaskProduct;
            public int RequiredCount;
        }
    }
}
