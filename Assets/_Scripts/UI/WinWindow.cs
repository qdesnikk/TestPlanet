using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WinWindow : MonoBehaviour, IFinishable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void StartActionOnWin()
    {
        _animator.Play("Open");
    }

    public void StartActionOnLose()
    {
    }
}
