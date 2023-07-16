using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace Infrastructure
{
    public class Conveyor : MonoBehaviour
    {
        [SerializeField] private GameObject _pineapplePrefab;
        [SerializeField] private GameObject _croissaintPrefab;
        [SerializeField] private GameObject _burgerPrefab;

        [SerializeField] private Transform _poolContainer;
        
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [SerializeField] private float _movingSpeed = 2f;
        [SerializeField] private float _itemsSpaceBetween = .2f;

        [SerializeField] private TextureMover _textureMover;

        private GameObject _pineappleContainer;
        private GameObject _croissantContainer;
        private GameObject _burgerContainer;
        
        private bool _canGenerate;
        private float _passedWay;
        private bool _canTick;

        void Start()
        {
            _canGenerate = true;
            _textureMover.SetSpeed(_movingSpeed);
            InitContainers();
        }


        private void InitContainers()
        {
            _pineappleContainer = new GameObject("Pineapple container");
            _pineappleContainer.transform.SetParent(_poolContainer);

            _croissantContainer = new GameObject("Croissant container");
            _croissantContainer.transform.SetParent(_poolContainer);

            _burgerContainer = new GameObject("Burger container");
            _burgerContainer.transform.SetParent(_poolContainer);

        }

        private void SpawnPineapple()
        {
            var pineapple = Instantiate(_pineapplePrefab, _pineappleContainer.transform);
            pineapple.transform.position = _startPoint.position;
        }
        
        private void SpawnCroissant()
        {
            var croissant = Instantiate(_croissaintPrefab, _croissantContainer.transform);
            croissant.transform.position = _startPoint.position;
        }
        
        private void SpawnBurger()
        {
            var burger = Instantiate(_burgerPrefab, _burgerContainer.transform);
            burger.transform.position = _startPoint.position;
        }

        void Update()
        {
            WaitTimer();
            
            GenerateProducts();
            MoveOnConveyor();
        }

        private void GenerateProducts()
        {
            if (_canGenerate == false)
                return;
            
            int randomProduct = Random.Range(0, 3);
            switch (randomProduct)
            {
                case 0:
                    SpawnPineapple();
                    break;
                case 1:
                    SpawnCroissant();
                    break;
                case 2:
                    SpawnBurger();
                    break;
            }

            _canGenerate = false;
            _canTick = true;
        }

        private void WaitTimer()
        {
            if (_canTick == false)
                return;
            
            _passedWay += _movingSpeed * Time.deltaTime;
            
            
            if(_passedWay >= _itemsSpaceBetween)
            {
                _passedWay = 0f;
                _canGenerate = true;
                _canTick = false;
            }
        }

        private void MoveOnConveyor()
        {
            MoveItems(_pineappleContainer.transform);
            MoveItems(_croissantContainer.transform);
            MoveItems(_burgerContainer.transform);
        }

        private void MoveItems(Transform container)
        {
            foreach (Transform item in container)
            {
                if (item.gameObject.activeSelf == false)
                    continue;

                Vector3 movingDirection = (_endPoint.position - _startPoint.position).normalized;
                item.position += movingDirection * (_movingSpeed * Time.deltaTime);
                
                bool reachedDestination = Vector3.Distance(item.position, _endPoint.position) <= 0.05f;
                if(reachedDestination)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
