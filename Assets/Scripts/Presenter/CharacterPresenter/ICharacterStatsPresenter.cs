using Character;
using System;
using System.Collections.Generic;


namespace Presenter.CharacterPresenter
{
    public interface ICharacterStatsPresenter : IPresenter
    {
        public HashSet<CharacterStat> CharacterStats { get; }
        event Action OnLevelUp;
    }

}
