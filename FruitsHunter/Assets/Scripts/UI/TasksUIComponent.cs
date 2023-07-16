using System.Collections;
using System.Collections.Generic;
using Infrastructure.LevelTasks;
using UnityEngine;

namespace Infrastructure.UI
{
    public class TasksUIComponent : MonoBehaviour
    {
        [SerializeField] private TaskUIElement _taskUIElementPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private TaskGenerator _taskGenerator;
        
        void Awake()
        {
            _taskGenerator.OnTaskGenerated += OnTaskGenerated;
        }

        private void OnTaskGenerated(TaskGenerator.LevelTask levelTask)
        {
            foreach (var taskItem in levelTask.Item)
            {
                var spawnedItem = Instantiate(_taskUIElementPrefab, _container);
                spawnedItem.SetupElement(taskItem);
            }
        }
    }
}
