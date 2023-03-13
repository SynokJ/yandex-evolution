using UnityEngine;

public class LevelKeeper : MonoBehaviour
{
    [Header("Level SO:")]
    [SerializeField] private System.Collections.Generic.List<LevelSO> levels = new System.Collections.Generic.List<LevelSO>();

    private int _levelId = 0;

    public static LevelKeeper instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public LevelSO GetLevel()
    {
        return levels[_levelId];
    }
}
