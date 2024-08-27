using Assets.Scripts.Enums;
using Assets.Scripts.Player;

namespace Assets.Scripts.Managers
{
	public class PlayersAppearanceManager
	{
		public static void SetAvatar(Avatars avatar, PlayerAppearance playerAppearance)
		{
			playerAppearance.SetAvatar(avatar);
		}

		public static void SetTeam(Teams team, PlayerClient player, PlayerAppearance playerAppearance)
		{
			playerAppearance.UnsetCircle(playerAppearance.CurrentCircle);

			if (team == Teams.Red)
				playerAppearance.SetCircle(Circles.Red);

			else if (team == Teams.Blue)
				playerAppearance.SetCircle(Circles.Blue);

			player.SetTeam(team);
		}
	}
}
