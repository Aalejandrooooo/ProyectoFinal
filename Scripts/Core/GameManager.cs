using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Mental State")]
    public int obedience = 50;
    public int doubt = 0;
    public int stability = 100;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ModifyMentalState(int obedienceDelta, int doubtDelta, int stabilityDelta)
    {
        obedience += obedienceDelta;
        doubt += doubtDelta;
        stability += stabilityDelta;
    }
}
