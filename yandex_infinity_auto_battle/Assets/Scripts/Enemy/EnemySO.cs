using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy", fileName = "Enemy")]
public class EnemySO : ScriptableObject
{
    public int healthPoints;
    public int rewardPoints;
    public float attackDelay;
}