using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookaround : MonoBehaviour
{

    [SerializeField] private float cameraSensitivity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveInputDeadZone;

    private float halfScreenWidth;

    // Camera control
    private Vector2 lookInput;
    private float cameraPitch;

    private Vector2 moveTouchStartPosition;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        halfScreenWidth = Screen.width / 2;

        // calculate the movement input dead zone
        moveInputDeadZone = Mathf.Pow(Screen.height / moveInputDeadZone, 2);
    }

    // Update is called once per frame
    void Update()
    {
        GetTouchInput();
    }

    void GetTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if (t.position.x > halfScreenWidth && t.phase == TouchPhase.Moved)
            {
                lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
            }
            else
                lookInput = Vector2.zero;
        }
    }

    public float XLookInput()
    {

        return lookInput.x;
    }

    public float YLookInput()
    {
        return lookInput.y;
    }
}
