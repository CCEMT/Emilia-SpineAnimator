using System;
using Emilia.StateMachine;
using Sirenix.OdinInspector;

namespace Emilia.SpineAnimator
{
    [StateMachineTitle("播放动画"), Serializable]
    public class PlayAnimationComponentAsset : SpineAnimatorComponentAsset<PlayAnimationComponent>
    {
        [LabelText("动画名称"), SpineAnimationNameSelector]
        public string animationName;

        [LabelText("轨道")]
        public int trackIndex;

        [LabelText("是否循环")]
        public bool isLoop;
    }

    public class PlayAnimationComponent : SpineAnimatorComponent<PlayAnimationComponentAsset>
    {
        public override void Enter(StateMachine.StateMachine stateMachine)
        {
            base.Enter(stateMachine);
            this.skeletonAnimation.AnimationState.SetAnimation(this.asset.trackIndex, this.asset.animationName, this.asset.isLoop);
        }
    }
}