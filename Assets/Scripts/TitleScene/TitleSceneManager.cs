using UnityEngine;

namespace Reversi.Scene
{
    public class TitleSceneManager : SceneManagerBase
    {
        [SerializeField]
        private TitleSceneController _titleSceneController = null;

        public override void Initialize(SceneArgBase argBase)
        {
            var arg = ConvertArg<TitleSceneArg>(argBase);
            Debug.Log(arg.TestString);

            _titleSceneController.Initialize();
        }
    }

    public class TitleSceneArg : SceneArgBase
    {
        public readonly string TestString;

        public TitleSceneArg(string testString)
        {
            TestString = testString;
        }
    }
}
