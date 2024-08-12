using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _playerSpeed = 10;
	
	private PlayerLook _playerLook;
    private Rigidbody2D _player;
	private Vector2 _movementVector = Vector2.zero;

	void Start()
    {
		_playerLook = new PlayerLook(this.transform);
        _player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
		if (_movementVector == Vector2.zero)
			return;

		_player.AddForce(_playerSpeed * _movementVector);
		_playerLook.HandleMovement(_movementVector);
	}

	private void OnMove(InputValue movementValue)
	{
		_movementVector = movementValue.Get<Vector2>();
	}
}
