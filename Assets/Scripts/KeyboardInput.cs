using UnityEngine;


public struct InputData
{
    public Vector2 Direction;
    public bool IsJump;
    public bool IsDash;

    public InputData(Vector2 direction, bool isJump, bool isDash)
    {
        Direction = direction;
        IsJump = isJump;
        IsDash = isDash;
    }   
}


public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    void Update()
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        var isJump = Input.GetKeyDown(KeyCode.C);
        var isDash = Input.GetKeyDown(KeyCode.X);

        var inputData = new InputData(new Vector2(directionX, directionY), isJump, isDash);

        _movement.PutInput(inputData);
    }
}
