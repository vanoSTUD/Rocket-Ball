using Assets.Scripts.Boosting;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
	public static class BoostManager
	{
		public static void ProcessBoost(PlayerBoost playerBoost, bool hasActive)
		{
			playerBoost.SetActive(hasActive);
		}
	}
}
