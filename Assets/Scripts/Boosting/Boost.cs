using System;
using UnityEngine;

namespace Assets.Scripts.Boosting
{
	public class Boost : MonoBehaviour
	{
		public Action EndAnimationAction;

		public void EndAnimation()
		{
			EndAnimationAction?.Invoke();
		}
	}
}
