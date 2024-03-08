using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoardHandler : MonoBehaviour
{
    string url = "https://sid-restapi.onrender.com";

    private UsuarioJson Usuario;
    private string Token;

    public GameObject panelLeaderboard;
    public GameObject itemLeaderboardPrefab;

    private List<GameObject> LeaderboardItems;

    // Start is called before the first frame update
    void Start()
    {
        Token = PlayerPrefs.GetString("token");

        LeaderboardItems = new List<GameObject>();
    }

    public void ConsultarLeaderboard()
    {
        StartCoroutine("GetLeaderboard");
    }

    IEnumerator GetLeaderboard()
    {
        UnityWebRequest request = UnityWebRequest.Get(url + "/api/usuarios");
        Debug.Log("Sending Request GetLeaderboard");
        request.SetRequestHeader("x-token", Token);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                ListaUsuarios data = JsonUtility.FromJson<ListaUsuarios>(request.downloadHandler.text);

                var usuariosOrganizados = data.usuarios.OrderByDescending(user => user.data.score).Take(5).ToArray();
                ShowLeaderboard(usuariosOrganizados);
            }
            else
            {
                //Debug.Log(request.responseCode + "|" + request.error);
                Debug.Log("Usuario no autenticado");
            }
        }
    }

    void ShowLeaderboard(UsuarioJson[] usuarios)
    {
        panelLeaderboard.SetActive(true);
        LeaderboardItems.Clear();
        foreach(UsuarioJson usuario in usuarios) 
        {
            GameObject item = GameObject.Instantiate(itemLeaderboardPrefab, panelLeaderboard.transform) as GameObject;

            SetLeaderboardItem(item, usuario);
        }
    }

    public void HideLeaderboard() 
    {
        panelLeaderboard.SetActive(false);
    }

    void SetLeaderboardItem(GameObject item, UsuarioJson usuario)
    {
        LeaderboardItems.Add(item);

        //LeaderboardItem.SetItem(usuario, LeaderboardItems.Count);
    }
}
