using Assets.Scripts.Player;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerBoost))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _playerSpeed = 10;
	[SerializeField] private float _playerBoostingSpeed = 17;
	[SerializeField] private PlayerClient _player;
	[SerializeField] private Rigidbody2D _playerRb;
	[SerializeField] private PlayerLook _playerLook;

	private Vector2 _movementVector = Vector2.zero;

	public bool IsBoosting { get; private set; }

    private void FixedUpdate()
    {
		ProccessMove();
	}

	public Action Boost;

	public void SetBoost(bool hasBoost)
	{
		IsBoosting = hasBoost;
	}

	private void ProccessMove()
	{
		if (_movementVector == Vector2.zero)
			return;

		if (IsBoosting)
		{
			_playerRb.AddForce(_playerBoostingSpeed * _movementVector);
			Boost?.Invoke();
		}
		else
		{
			_playerRb.AddForce(_playerSpeed * _movementVector);
		}

		_playerLook.HandleMovement(_movementVector);
	}

	private void OnMove(InputValue movementValue)
	{
		_movementVector = movementValue.Get<Vector2>();
	}
}
