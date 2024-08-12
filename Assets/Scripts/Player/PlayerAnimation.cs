using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerAppearance))]
	public class PlayerAnimation : MonoBehaviour
	{
		[SerializeField] private float _rotationAngle = 5f;
		[SerializeField] private float _rotationSpeed = 7f;

		private PlayerAppearance _playerAppearance;
		private Transform _playerAvatar;

		private void Start()
		{
			_playerAppearance = transform.GetComponent<PlayerAppearance>();
			_playerAvatar = _playerAppearance.GiveAvatar();
		}

		public void Look(LookDirections lookAt)
		{
			Vector3 rotationAngle = new (0, 0, _rotationAngle);

			if (lookAt == LookDirections.Down)
				rotationAngle *= -1;

			else if (lookAt == LookDirections.Forward)
				rotationAngle = Vector3.zero;

			_playerAvatar.rotation = Quaternion.Slerp(_playerAvatar.rotation, Quaternion.Euler(rotationAngle), _rotationSpeed * Time.deltaTime);
		}

		public void ShowKick()
		{
			StartCoroutine(YellowCircleAnimation());
		}

		public void Flip()
		{
			var currentScale = _playerAvatar.localScale;
			currentScale.x *= -1;
			_playerAvatar.localScale = currentScale;
		}

		private IEnumerator YellowCircleAnimation()
		{
			_playerAppearance.SetCircle(Circles.Yellow);
			yield return new WaitForSecondsRealtime(0.1f);
			_playerAppearance.UnsetCircle(Circles.Yellow);
		}
	}
}