using UnityEngine;

public class CollectableMove : MonoBehaviour
{

    private const float _RADIUS_TO_SPAWN = 8.0f;

    [Header("Take Components:")]
    [SerializeField] private CollectableTake _take;

    private void Start()
    {
        _take.onPositionChanged = OnPositionGhanged;
    }

    public  void OnPositionGhanged()
    {
        float posX = Random.Range(-_RADIUS_TO_SPAWN, _RADIUS_TO_SPAWN);
        float posY = Random.Range(-_RADIUS_TO_SPAWN, _RADIUS_TO_SPAWN);
        transform.position = new Vector2(posX, posY);
    }
}
