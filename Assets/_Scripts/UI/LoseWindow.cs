using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LoseWindow : MonoBehaviour, IFinishable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartActionOnLose()
    {
        _animator.Play("Open");
    }

    public void StartActionOnWin()
    {
    }
}
