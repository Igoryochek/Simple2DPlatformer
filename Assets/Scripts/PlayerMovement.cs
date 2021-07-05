using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private UnityEvent _idle;
    [SerializeField] private UnityEvent _run;

    private bool _isGrounded = true;
    private int _rotationAngleByY;

    private void Update()
    {
        MovePlayer();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isGrounded = false;
        }
    }

    private void MovePlayer()
    {
        _idle.Invoke();

        if (Input.GetKey(KeyCode.D))
        {
            _rotationAngleByY = 0;
            Rotate(_rotationAngleByY);
            Move();
            _run.Invoke();
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rotationAngleByY = 180;
            Rotate(_rotationAngleByY);
            Move();
            _run.Invoke();
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void Rotate(int degreesY)
    {
        transform.rotation = new Quaternion(0, degreesY, 0, 1);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _player.AddForce(Vector2.up * _force);
            _run.Invoke();
        }
        
    }
}
