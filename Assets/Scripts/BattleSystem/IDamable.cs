using UnityEngine;

public interface IDamable {
    public int MaxHealth { get; set; }
    public void GetDamage(ref int health, int damage) {
        health = Mathf.Clamp(health - damage, 0, MaxHealth);
    }
}