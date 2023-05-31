using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _endsArray;
    [SerializeField]
    private PlayerStats _playerStats;

    private bool close = false;

    private void Update()
    {
        if (close && !_playerStats.InDialogue)
        {
            Application.Quit();
        }
    }

    public void Finish(int end)
    {
        _endsArray[end].SetActive(true);
    }

    private IEnumerator finishDialog()
    {
        yield return new WaitForSeconds(3);
        close = true;
    }
}
