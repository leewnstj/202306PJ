using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private TextMeshProUGUI _modeText;
    private Image _ballImage;
    private Image _gunImage;

    private TextMeshProUGUI _bulletText;
    private TextMeshProUGUI _hpText;

    private void Awake()
    {
        if (Instance != null) Debug.LogError("UIManager!!!!!");
        Instance = this;

        _modeText = transform.Find("Mode/CurrentMode").GetComponent<TextMeshProUGUI>();
        _ballImage = transform.Find("Mode/Player/PlayerWalk").GetComponent<Image>();
        _gunImage = transform.Find("Gun/Gun").GetComponent<Image>();
        _bulletText = transform.Find("Gun/Bullet").GetComponent<TextMeshProUGUI>();
        _hpText = transform.Find("Hp/HP").GetComponent <TextMeshProUGUI>();
    }

    public void ModeChange(string str, bool value)
    {
        if(value)
        {
            _ballImage.enabled = false;
        }
        else
        {
            _ballImage.enabled = true;
        }
        _modeText.SetText(str);
    }

    public void BulletUI(float currentBullet, float maxBullet)
    {
        _bulletText.SetText($"{currentBullet} / {maxBullet}");
    }

    public void HealthUI(float currentHealth, float maxHealth)
    {
        _hpText.SetText($"{currentHealth} / {maxHealth}");
    }
}
