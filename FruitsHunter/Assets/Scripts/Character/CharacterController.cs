using System.Collections;
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

        public void TryGrabProduct(ProductHolder productHolder)
        {
            TryGrabState();
            Debug.Log("Try grab " + productHolder.AssignedProduct.Name);
            _target = productHolder.transform;
        }

        private void Start()
        {
            _characterHand.OnItemTaken += GatherToBasketState;
            _rightArmRig.weight = 0f;
        }

        private void Update()
        {
            LerpLookPoint();
        }

        private void LerpLookPoint()
        {
            if (_target == null)
                return;
            
            _lookPoint.position = Vector3.Lerp(_lookPoint.position, _target.position, Time.deltaTime * _lookingSpeed);
        }

        private void SetIdleState()
        {
            StartCoroutine(LerpRigWeight(0f, 1f));
        }

        private void TryGrabState()
        {
            StartCoroutine(LerpRigWeight(1f, 1f));
            StartCoroutine(WaitAndSetIdle());
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
        
        IEnumerator LerpRigWeight(float endValue, float duration)
        {
            float time = 0;
            float startValue = _rightArmRig.weight;
            while (time < duration)
            {
                _rightArmRig.weight = Mathf.Lerp(startValue, endValue, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            _rightArmRig.weight = endValue;
        }
    }
}
