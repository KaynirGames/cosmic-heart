using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public static bool IsPause => Time.timeScale == 0;

    public static void Pause(bool enable)
    {
        Time.timeScale = enable ? 0 : 1;
    }

    public void TogglePause(bool enable)
    {
        Pause(enable);
    }
}
