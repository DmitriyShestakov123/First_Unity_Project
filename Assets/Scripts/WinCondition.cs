using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    private int _crates = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(_crates == 4) {
            DataHolder.gameResult = 1;
            Debug.Log("win");
            SceneManager.LoadScene("MainMenu");
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("crate")) {
            _crates += 1;
        }
        Debug.Log("entered");
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("crate")) {
            _crates -= 1;
        }
        Debug.Log("exited");
    }
}
