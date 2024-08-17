using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerBoost))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _playerSpeed = 10;
	[SerializeField] private float _playerBoostingSpeed = 15;
	[SerializeField] private PlayerLook _playerLook;

	private PlayerBoost _playerBoost;
    private Rigidbody2D _player;
	private Vector2 _movementVector = Vector2.zero;

	void Start()
    {
        _player = GetComponent<Rigidbody2D>();
		_playerBoost = GetComponent<PlayerBoost>();
	}

    private void FixedUpdate()
    {
		if (_movementVector == Vector2.zero)
			return;

		if (_playerBoost.IsBoosting)
		{
			_player.AddForce(_playerBoostingSpeed * _movementVector);
			_playerBoost.Spawn();
		}
		else
			_player.AddForce(_playerSpeed * _movementVector);

		_playerLook.HandleMovement(_movementVector);
	}

	private void OnMove(InputValue movementValue)
	{
		_movementVector = movementValue.Get<Vector2>();
	}
}
