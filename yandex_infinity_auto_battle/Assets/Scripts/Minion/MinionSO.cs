using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Minion", fileName = "Minion")]
public class MinionSO : ScriptableObject
{
    public int healthPoints;
    public int damagePoints;
    public int attackSpeed;
}