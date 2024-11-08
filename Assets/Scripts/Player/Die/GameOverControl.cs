using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour
{
    public void GameOver(Animator animator, float dieTime)
    {
        if (animator != null)
        {
            animator.SetTrigger("destroy");
            Destroy(gameObject, dieTime);
            StartCoroutine(LoadGameOverScene(dieTime));
        }
    }

    private IEnumerator LoadGameOverScene(float delay)
    {
        yield return new WaitForSeconds(delay - 0.1f);
        SceneManager.LoadScene(2);
    }
}
