using System;

public interface IBalance
{
    event Action Updated;
    
    float Money { get; }

    void AddMoney(float value);
}