using Emilia.StateMachine;
using Spine.Unity;
using UnityEngine;

namespace Emilia.SpineAnimator
{
    [RequireComponent(typeof(SkeletonAnimation))]
    public class SpineAnimatorMono : MonoBehaviour
    {
        public const string EditorPath = "Assets/Emilia/SpineAnimator/Resource/Asset";

        public string fileName;

        private SkeletonAnimation _skeletonAnimation;

        private IStateMachineRunner runner;

        public SkeletonAnimation skeletonAnimation => _skeletonAnimation;

        private void Awake()
        {
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(fileName)) return;

            StateMachineLoader stateMachineLoader = new StateMachineLoader();
            stateMachineLoader.editorFilePath = EditorPath;

            runner = StateMachineRunnerUtility.CreateRunner();
            runner.Init(this.fileName, stateMachineLoader, skeletonAnimation);
            this.runner.Start();
        }

        private void Update()
        {
            this.runner?.Update();
        }

        private void OnDisable()
        {
            this.runner?.Dispose();
            runner = null;
        }
    }
}