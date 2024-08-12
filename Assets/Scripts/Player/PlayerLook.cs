using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerLook
	{
		private readonly Transform _player;
		private readonly float _angleRotation = 5f;
		private readonly float _speedRotation = 7f;

		private bool _isFlip = false;

		public PlayerLook(Transform player)
        {
            _player = player;
        }

		public void HandleMovement(Vector2 movement)
		{
			if (movement.x > 0 && _isFlip == false)
			{
				_isFlip = true;
				Flip();
			}
			else if (movement.x < 0 && _isFlip == true)
			{
				_isFlip = false;
				Flip();
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
				RotateAvatar(new Vector3(0, 0, -_angleRotation));
			else
				RotateAvatar(new Vector3(0, 0, _angleRotation));
		}

		private void LookDown()
		{
			if (!_isFlip)
				RotateAvatar(new Vector3(0, 0, _angleRotation));
			else
				RotateAvatar(new Vector3(0, 0, -_angleRotation));
		}

		private void LookForward()
		{
			RotateAvatar(Vector3.zero);
		}

		private void RotateAvatar(Vector3 rotationAngle)
		{
			_player.rotation = Quaternion.Slerp(_player.rotation, Quaternion.Euler(rotationAngle), _speedRotation * Time.deltaTime);
		}

		private void Flip()
		{
			var currentScale = _player.localScale;
			currentScale.x *= -1;
			_player.localScale = currentScale;
		}

	}
}