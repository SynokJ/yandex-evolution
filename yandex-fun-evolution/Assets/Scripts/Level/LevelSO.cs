using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Level", fileName = "Level")]
public class LevelSO : ScriptableObject
{
    public CollectableSO collectable;
    public PlayerSO player;

}
