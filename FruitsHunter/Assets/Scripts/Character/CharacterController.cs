using System.Collections;
using DG.Tweening;
using Infrastructure.Products;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Infrastructure.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _timeToIdle = 1f;
        [SerializeField] private Rig _rightArmRig;
        [SerializeField] private CharacterHand _characterHand;
        
        [SerializeField] private Transform _lookPoint;
        [SerializeField] private float _lookingSpeed = 2f;
        private Transform _target;
        
        [SerializeField] private float raiseHandDuration = 0.5f;
        [SerializeField] private Ease handRaiseEase;
        
        [SerializeField] private float letdownHandDuration = 0.5f;
        [SerializeField] private Ease handLetdownEase;

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;
        
        [SerializeField] private float _pingPongSpeed = 0.5f;
        
        private Coroutine waitCoroutine;
        private bool _idle;

        public void TryGrabProduct(ProductHolder productHolder)
        {
            TryGrabState();
            _target = productHolder.transform;
        }

        private void Start()
        {
            _characterHand.OnItemTaken += GatherToBasketState;
            _rightArmRig.weight = 0f;
            _idle = true;
        }

        private void Update()
        {
            LerpLookPoint();
            //SmoothLookPointMoving();
        }

        private void SmoothLookPointMoving()
        {
            if (_idle == false)
                return;
            
            _lookPoint.position = Vector3.Lerp(_startPoint.position, _endPoint.position, Mathf.PingPong(Time.time * _pingPongSpeed, 1f));
        }

        private void LerpLookPoint()
        {
            if (_target == null)
                return;
            
            _lookPoint.position = Vector3.Lerp(_lookPoint.position, _target.position, Time.deltaTime * _lookingSpeed);
        }
        
        private void SetIdleState()
        {
            DOVirtual.Float(_rightArmRig.weight, 0f, letdownHandDuration, value => _rightArmRig.weight = value).SetEase(handLetdownEase);
            _lookPoint.DOMove(_endPoint.position, 1f).OnComplete((() =>
            {
                _lookPoint.DOMove(_startPoint.position, _pingPongSpeed).SetLoops(-1, LoopType.Yoyo).SetId("yoyo");
            }));
        }

        private void TryGrabState()
        {
            DOTween.Kill("yoyo");
            
            DOVirtual.Float(_rightArmRig.weight, 1f, raiseHandDuration, value => _rightArmRig.weight = value).SetEase(handRaiseEase);
            
            if(waitCoroutine != null)
                StopCoroutine(waitCoroutine);
            waitCoroutine = StartCoroutine(WaitAndSetIdle());
        }

        private IEnumerator WaitAndSetIdle()
        {
            yield return new WaitForSeconds(_timeToIdle);
            SetIdleState();
        }

        private void GatherToBasketState()
        {
            
            // SetIdleState after gathered!
        }
    }
}
