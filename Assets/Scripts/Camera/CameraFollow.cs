using UnityEngine;
using System.Collections;

//Basic camera follow script.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 0.25f;

    public Vector2 offset;

    //LateUpdate ensures camera moves within the same from as the target
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z), followSpeed);
    }
}
