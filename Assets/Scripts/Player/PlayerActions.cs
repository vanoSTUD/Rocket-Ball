using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerInput))]
	public class PlayerActions : MonoBehaviour
	{
		private void OnKick()
		{
			KickManager.HandleKick(this.transform);
		}
	}
}