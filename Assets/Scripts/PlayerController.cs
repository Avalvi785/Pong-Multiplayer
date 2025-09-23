using Fusion;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float Speed = 5f;

    public float TargetY { get; set; }


    private void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TargetY = worldPos.y;
        }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
           targetY = worldPos.y;d
        }
#endif

    }

    public override void FixedUpdateNetwork()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, TargetY, Speed * Runner.DeltaTime);
        transform.position = pos;
    }
}



