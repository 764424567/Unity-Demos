using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int MaxHp = 20;
    public int CurrentHp = 20;
    public bool invulnerable;//无敌
    public delegate void OnHealthChange(float percentage, GameObject GO);
    public static event OnHealthChange onHealthChange;

    void Start()
    {
        SendUpdateEvent();
    }

    // 减血
    public void SubstractHealth(int damage)
    {
        if (!invulnerable)
        {
            // 极少血量
            CurrentHp = Mathf.Clamp(CurrentHp -= damage, 0, MaxHp);

            // 血量到达0
            if (isDead()) gameObject.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
        }

        // 血量更新
        SendUpdateEvent();
    }

    // 加血
    public void AddHealth(int amount)
    {
        CurrentHp = Mathf.Clamp(CurrentHp += amount, 0, MaxHp);
        SendUpdateEvent();
    }

    // 血量更新
    void SendUpdateEvent()
    {
        float CurrentHealthPercentage = 1f / MaxHp * CurrentHp;
        if (onHealthChange != null) onHealthChange(CurrentHealthPercentage, gameObject);
    }

    // 死亡
    bool isDead()
    {
        return CurrentHp == 0;
    }
}
