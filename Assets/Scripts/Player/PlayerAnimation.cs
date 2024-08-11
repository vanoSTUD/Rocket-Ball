using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerAppearance))]
	public class PlayerAnimation : MonoBehaviour
	{
		private PlayerAppearance _playerAppearance;

		private void Awake()
		{
			_playerAppearance = GetComponent<PlayerAppearance>();
		}



		private void Flip()
		{

		}
	}
}