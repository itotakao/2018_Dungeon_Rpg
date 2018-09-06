using UnityEngine;
namespace Ito
{
    public class MainSystem : MonoBehaviour
    {
        public TitleUI TitleUI { get { return TitleUI.Current; }}
        public GameUI GameUI{ get { return GameUI.Current; }}

        StateMachine stateMachine;

        void Start()
        {
            Settings.Load();

            stateMachine = new StateMachine();
            stateMachine.Start();

            TitleUI.Show(false);
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