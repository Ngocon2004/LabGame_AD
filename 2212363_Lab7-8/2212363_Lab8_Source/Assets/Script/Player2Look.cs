using UnityEngine;

public class Player2Look : MonoBehaviour
{
    public float turnSpeed = 180f;
    void Update()
    {
        float turn = Input.GetAxisRaw("Horizontal2"); // left/right arrow
        transform.Rotate(0f, turn * turnSpeed * Time.deltaTime, 0f);
    }
}
