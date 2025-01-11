using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ������������
    public float jumpForce = 10f; // ���� ������
    private Rigidbody2D rb;
    private bool isGrounded = false; // ��������, �� ����� �� ��������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    void Update()
    {
        // �������� ���� �� ������
        float moveInput = Input.GetAxis("Horizontal");

        // ������� ��������� �� �����������
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // ������
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // ���� � �������, ������ ����������
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, �������� �� �������� �����
        if (collision.contacts.Length > 0 && collision.GetContact(0).normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}

