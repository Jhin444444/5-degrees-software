using UnityEngine;
using Fusion;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Проверяем, что у нас есть право на управление этим объектом
        if (Object.HasInputAuthority)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        // Чтение входных данных (например, от клавиатуры или контроллера)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * 5f;
        _rigidbody2D.linearVelocity = movement; // Двигаем игрока
    }
}