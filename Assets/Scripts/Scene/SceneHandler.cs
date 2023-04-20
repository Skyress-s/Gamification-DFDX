using System.Threading.Tasks;
using UnityEngine.SceneManagement;

// Task<float> asyncFloat = SomeOtherOperation(); // asyncFloat.Start();
// Debug.Log("Test");
// Debug.Log(asyncFloat.Result);  // waits for result!
//
// SomevoidAsyncOperation(); // will pause program

public static class SceneHandler {

    public static string NewSceneName => _newSceneName;
    private static string _newSceneName = "";
    
    public static string PreviousSceneName => _previousSceneName;
    private static string _previousSceneName = "";
    
    public static void LoadSceneWithDefaultTransition(string sceneName) {
        _previousSceneName =  SceneManager.GetActiveScene().name;
        var handle = SceneManager.LoadSceneAsync("S_GenericSceneTransition", LoadSceneMode.Additive);
        handle.completed += operation => {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("S_GenericSceneTransition"));
            _newSceneName = sceneName;
        };
        // Debug.Log(activeScene.name);
        //
        // AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync("S_GenericSceneTransition");
        // loadSceneOperation.completed += operation => {
        //     
        // };
        //
        // AsyncOperation newSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        //
        // newSceneOperation.completed += operation => {
        //     
        // };

        // var a = waitLoad("awdawdl");
        // Task g = SomevoidAsyncOperation();
    }

    public static async Task<string> waitLoad(string str) {
        return str;
    }
    
    public static async Task SomevoidAsyncOperation() {
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