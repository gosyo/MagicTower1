using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float _maxHealth;
    float _health;

    public Slider _healthSlider;
    public float _changeHealthInterval = 0.5f;
    private void Start()
    {
        _health = _maxHealth;
        _healthSlider = GetComponentInChildren<Slider>();
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.value = _maxHealth;        
    }

    private void Update()
    {
        //if (_healthSlider)
        //{
        //    _healthSlider.value = _health / _maxHealth;
        //    //Debug.Log(_health);
        //}

    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        ChangeValue(_health);
        if (_health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Gamemanager.S.GameOver();
        Destroy(gameObject);
    }

    void ChangeValue(float value)
    {
        // DOTween.To() を使って連続的に変化させる
        DOTween.To(() => _healthSlider.value, // 連続的に変化させる対象の値
            x => _healthSlider.value = x, // 変化させた値 x をどう処理するかを書く
            value, // x をどの値まで変化させるか指示する
            _changeHealthInterval);   // 何秒かけて変化させるか指示する
    }
}
