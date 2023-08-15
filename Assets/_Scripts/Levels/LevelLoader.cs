using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private int _levelForLoad;

    private int _currentLevel;
    private int _totalLevel;

    private void Start()
    {
#if UNITY_EDITOR

        SetLevel();
#endif
        //if (PlayerPrefs.HasKey("CurrentLevel") == false)
        //{
        //    _currentLevel = 0;
        //    PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
        //    PlayerPrefs.SetInt("TotalLevel", _currentLevel + 1);
        //}
        //else
        //{
        //PlayerPrefs.GetInt("CurrentLevel");
        //}

        _currentLevel = SaveGame.Load(Keys.CurrentLevel, 0);
        _totalLevel = SaveGame.Load(Keys.TotalLevel, 0);

        LoadLevel();
    }

    private void LoadLevel()
    {
        if (_levels.Count > 0)
        {
            foreach (var level in _levels)
                level.gameObject.SetActive(false);

            _levels[_currentLevel].gameObject.SetActive(true);

            GAInstance.Instance.LevelStartedEvent(_currentLevel, _totalLevel);
        }

        Time.timeScale = 1;
    }

    private void SetLevel()
    {
        if (_levelForLoad != 0)
            SaveGame.Save(Keys.CurrentLevel, _levelForLoad - 1);

        //PlayerPrefs.SetInt("CurrentLevel", _levelForLoad - 1);
    }

    public void LoadNextLevel()
    {
        _currentLevel++;
        _totalLevel++;

        if (_levels.Count <= _currentLevel)
            _currentLevel = 0;

        SaveGame.Save(Keys.TotalLevel, _totalLevel);
        SaveGame.Save(Keys.CurrentLevel, _currentLevel);

        //PlayerPrefs.SetInt("TotalLevel", PlayerPrefs.GetInt("TotalLevel") + 1);
        //PlayerPrefs.SetInt("CurrentLevel", _currentLevel);

        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
