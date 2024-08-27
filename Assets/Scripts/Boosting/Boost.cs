using System;
using UnityEngine;

namespace Assets.Scripts.Boosting
{
	public class Boost : MonoBehaviour
	{
		private SpriteRenderer _sprite;

		private void Awake()
		{
			_sprite = GetComponent<SpriteRenderer>();
		}

		public Action EndAnimationAction;

		public void SetColor(Color color)
		{
			_sprite.color = color;
		}

		public void EndAnimation()
		{
			EndAnimationAction?.Invoke();
		}
	}
}
