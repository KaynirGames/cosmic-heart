using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public event System.Action<Player> OnPlayerActive = delegate { };

    [SerializeField] private GameObjectRuntimeListSO _runtimePlayer = null;

    public Player Player { get; private set; }

    private BaseMoveInput _playerMovement;

    private void Start()
    {
        Player = _runtimePlayer.Get(0).GetComponent<Player>();
        _playerMovement = Player.GetComponent<BaseMoveInput>();
        OnPlayerActive.Invoke(Player);
    }

    public void TogglePlayerControls(bool enable)
    {
        Player.enabled = enable;
        _playerMovement.enabled = enable;
    }
}