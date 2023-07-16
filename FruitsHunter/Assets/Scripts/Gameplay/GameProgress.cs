using System.Linq;
using Infrastructure.LevelTasks;
using Infrastructure.Products;
using UnityEngine;

namespace Infrastructure.Gameplay
{
    public class GameProgress : MonoBehaviour
    {
        [SerializeField] private TaskGenerator _taskGenerator;
        [SerializeField] private Basket _basket;
        private TaskGenerator.LevelTask _levelTask;
        
        private void Start()
        {
            _taskGenerator.OnTaskGenerated += OnTaskGenerated;
            _basket.OnItemGathered += OnGathered;
        }

        private void OnTaskGenerated(TaskGenerator.LevelTask levelTask)
        {
            _levelTask = levelTask;
        }

        private void OnGathered(Product product)
        {
            var item = _levelTask.Item.Single(x => x.TaskProduct == product);
            item.GatheredCount++;
            CheckProgress();
        }

        private void CheckProgress()
        {
            foreach (var item in _levelTask.Item)
            {
                if (item.GatheredCount < item.RequiredCount)
                    return;
            }

            PassLevel();
        }

        private void PassLevel()
        {
            Debug.Log("Level passed!");
        }
    }
}
