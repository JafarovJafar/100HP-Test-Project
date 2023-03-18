using System;
using Battle;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public event Action<Enemy> Entered;

    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private float _radius;

    private GameObject _gameObject;

    public void Init()
    {
        _gameObject = gameObject;

        _collider.radius = _radius;
        _spriteTransform.localScale = Vector2.one * _radius;
    }

    public void Activate() => _gameObject.SetActive(true);
    public void DeActivate() => _gameObject.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy)) Entered?.Invoke(enemy);
        else Debug.Log("этой коллизии не должно быть");
    }
}