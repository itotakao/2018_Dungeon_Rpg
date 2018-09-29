using UnityEngine;

namespace Ito
{
    public class MainSystem : MonoBehaviour
    {
        public TitleScene TitleScene { get { return TitleScene.Current; }}

        StateMachine stateMachine;

        [SerializeField]
        GameObject[] sceneList = null;

        void Awake()
        {
            foreach(var scene in sceneList){ scene.SetActive(true); }
        }

        void Start()
        {
            Settings.Load();

            stateMachine = new StateMachine();
            stateMachine.Start();

            TitleScene.Show(true);
        }

        void Update()
        {
            stateMachine.Update();
        }

        void LateUpdate()
        {
            stateMachine.LateUpdate();
        }
    }
}