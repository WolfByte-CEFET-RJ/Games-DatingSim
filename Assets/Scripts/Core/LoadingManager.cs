using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public bool isLoading = false;
    public float loadProgress = 0;

    private Animator animator;

    public static LoadingManager Instance;

    private void Awake() {
        Instance = this;

        animator = GetComponentInChildren<Animator>();
        animator.gameObject.SetActive(false);

        DontDestroyOnLoad(gameObject);
    }

    public void NextScene (int index) {
        if (!isLoading) {
            isLoading = true;
            loadProgress = 0f;
            Time.timeScale = 0f;

            //play animação
            animator.gameObject.SetActive(true);
            animator.Play("Transicao");

            //Carrega nova cena
            StartCoroutine(LoadScene(index));
        }
    }

    IEnumerator LoadScene (int index) {
        yield return null;
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        //Enquanto não terminar de carregar a cena
        while(!operation.isDone) {
            loadProgress = operation.progress;

            if(operation.progress.Equals(.9f)) {
                operation.allowSceneActivation = true;
            }

            yield return new WaitForEndOfFrame();
        }

        //Espera tempo da primeira transição
        yield return new WaitForSecondsRealtime(1f);

        //Terminou de carregar

        Time.timeScale = 1f;
        isLoading = false;
        loadProgress = 0f;

        //Finaliza animação
        animator.Play("TransicaoEnd");

        //Esconde transição
        yield return new WaitForSeconds(1f);
        animator.gameObject.SetActive(false);
    }

    public int CurrentScene () {
        return SceneManager.GetActiveScene().buildIndex;
    }


}
