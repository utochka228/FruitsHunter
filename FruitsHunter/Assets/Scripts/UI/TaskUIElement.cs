using System.Collections;
using System.Collections.Generic;
using Infrastructure.LevelTasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class TaskUIElement : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _requiredLabel;

        public void SetupElement(TaskGenerator.TaskItem taskItem)
        {
            _icon.sprite = taskItem.TaskProduct.Icon;
            _requiredLabel.text = $"0/{taskItem.RequiredCount}";
        }
    }
}
