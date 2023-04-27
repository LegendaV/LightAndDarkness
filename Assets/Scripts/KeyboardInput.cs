using UnityEngine;

public class InputData
{
    public readonly Vector2 Direction;
    public readonly bool Jump;
    public readonly bool Dash;

    public InputData(Vector2 direction, bool jump, bool dash)
    {
        Direction = direction;
        Jump = jump;
        Dash = dash;
    }
}

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    void Update()
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        var jump = Input.GetKey(KeyCode.Space);
        var isDash = Input.GetKeyDown(KeyCode.E);

        _playerMovement.SetDirection(new InputData(new Vector2(directionX, directionY), jump, isDash));
    }
}
