using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _playerSpeed = 10;

    private Rigidbody2D _player;
	private Vector2 _movementVector = Vector2.zero;

	void Start()
    {
        _player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
		if (_movementVector == Vector2.zero)
			return;

		_player.AddForce(_playerSpeed * _movementVector);
	}

	private void OnMove(InputValue movementValue)
	{
		_movementVector = movementValue.Get<Vector2>();
		Debug.Log(_movementVector);
	}
}
