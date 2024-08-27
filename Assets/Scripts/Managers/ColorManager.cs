using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Managers
{
	public static class ColorManager
	{
		private static Color _colorRedTeam = new(0.9529412f, 0.2862745f, 0.1215686f, 0.7f);
		private static Color _colorBlueTeam = new (0.133f, 0.518f, 0.89f, 0.7f);

		public static Color GetColorByTeam(Teams team)
		{
			if (team == Teams.Blue)
				return _colorBlueTeam;

			if (team == Teams.Red)
				return _colorRedTeam;




			return _colorRedTeam;
		}
	}
}
