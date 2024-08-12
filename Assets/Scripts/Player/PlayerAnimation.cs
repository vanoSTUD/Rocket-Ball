using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Player
{
	
	public class PlayerAnimation : MonoBehaviour
	{
		private PlayerAppearance _playerAppearance;

		private void Awake()
		{
			_playerAppearance = new PlayerAppearance(this.transform);
		}

		private void Flip()
		{

		}
	}
}