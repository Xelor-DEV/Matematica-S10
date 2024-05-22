using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerController : MonoBehaviour
{
    public static GameManagerController Instance {get; private set;}
    [SerializeField] private string scene;
    [SerializeField] private int enemiesToEliminate;
    [SerializeField] private int enemiesEliminated;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void UpdateEnemiesEliminated()
    {
        enemiesEliminated = enemiesEliminated + 1;
        if (enemiesEliminated >= enemiesToEliminate)
        {
            ChangeScene(scene);
        }
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
