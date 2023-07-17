using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Effects
{
    public class PopingItem : MonoBehaviour
    {
        [SerializeField] private float popHeight = 0.05f;
        [SerializeField] private float popDuration = 0.5f;
        [SerializeField] private Ease popEase;

        private bool _executing;

        public void PopItem()
        {
            if (_executing)
                return;

            _executing = true;
            transform.DOMoveY(transform.position.y + popHeight, popDuration).SetEase(popEase)
                .OnComplete((() =>
                {
                    transform.DOMoveY(transform.position.y - popHeight, popDuration).SetEase(popEase)
                        .OnComplete((() => _executing = false));
                }));
        }
    }
}
