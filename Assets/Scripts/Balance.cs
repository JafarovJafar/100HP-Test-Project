using System;

public class Balance : IBalance
{
    public event Action Updated;

    public float Money => _money;

    private float _money;

    public Balance(float money)
    {
        _money = money;
    }

    public void AddMoney(float value)
    {
        _money += value;
        Updated?.Invoke();
    }
}