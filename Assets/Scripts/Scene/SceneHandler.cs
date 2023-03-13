using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

// Task<float> asyncFloat = SomeOtherOperation(); // asyncFloat.Start();
// Debug.Log("Test");
// Debug.Log(asyncFloat.Result);  // waits for result!
//
// SomevoidAsyncOperation(); // will pause program

public static class SceneHandler {
    public static void LoadSceneWithDefaultTransition(string sceneName) {
        Scene activeScene =  SceneManager.GetActiveScene();

        AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync("S_GenericSceneTransition");
        loadSceneOperation.completed += operation => {
            
        };
        
        AsyncOperation newSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        newSceneOperation.completed += operation => {
            SceneManager.UnloadSceneAsync(activeScene);
        };
    }

    public static async void SomevoidAsyncOperation() {
        await Task.Delay(10000);
    }
    public static async Task<float> SomeOtherOperation() {
        
        float someValue = await DoSomething(); // wait here unt
        return someValue;
    }

    public static async Task<float> DoSomething() {
        await Task.Delay(100);

        return 4f;
    }
}