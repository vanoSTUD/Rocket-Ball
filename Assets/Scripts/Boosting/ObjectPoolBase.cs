using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Boosting
{
	public class ObjectPoolBase
	{
        private GameObject _prefab;
		private ObjectPool<GameObject> _pool;

        public ObjectPoolBase(GameObject prefab)
        {
            _prefab = prefab;
			_pool = new ObjectPool<GameObject>(OnCreated, OnGet, OnRelease, defaultCapacity: 50);
        }

		public GameObject Get()
		{
			return _pool.Get();
		}

		public void Release(GameObject boostPrefab)
		{
			_pool.Release(boostPrefab);
		}
        
        private GameObject OnCreated()
        {
            return GameObject.Instantiate(_prefab);
        }

		private void OnGet(GameObject boostPrefab)
		{
			boostPrefab.SetActive(true);
		}

		private void OnRelease(GameObject boostPrefab)
		{
			boostPrefab.SetActive(false);
		}
	}
}