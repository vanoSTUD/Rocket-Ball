using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Boosting
{
	public class BoostPool
	{
        private GameObject _boostPrefab;
		private ObjectPool<GameObject> _pool;

        public BoostPool(GameObject boostPrefab)
        {
            _boostPrefab = boostPrefab;
			_pool = new ObjectPool<GameObject>(OnCreated, OnGet, OnRelease, defaultCapacity: 150);
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
            return GameObject.Instantiate(_boostPrefab);
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