using UnityEngine;

namespace Ito
{
    public class MainSystem : MonoBehaviour
    {
        public TitleUI TitleUI { get { return TitleUI.Current; }}
        public GameUI GameUI{ get { return GameUI.Current; }}

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

            TitleUI.Show(true);
            GameUI.Show(false);
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