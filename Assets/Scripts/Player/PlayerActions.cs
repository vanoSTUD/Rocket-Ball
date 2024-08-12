using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Player
{
	[RequireComponent(typeof(UnityEngine.InputSystem.PlayerInput))]
	public class PlayerActions : MonoBehaviour
	{
		[SerializeField] private PlayerAppearance _playerAppearance;
		[SerializeField] private PlayerAnimation _playerAnimation;

		private void Start()
		{
			if (_playerAnimation == null)
				throw new UnityException("playerAnimation is null");
		}

		private void Update()
		{
			if (Input.anyKey == false)
				return;

			ProcessAvatarChange();

			ProcessTeamChange();
		}

		// Сalled when the user clicks on the space bar // New Input System
		private void OnKick()
		{
			KickManager.HandleKick(transform, _playerAnimation);
		}

		private void ProcessAvatarChange()
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
				SetAvatar(Avatars.Injesta);

			else if (Input.GetKeyDown(KeyCode.Alpha2))
				SetAvatar(Avatars.Messi);

			else if (Input.GetKeyDown(KeyCode.Alpha3))
				SetAvatar(Avatars.Pele);

			else if (Input.GetKeyDown(KeyCode.Alpha4))
				SetAvatar(Avatars.Suarez);
		}

		private void ProcessTeamChange()
		{
			if (Input.GetKeyDown(KeyCode.T))
				SetTeam(Teams.Blue);

			else if (Input.GetKeyDown(KeyCode.Y))
				SetTeam(Teams.Red);
		}
		
		private void SetTeam(Teams team)
		{
			PlayersAppearanceManager.SetTeam(team, _playerAppearance);
		}

		private void SetAvatar(Avatars avatar)
		{
			PlayersAppearanceManager.SetAvatar(avatar, _playerAppearance);
		}
	}
}