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
        
        [SerializeField] private int _eachProductPoolSize = 5;
        [SerializeField] private int _eachProductMaxPoolSize = 10;
        
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        [SerializeField] private float _movingSpeed = 2f;
        [SerializeField] private float _itemsSpaceBetween = .2f;

        [SerializeField] private TextureMover _textureMover;

        private ObjectPool<GameObject> _pineapplePool;
        private ObjectPool<GameObject> _croissantPool;
        private ObjectPool<GameObject> _burgerPool;

        private GameObject _pineappleContainer;
        private GameObject _croissantContainer;
        private GameObject _burgerContainer;
        
        private bool _canGenerate;
        private float _passedWay;
        private bool _canTick;

        void Start()
        {
            _canGenerate = true;
            InitPools();

            _textureMover.SetSpeed(_movingSpeed);
        }

        private void InitPools()
        {
            _pineappleContainer = new GameObject("Pineapple container");
            _pineappleContainer.transform.SetParent(_poolContainer);

            _croissantContainer = new GameObject("Croissant container");
            _croissantContainer.transform.SetParent(_poolContainer);

            _burgerContainer = new GameObject("Burger container");
            _burgerContainer.transform.SetParent(_poolContainer);

            InitializePool(ref _pineapplePool, _pineapplePrefab, _pineappleContainer.transform);
            InitializePool(ref _croissantPool, _croissaintPrefab, _croissantContainer.transform);
            InitializePool(ref _burgerPool, _burgerPrefab, _burgerContainer.transform);
        }

        private void InitializePool(ref ObjectPool<GameObject> targetPool, GameObject prefab, Transform parent)
        {
            targetPool = new ObjectPool<GameObject>(() =>
            {
                return Instantiate(prefab, parent);
            }, item =>
            {
                item.gameObject.SetActive(true);
                item.transform.position = _startPoint.position;
            }, item =>
            {
                item.gameObject.SetActive(false);
            }, item =>
            {
                Destroy(item.gameObject);
            }, false, _eachProductPoolSize, _eachProductMaxPoolSize);
        }

        private void SpawnPineapple()
        {
            var pineapple = _pineapplePool.Get();
        }
        
        private void SpawnCroissant()
        {
            var croissant = _croissantPool.Get();
            
        }
        
        private void SpawnBurger()
        {
            var burger = _burgerPool.Get();
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
            MoveItemsInPool(_pineappleContainer.transform, _pineapplePool);
            MoveItemsInPool(_croissantContainer.transform, _croissantPool);
            MoveItemsInPool(_burgerContainer.transform, _burgerPool);
        }

        private void MoveItemsInPool(Transform container, ObjectPool<GameObject> pool)
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
                    pool.Release((item.gameObject));
                }
            }
        }
    }
}
