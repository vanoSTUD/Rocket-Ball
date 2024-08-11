﻿using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerAppearance : MonoBehaviour
	{
		private Dictionary<Avatars, SpriteRenderer> _avatars = new();
		private Dictionary<Circles, SpriteRenderer> _circles = new();

		public Avatars CurrentAvatar {  get; private set; }

		private void Awake()
		{
			FillAvatars();
			FillCircles();

			SetStartingAppearance();
		}

		public void SetCircle(Circles circle)
		{
			var foundedCircle = _circles[circle];

			foundedCircle.enabled = true;
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
			CurrentAvatar = startingAvatar;

			SetAvatar(startingAvatar);
			SetCircle(Circles.White);
			SetCircle(Circles.Red);
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
			string name = avatar.ToString();

			SpriteRenderer output = transform.Find("Avatars").Find(name).GetComponent<SpriteRenderer>();

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

		private SpriteRenderer FindCircle(Circles avatar)
		{
			string name = avatar.ToString();

			Debug.Log(name);

			SpriteRenderer output = transform.Find("Circles").Find(name).GetComponent<SpriteRenderer>();

			Debug.Log(output);

			return output;
		}

	}
}