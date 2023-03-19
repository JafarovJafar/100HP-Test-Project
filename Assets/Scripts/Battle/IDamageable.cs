using System;

public interface IDamageable
{
    event Action<float> TakenDamage;
    
    void TakeDamage(float damage);
}