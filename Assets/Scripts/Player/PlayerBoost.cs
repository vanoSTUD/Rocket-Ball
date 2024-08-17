using Assets.Scripts.Boosting;
using Assets.Scripts.Managers;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerInput))]
	public class PlayerBoost : MonoBehaviour
	{
		[SerializeField] private GameObject _boostPrefab;

		private BoostPool _boostPool;

		public bool IsBoosting { get; private set; }

		private void Awake()
		{
			_boostPool = new BoostPool(_boostPrefab);
		}

		public void Spawn()
		{
			Boost boost = _boostPool.Get().GetComponent<Boost>();
			boost.transform.position = transform.position;
			boost.EndAnimationAction += OnEndAnimation;

			void OnEndAnimation()
			{
				boost.EndAnimationAction -= OnEndAnimation;
				_boostPool.Release(boost.gameObject);
			}
		}

		public void SetActive(bool isBoostActive)
		{
			IsBoosting = isBoostActive;
		}
 
		// called PlayerInput
		private void OnBoost(InputValue inputValue)
		{
			bool hasActive = Convert.ToBoolean(inputValue.Get<float>());
			IsBoosting = hasActive;
		}
	}
}