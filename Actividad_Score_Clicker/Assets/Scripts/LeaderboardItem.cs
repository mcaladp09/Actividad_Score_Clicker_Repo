using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardItem : MonoBehaviour
{
    public string Username {  get; set; }

    public int Score { get; set; }

    public int Position { get; set; }

    public TMP_Text TextUsername;
    public TMP_Text TextScore;

    public void SetItem(UsuarioJson usuario, int pos) 
    {
        TextUsername.text = usuario.username;
        TextScore.text = "" + usuario.data.score;

        //transform.position = new Vector3(transform.position.x, 150 - (pos * 100), 0);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
