using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerAppearance : MonoBehaviour
	{
		private const string ObjectOfAvatars = "Avatars";
		private const string ObjectOfCircles = "Circles";

		private readonly Dictionary<Avatars, SpriteRenderer> _avatars = new();
		private readonly Dictionary<Circles, SpriteRenderer> _circles = new();
		private Transform _playerAppearance;

		public Avatars CurrentAvatar {  get; private set; }
		public Circles CurrentCircle {  get; private set; }

		private void Awake()
		{
			_playerAppearance = transform;

			FillAvatars();
			FillCircles();

			SetStartingAppearance();
		}

		public Transform GiveAvatar()
		{
			return _playerAppearance.Find(ObjectOfAvatars).transform;
		}

		public void SetCircle(Circles circle)
		{
			if (circle == Circles.White || circle == Circles.Yellow)
			{
				_circles[circle].enabled = true;
			}
			else
			{
				_circles[CurrentCircle].enabled = false;
				_circles[circle].enabled = true;

				CurrentCircle = circle;
			}
		}

		public void UnsetCircle(Circles circle)
		{
			_circles[circle].enabled = false;
		}

		public void SetAvatar(Avatars avatar)
		{
			_avatars[CurrentAvatar].enabled = false;
			_avatars[avatar].enabled = true;

			CurrentAvatar = avatar;
		}

		private void SetStartingAppearance()
		{
			Avatars startingAvatar = Avatars.Suarez;
			Circles startingCircle = Circles.Red;

			SetAvatar(startingAvatar);
			SetCircle(startingCircle);
			SetCircle(Circles.White);
		}

		private void FillAvatars()
		{
			FillAvatar(Avatars.Injesta);
			FillAvatar(Avatars.Messi);
			FillAvatar(Avatars.Pele);
			FillAvatar(Avatars.Suarez);
		}

		private void FillAvatar(Avatars avatar)
		{
			SpriteRenderer avatarSpriteRenderer = FindAvatar(avatar);

			_avatars.Add(avatar, avatarSpriteRenderer);
		}

		private SpriteRenderer FindAvatar(Avatars avatar)
		{
			string avatarName = avatar.ToString();

			SpriteRenderer output = _playerAppearance.Find(ObjectOfAvatars).Find(avatarName).GetComponent<SpriteRenderer>();

			return output;
		}

		private void FillCircles()
		{
			FillCircle(Circles.White);
			FillCircle(Circles.Yellow);
			FillCircle(Circles.Blue);
			FillCircle(Circles.Red);
		}

		private void FillCircle(Circles circle)
		{
			SpriteRenderer avatarSpriteRenderer = FindCircle(circle);

			_circles.Add(circle, avatarSpriteRenderer);
		}

		private SpriteRenderer FindCircle(Circles circle)
		{
			string circleName = circle.ToString();

			SpriteRenderer output = _playerAppearance.Find(ObjectOfCircles).Find(circleName).GetComponent<SpriteRenderer>();

			return output;
		}

		
	}
}