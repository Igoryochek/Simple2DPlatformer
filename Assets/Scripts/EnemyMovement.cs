using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private UnityEvent _idle;
    [SerializeField] private UnityEvent _run;

    private int _currentPoint;

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        _run.Invoke();

        if (transform.position == target.position)
        {
            transform.Rotate(0, 180, 0);
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
