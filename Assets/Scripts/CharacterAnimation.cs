using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _idle;
    private float _run;

    public void SetIdleState()
    {
        _idle = 0;
        _animator.SetFloat("Speed", _idle);
    }

    public void SetRunState()
    {
        _run = 1;
        _animator.SetFloat("Speed", _run);
    }
}
