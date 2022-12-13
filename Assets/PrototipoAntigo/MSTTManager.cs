using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MSTTManager : MonoBehaviour
{
    private string s = "";
    public string resposta = "";
    public TMPro.TextMeshProUGUI textDisplay;
    //public TMPro.TextMeshProUGUI roundDisplay;
    
    public AudioSource somFino;
    public AudioSource somGrosso;
    public Button soundButton;

    
    // Update is called once per frame
    void Update()
    {
        textDisplay.text = resposta;

    }

    public string RandomString(){
        char[] chars = new char[2] { 'O', 'I' };
        string t = "";
        for(int i = 0; i < 4; i++){
            t += chars[Random.Range(0, 2)];
        }
        return t;
    }

    public void OButton(){
        resposta += 'O';
    }

    public void IButton(){
        resposta += 'I';
    }

    public void Confirma(){

        if(resposta.Equals(s)){
            Debug.Log("Acertou");
            //PlayerPrefs.SetInt("Pontos", PlayerPrefs.GetInt("Pontos") + 1);
            SceneManager.LoadScene("SampleScene");
        }
        else{
            Debug.Log("Errou");
        }

        //PlayerPrefs.SetInt("Round", PlayerPrefs.GetInt("Round") + 1);

        // if(PlayerPrefs.GetInt("Round") > 20){
        //     SceneManager.LoadScene("Resultado");
        // }
        // else{
        //     SceneManager.LoadScene("MSTT");
        // }
    }

    public void Cancela(){
        resposta = "";
    }

    public void PlaySound(){
        s = PlayerPrefs.GetString("sequence");
        Debug.Log(s);
        StartCoroutine(PlaySoundCoroutine());
    }    

    IEnumerator PlaySoundCoroutine(){

        for (int i = 0; i < s.Length; i++){

            if(s[i] == 'I'){
                somFino.Play();
            }
            else{
                somGrosso.Play();
            }

            yield return new WaitForSeconds(0.682f);
        }

    }

    public void CloseButton(){
        this.transform.parent.gameObject.SetActive(false);
    }


}
