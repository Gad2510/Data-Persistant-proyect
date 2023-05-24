using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button btn_startGame, btn_quitApp;
    [SerializeField]
    private TMPro.TMP_InputField in_name;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.gm_instance != null)
        {
            btn_startGame.onClick.AddListener(() => {
                GameManager.gm_instance.LoadGame();
            });
            in_name.onValueChanged.AddListener((x) => { GameManager.gm_instance.str_plName = x; });
        }
        
        btn_quitApp.onClick.AddListener(()=> { Application.Quit(); });
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
