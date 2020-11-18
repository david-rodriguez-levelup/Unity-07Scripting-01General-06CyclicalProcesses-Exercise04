using UnityEngine;

public class Switcher : MonoBehaviour
{

    /// <summary>
    /// Delegate signature for "Pressed" event.
    /// </summary>
    public delegate void PressedAction();

    #region Fields/Properties

    /// <summary>
    /// Delegates subscribed to "Pressed" event.
    /// </summary>
    public event PressedAction OnPressedActions;

    private bool _isPressed;

    #endregion


    #region Lifecycle

    private void Start()
    {
        _isPressed = false;
    }

    private void OnTriggerEnter()
    {
        if (!_isPressed)
        {
            Press();
        }
    }

    #endregion

    #region Own methods

    private void Press()
    {
        _isPressed = true;
        OnPressed();
        transform.position += Vector3.down * 0.25f;
    }

    private void OnPressed()
    {
        OnPressedActions?.Invoke();
    }

    #endregion

}
