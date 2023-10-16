using UnityEngine;

public class TankView : MonoBehaviour
{
    TankType tankType;
    TankController tankController;
    float horizontalMove;
    float verticalMove;
    [SerializeField] Rigidbody rb;
    [SerializeField] FixedJoystick joystick;
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public void SetJoystick(FixedJoystick _joystick)
    {
        joystick = _joystick;
    }
    public void SetTankType(TankType _tankType)
    {
        tankType = _tankType;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    void PlayerInput()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
    }
    void Update()
    {
        if (tankType == TankType.Player)
        {
            PlayerInput();
            if (horizontalMove != 0 || verticalMove != 0)
            {
                tankController.MoveTank(horizontalMove, verticalMove);
            }
        }
    }
}