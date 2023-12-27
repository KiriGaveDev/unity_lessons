using UnityEngine;


namespace Presenter
{
    public interface ICharacterInfoPresenter : IPresenter
    {
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
    }
}

