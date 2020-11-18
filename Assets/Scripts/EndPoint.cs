using UnityEngine;

public class EndPoint : MonoBehaviour
{
    /// <summary>
    /// Delegate signature for "Reached" event.
    /// </summary>
    public delegate void ReachedAction();

    #region Fields/Properties

    /// <summary>
    /// Delegates subscribed to "Reached" event.
    /// </summary>
    public event ReachedAction OnReachedActions;

    #endregion


    #region Lifecycle

    private void OnTriggerEnter()
    {
        OnReached();
    }

    #endregion


    #region Own methods

    private void OnReached()
    {
        OnReachedActions?.Invoke();
    }

    #endregion

}
