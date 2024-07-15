using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    #region Biến nguồn nhạc cho homeview
    public AudioSource audioSource;
    public AudioClip clip;
    public Button button;
    #endregion

    #region Khởi tạo nguồn nhạc
    private void Awake()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume *= 0.5f;
        button.onClick.AddListener(PlaySound);
    }
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
    #endregion

    #region Trễ thời gian để nhạc chạy rồi mới load Scene mới
    public void Play()
    {
        PlaySound();
        StartCoroutine(LoadSceneWithDelay());
        
    }
    private IEnumerator LoadSceneWithDelay()
    {
        // đợi thời gian bằng thời lượng âm thanh mới bắt đầu tải cảnh mới
        yield return new WaitForSeconds(clip.length);
        
        SceneManager.LoadScene(SceneData.gameplay);
    }
    #endregion
}
