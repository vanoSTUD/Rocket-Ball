using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(PlayerInput))]
	public class PlayerActions : MonoBehaviour
	{



		// Сalled when the user clicks on the space bar
		private void OnKick()
		{
			KickManager.HandleKick(this.transform);
		}
	}
}