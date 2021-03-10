using UnityEngine;

public class ActionInputTouch : MonoBehaviour, IActionInputHandler
{
    [SerializeField] private int _touchID = 0;

    public bool GetInputDown()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(_touchID);

            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }

        return false;
    }

    public bool GetInputHold()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(_touchID);

            switch (touch.phase)
            {
                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    return true;
            }
        }

        return false;
    }

    public bool GetInputUp()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(_touchID);

            if (touch.phase == TouchPhase.Ended)
            {
                return true;
            }
        }

        return false;
    }
}
