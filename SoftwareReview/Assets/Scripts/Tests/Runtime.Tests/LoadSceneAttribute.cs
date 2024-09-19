using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LoadSceneAttribute : NUnitAttribute, IOuterUnityTestAction
{
    private string scene;
    
    public LoadSceneAttribute(string scene)
    {
        this.scene = scene;
    }
    
    public IEnumerator BeforeTest(ITest test)
    {
        Debug.Assert(scene.EndsWith(".unity"), "Scene must end with .unity");
        yield return EditorSceneManager.LoadSceneInPlayMode(scene, new LoadSceneParameters(LoadSceneMode.Single));
    }

    public IEnumerator AfterTest(ITest test)
    {
        yield return null;
    }
}