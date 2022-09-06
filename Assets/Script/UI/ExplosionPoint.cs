using UnityEngine;
using UnityEngine.UI;

public class ExplosionPoint : MonoBehaviour
{
    private Slider _slider;
    private PlayerExplosionPoint _playerExplosionPoint;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _playerExplosionPoint = GameObject.FindWithTag("Player").GetComponent<PlayerExplosionPoint>();
    }

    private void Update()
    {
        _slider.value = (float)_playerExplosionPoint.ExplosionPoint / PlayerExplosionPoint.MaxExplosionPoint;
    }
}
