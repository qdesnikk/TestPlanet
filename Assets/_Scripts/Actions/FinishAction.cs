using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAction : MonoBehaviour
{
    [SerializeField] private List<GameObject> _finishableObjects;

    private float _sessionTime = 0f;

    private void Update()
    {
        _sessionTime += Time.deltaTime;
    }

    public void Activate(FinishType finishType = FinishType.None)
    {
        if (_finishableObjects.Count > 0)
        {
            switch (finishType)
            {
                case FinishType.Win:

                    foreach (var obj in _finishableObjects)
                    {
                        if (obj.TryGetComponent(out IFinishable finishable))
                            finishable.StartActionOnWin();
                    }

                    GAInstance.Instance.LevelCompleteEvent(SaveGame.Load(Keys.TotalLevel, 0), _sessionTime);
                    break;

                case FinishType.Lose:

                    foreach (var obj in _finishableObjects)
                    {
                        if (obj.TryGetComponent(out IFinishable finishable))
                            finishable.StartActionOnLose();
                    }

                    GAInstance.Instance.LevelFailEvent(SaveGame.Load(Keys.TotalLevel, 0), _sessionTime);
                    break;

                default:
                    break;
            }
        }
    }

    public enum FinishType
    {
        None,
        Win,
        Lose
    }
}