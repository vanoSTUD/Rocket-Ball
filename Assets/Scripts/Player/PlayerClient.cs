using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerClient : MonoBehaviour
	{
		public Teams Team {  get; private set; }

		public void SetTeam(Teams team)
		{
			Team = team;
		}
	}
}