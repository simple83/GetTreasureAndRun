using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    
    public PlayerController playerObject;

    public void GameStartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void GameExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터 모드에서는 에디터를 종료
#else
        Application.Quit(); // 빌드된 게임에서는 게임을 종료
#endif
    }

    public void SettingsBtn()
    {

    }

    public void JumpBtn()
    {
        if (playerObject != null)
        {
            playerObject.Jump();
        }
        else
        {
            Debug.Log("플레이어 오브젝트가 NULL입니다.");
        }
    }

    public void SlideBtnDown()
    {
        if (playerObject != null)
        { 
            playerObject.SlideDown();
        }
        else
        {
            Debug.Log("플레이어 오브젝트가 NULL입니다.");
        }
    }

    public void SlideBtnUp()
    {
        if (playerObject != null)
        {
            playerObject.SlideUp();
        }
        else
        {
            Debug.Log("플레이어 오브젝트가 NULL입니다.");
        }
    }
}
