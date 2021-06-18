using UnityEditor;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public IntVariableSO playerMoney = null;

    public static Cheats Instance;

    private void Awake()
    {
        Instance = this;
    }

    [MenuItem("Cheats/Add Money")]
    private static void AddGold()
    {
        //Instance.playerMoney.ApplyChange(1000);
    }
}
