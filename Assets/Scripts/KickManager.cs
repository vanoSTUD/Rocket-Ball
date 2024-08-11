using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class KickManager : MonoBehaviour
	{
		private static readonly float _kickForce = 7;
		private static readonly float _kickRadius = 0.25f;

		public static void HandleKick(Transform kicker)
		{
			if (kicker.TryGetComponent(out Rigidbody2D kikerRb) == false)
				return;

			var targets = GetTargets(kicker);

			if (targets.Count == 0)
				return;
			
			KickTargets(kikerRb, targets);
		}

		private static List<Rigidbody2D> GetTargets(Transform kicker)
		{
			float kickerRadius = kicker.GetComponent<CircleCollider2D>().radius;
			float overlapRarius = kickerRadius + _kickRadius;

			Collider2D[] colliders = Physics2D.OverlapCircleAll(kicker.position, overlapRarius);
			List<Rigidbody2D> targets = new();

			foreach (Collider2D collider in colliders)
			{
				if (collider.attachedRigidbody != null && collider.name != kicker.name)
					targets.Add(collider.attachedRigidbody);
			}

			return targets;
		} 

		private static void KickTargets(Rigidbody2D kicker, List<Rigidbody2D> targets)
		{
			foreach (Rigidbody2D target in targets)
			{
				Vector2 heading = target.position - kicker.position;
				float distance = heading.magnitude;
				Vector2 direction = heading / distance;

				target.AddForce(_kickForce * direction, ForceMode2D.Impulse);
			}
		}
	}
}