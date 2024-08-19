using Cinemachine;
using TMPro;
using UnityEngine;

public class FPSGameManager : MonoBehaviour
{
    public static FPSGameManager instance;

    public GameObject finishScreen, gameOverScreen, playerUI, gun, fpsCam;
    public TextMeshProUGUI remainEnemy;
    public int enemiesCount;

    private void Awake()
    {
        instance = this;
    }
    public void EnemyCountIncrease()
    {
        enemiesCount++;
        remainEnemy.text = enemiesCount.ToString();
    }
    private void OnEnable()
    {
        HealthPlayer.GameOver += HealthPlayer_GameOver;
        EnemiesHealth.EnemyDied += EnemiesHealth_ChangeCount;
    }

    private void OnDisable()
    {
        HealthPlayer.GameOver -= HealthPlayer_GameOver;
        EnemiesHealth.EnemyDied -= EnemiesHealth_ChangeCount;
    }

    private void EnemiesHealth_ChangeCount()
    {
        enemiesCount--;
        remainEnemy.text = enemiesCount.ToString();
        if (enemiesCount == 0)
        {
            fpsCam.GetComponent<CinemachineInputProvider>().enabled = false;
            gun.SetActive(false);
            playerUI.SetActive(false);
            finishScreen.SetActive(true);
            InputsHandler.Instance.SetInputs(false);
        }
    }

    private void HealthPlayer_GameOver()
    {
        fpsCam.GetComponent<CinemachineInputProvider>().enabled = false;
        gun.SetActive(false);
        playerUI.SetActive(false);
        gameOverScreen.SetActive(true);
        InputsHandler.Instance.SetInputs(false);
    }

}
