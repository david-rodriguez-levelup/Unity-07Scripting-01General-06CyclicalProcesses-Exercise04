using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    #region Fields/Properties

    /// <summary>
    /// Is the game over?
    /// </summary>
    public bool IsGameOver { get; private set; }

    private EndPoint _endPoint;

    #endregion


    #region Lifecycle

    private void Awake()
    {
        // We can do this because there is only one EndPoint object per scene!
        _endPoint = FindObjectOfType<EndPoint>();
    }

    private void OnEnable()
    {
        _endPoint.OnReachedActions += OnEndPointReached;
    }

    private void OnDisable()
    {
        _endPoint.OnReachedActions -= OnEndPointReached;
    }

    #endregion


    #region Own methods

    private void OnEndPointReached()
    {
        if (!IsGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        IsGameOver = true;
        SceneManager.LoadScene("GameOver");
    }

    #endregion

}
