using UnityEngine;

public class Player : MonoBehaviour
{

    #region Fields/Properties

    [SerializeField]
    [Tooltip("Speed of the player (in units).")]
    private float _speed = 10;

    private Rigidbody _myRigidBody;

    #endregion


    #region Lifecycle

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (vertical != 0 || horizontal != 0)
        {
            _myRigidBody.AddForce(new Vector3(horizontal, 0, vertical) * _speed);
        }
    }

    #endregion

}
