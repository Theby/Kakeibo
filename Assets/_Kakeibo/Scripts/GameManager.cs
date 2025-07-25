using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KakeiboManager kakeiboManager;
    [SerializeField] private CanvasManager canvasManager;

    public static KakeiboManager KakeiboManager { get; private set; }
    public static CanvasManager CanvasManager { get; private set; }

    SQLController _sqlController;

    void Awake()
    {
        _sqlController = new SQLController();
        KakeiboManager = kakeiboManager;
        CanvasManager = canvasManager;

        _sqlController.Initialize();
        kakeiboManager.Initialize(_sqlController);
        canvasManager.Initialize();
    }

    void OnDestroy()
    {
        _sqlController.Clear();
    }
}