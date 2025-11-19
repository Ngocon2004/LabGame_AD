using UnityEngine;

public class PlayerMovemet2 : MonoBehaviour
{
    // Gán CharacterController của nhân vật 2 trong Inspector
    public CharacterController controller;

    [Header("Cấu hình di chuyển")]
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    [Header("Kiểm tra chạm đất")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Kiểm tra nếu đang chạm đất để reset lại vận tốc rơi
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 🕹️ Lấy input từ phím mũi tên
        float x = Input.GetAxis("Horizontal2"); // Left/Right arrow
        float z = Input.GetAxis("Vertical2");   // Up/Down arrow

        // Di chuyển theo hướng của nhân vật
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // ⬆️ Nhảy bằng Right Ctrl
        if (Input.GetButtonDown("Jump2") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Áp dụng trọng lực
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
