using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private bool running = false;

    [SerializeField] private GameObject commandwin;
    [SerializeField] private GameObject Player;

    playerMove script;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        script = Player.GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isRunning()
    {
        return running;
    }

    public void switchRun(bool enabled)
    {
        running = enabled;
    }
}
