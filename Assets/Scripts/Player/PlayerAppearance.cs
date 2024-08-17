using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerAppearance : MonoBehaviour
	{
		[SerializeField] private GameObject _objectOfAvatars;
		[SerializeField] private GameObject _objectOfCircles;

		private readonly Dictionary<Avatars, GameObject> _avatars = new();
		private readonly Dictionary<Circles, GameObject> _circles = new();

		public Avatars CurrentAvatar {  get; private set; }
		public Circles CurrentCircle {  get; private set; }

		private void Awake()
		{
			FillAvatars();
			FillCircles();

			SetStartingAppearance();
		}

		public Transform GiveAvatar()
		{
			return _objectOfAvatars.transform;
		}

		public void SetCircle(Circles circle)
		{
			if (circle == Circles.White || circle == Circles.Yellow)
			{
				_circles[circle].SetActive(true);
			}
			else
			{
				_circles[CurrentCircle].SetActive(false);
				_circles[circle].SetActive(true);

				CurrentCircle = circle;
			}
		}

		public void UnsetCircle(Circles circle)
		{
			_circles[circle].SetActive(false);
		}

		public void SetAvatar(Avatars avatar)
		{
			_avatars[CurrentAvatar].SetActive(false);
			_avatars[avatar].SetActive(true);

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
			List<GameObject> objectsOfAvatars = _objectOfAvatars.GetComponentsInChildren<Transform>(true)
				.Where(trm => trm.name != _objectOfAvatars.name)
				.Select(trm => trm.gameObject)
				.ToList();

			foreach (Avatars avatar in Enum.GetValues(typeof(Circles)))
			{
				string avatarName = avatar.ToString();
				GameObject avatarObject = objectsOfAvatars.Find(obj => obj.name == avatarName);

				if (avatarObject != null)
					_avatars.Add(avatar, avatarObject);
			}
		}

		private void FillCircles()
		{
			List<GameObject> objectsOfCircles = _objectOfCircles.GetComponentsInChildren<Transform>(true)
				.Where(trm => trm.name != _objectOfCircles.name)
				.Select(trm => trm.gameObject)
				.ToList();

			foreach (Circles circle in Enum.GetValues(typeof(Circles)))
			{
				string circleName = circle.ToString();
				GameObject circleObject = objectsOfCircles.Find(obj => obj.name == circleName);

				if (circleObject != null)
					_circles.Add(circle, circleObject);
			}
		}
	}
}