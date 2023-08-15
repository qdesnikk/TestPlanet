using UnityEngine;
using UnityEngine.UI;
using Lofelt.NiceVibrations;
using System.Collections.Generic;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private float _openTime = 1f;
    [Header("Buttons")]
    [SerializeField] private Button _soundButton;
    [SerializeField] private Sprite _enabledSoundSprite;
    [SerializeField] private Sprite _disabledSoundSprite;
    [SerializeField] private Button _vibroButton;
    [SerializeField] private Sprite _enabledVibroSprite;
    [SerializeField] private Sprite _disabledVibroSprite;
    [SerializeField] private Button _langButton;
    [SerializeField] private Sprite _engLangSprite;
    [SerializeField] private Sprite _rusLangSprite;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _ppButton;
    [Space]
    [Header("Points")]
    [SerializeField] private List<Transform> _pointsForButtons;

    private bool _isOpen = false;
    private bool _volumeEnable = true;
    private bool _vibroEnable = true;
    private LanguageType _currentLanguage = LanguageType.English;


    public void SwitchSettingsMenu()
    {
        if (_isOpen == false)
        {
            _soundButton.transform.DOMove(_pointsForButtons[0].transform.position, _openTime);
            _vibroButton.transform.DOMove(_pointsForButtons[1].transform.position, _openTime);
            _langButton.transform.DOMove(_pointsForButtons[2].transform.position, _openTime);
            _ppButton.transform.DOMove(_pointsForButtons[3].transform.position, _openTime);
            _restartButton.transform.DOMove(_pointsForButtons[4].transform.position, _openTime);
        }
        else
        {
            _soundButton.transform.DOMove(transform.position, _openTime);
            _vibroButton.transform.DOMove(transform.position, _openTime);
            _langButton.transform.DOMove(transform.position, _openTime);
            _ppButton.transform.DOMove(transform.position, _openTime);
            _restartButton.transform.DOMove(transform.position, _openTime);
        }

        _isOpen = !_isOpen;
    }


    public void SwitchSound()
    {
        _volumeEnable = !_volumeEnable;

        if (_volumeEnable == false)
        {
            AudioListener.volume = 0f;
            _soundButton.image.sprite = _disabledSoundSprite;
        }
        else
        {
            AudioListener.volume = 1f;
            _soundButton.image.sprite = _enabledSoundSprite;
        }
    }

    public void SwitchVibro()
    {
        _vibroEnable = !_vibroEnable;

        if (_vibroEnable == false)
        {
            _vibroButton.image.sprite = _disabledVibroSprite;
            HapticController.hapticsEnabled = false;
        }
        else
        {
            _vibroButton.image.sprite = _enabledVibroSprite;
            HapticController.hapticsEnabled = true;
        }
    }

    public void SwitchLanguage()
    {
        string en = "English";
        string rus = "Russian";

        _currentLanguage++;

        int totalLangCount = System.Enum.GetNames(typeof(LanguageType)).Length;

        if ((int)_currentLanguage >= totalLangCount)
        {
            _currentLanguage = LanguageType.English;
        }

        //switch (_currentLanguage)
        //{
        //    case LanguageType.English:
        //        if (LocalizationManager.HasLanguage(en))
        //            LocalizationManager.CurrentLanguage = en;

        //        _langButton.image.sprite = _engLangSprite;
        //        break;
        //    case LanguageType.Russian:
        //        if (LocalizationManager.HasLanguage(rus))
        //            LocalizationManager.CurrentLanguage = rus;

        //        _langButton.image.sprite = _rusLangSprite;
        //        break;
        //    default:
        //        break;
        //}

    }

    public void ShowPolicy()
    {
        Application.OpenURL("https://ink-quokka-842.notion.site/Privacy-Policy-e2837eafdbe04769b7f913ebef507164");
    }

    private enum LanguageType
    {
        English,
        Russian
    }
}

