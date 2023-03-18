using UnityEngine;
using Battle.Projectiles;

public class Projectile : MonoBehaviour, IPoolable
{
    [SerializeField] private Trail _trail;
    
    public bool IsActive => _gameObject.activeSelf;

    private GameObject _gameObject;
    private Transform _transform;
    
    public void Activate()
    {
        _trail.Activate();
    }

    public void DeActivate()
    {
        _trail.DeActivate();
    }

    public void SetPosition(Vector3 position) => _transform.position = position;
    public void SetRotation(Quaternion rotation) => _transform.rotation = rotation;
    
    private void Awake()
    {
        _gameObject = gameObject;
        _transform = transform;
    }
}