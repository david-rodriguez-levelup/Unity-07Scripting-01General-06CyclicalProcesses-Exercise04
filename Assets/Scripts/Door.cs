using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{

    #region Fields/Variables

    // We have to inject this reference because would be more than one switcher per scene.
    [SerializeField]
    [Tooltip("Switcher this door is connected to.")]    
    private Switcher _switcher;

    private bool _isOpen;

    #endregion


    #region Lifecycle

    private void OnEnable()
    {
        if (_switcher != null)
        {
            _switcher.OnPressedActions += OnSwitcherPressed;
        }
    }

    private void Start()
    {
        _isOpen = false;
    }

    private void OnDisable()
    {
        if (_switcher != null)
        {
            _switcher.OnPressedActions -= OnSwitcherPressed;
        }
    }

    #endregion


    #region Own methods

    private void OnSwitcherPressed()
    {
        if (!_isOpen)
        {
            Open(true);
        }
    }

    private void Open(bool animateOpening)
    {
        _isOpen = true;
        if (animateOpening)
        {
            StartCoroutine(AnimateOpening());
        }
    }

    private IEnumerator AnimateOpening()
    {
        float finalPositionY = transform.position.y + 2.5f;
        float stepY = 1.75f;

        while (transform.position.y <= finalPositionY)
        {
            float newY = transform.position.y + (stepY * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }        
    }

    #endregion

}
