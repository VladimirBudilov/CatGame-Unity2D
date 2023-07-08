using UnityEngine;

public class ParallaxBehavior : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _lockVertical;
    Vector3 trargetPrevPos;

    private void Start()
    {
        if (Camera.main != null) _target = Camera.main.transform;
        trargetPrevPos = _target.position;
    }

    private void LateUpdate()
    {
        var delta = _target.position - trargetPrevPos;
        if(_lockVertical)
            delta.y = 0;
        trargetPrevPos = _target.position;
        transform.position += delta * _speed;
    }
}
