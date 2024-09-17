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
        // DOTween.To() ��ʹ�ä��B�A�Ĥˉ仯������
        DOTween.To(() => _healthSlider.value, // �B�A�Ĥˉ仯�����댝��΂�
            x => _healthSlider.value = x, // �仯�������� x ��ɤ��I���뤫�����
            value, // x ��ɤ΂��ޤǉ仯�����뤫ָʾ����
            _changeHealthInterval);   // ���뤫���Ɖ仯�����뤫ָʾ����
    }
}
