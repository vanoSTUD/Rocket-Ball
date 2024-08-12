using UnityEngine;
using Assets.Scripts.Enums;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerAnimation))]
	public class PlayerLook : MonoBehaviour
	{
		private PlayerAnimation _playerAnimation;
		private bool _isFlip = false;

		private void Awake()
		{
			_playerAnimation = GetComponent<PlayerAnimation>();
		}

		public void HandleMovement(Vector2 movement)
		{
			if (movement.x > 0 && _isFlip == false)
			{
				_isFlip = true;
				_playerAnimation.Flip();
			}
			else if (movement.x < 0 && _isFlip == true)
			{
				_isFlip = false;
				_playerAnimation.Flip();
			}

			if (movement.y > 0)
				LookUp();
			else if (movement.y < 0)
				LookDown();
			else if (movement.y == 0)
				LookForward();
		}

		private void LookUp()
		{
			if (!_isFlip)
				_playerAnimation.Look(LookDirections.Down);
			else
				_playerAnimation.Look(LookDirections.Up);
		}

		private void LookDown()
		{
			if (!_isFlip)
				_playerAnimation.Look(LookDirections.Up);
			else
				_playerAnimation.Look(LookDirections.Down);
		}

		private void LookForward()
		{
			_playerAnimation.Look(LookDirections.Forward);
		}
	}
}