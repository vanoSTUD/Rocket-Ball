namespace Assets.Scripts.Managers
{
	public static class BoostManager
	{
		public static void ProcessBoost(PlayerMovement playerMovement, bool hasActive)
		{
			playerMovement.SetBoost(hasActive);
		}
	}
}
