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
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private PlayerClient _player;

		private ObjectPoolBase _boostPool;

		private void Awake()
		{
			_boostPool = new ObjectPoolBase(_boostPrefab);

			_playerMovement.Boost += Spawn;
		}

		private void OnDestroy()
		{
			_playerMovement.Boost -= Spawn;
		}

		public void Spawn()
		{
			Color boostColor = ColorManager.GetColorByTeam(_player.Team);
			Boost boost = _boostPool.Get().GetComponent<Boost>();
			boost.SetColor(boostColor);
			boost.transform.position = transform.position;
			boost.EndAnimationAction += OnEndAnimation;

			void OnEndAnimation()
			{
				boost.EndAnimationAction -= OnEndAnimation;
				_boostPool.Release(boost.gameObject);
			}
		}
 
		// call PlayerInput
		private void OnBoost(InputValue inputValue)
		{
			bool hasActive = Convert.ToBoolean(inputValue.Get<float>());
			_playerMovement.SetBoost(hasActive);
		}
	}
}