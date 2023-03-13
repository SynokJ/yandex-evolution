using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public delegate void OnTouchEffected(Vector2 pos);
    public OnTouchEffected onTouchEffected = default;

    public delegate void OnDestinationalSetted(Vector2 pos);
    public OnDestinationalSetted onDestintaionalSetted = default;

    public delegate void OnDirectionSetted(Vector2 dir);
    public OnDirectionSetted onDirectionSetted = default;

    private Touch _firstTouch;

    void Update()
    {
        if (Input.touchCount > 0)
        {

            _firstTouch = Input.GetTouch(0);

            if (_firstTouch.phase == TouchPhase.Began)
                OnTouchBegun();
            else if (_firstTouch.phase == TouchPhase.Moved)
                OnTouchMoved();
        }
    }

    private void OnTouchBegun()
    {
        onTouchEffected?.Invoke(_firstTouch.position);
        onDestintaionalSetted?.Invoke(_firstTouch.position);
        onDirectionSetted?.Invoke(_firstTouch.position);
    }

    private void OnTouchMoved()
    {
        onDestintaionalSetted?.Invoke(_firstTouch.position);
        onDirectionSetted?.Invoke(_firstTouch.position);
    }
}
