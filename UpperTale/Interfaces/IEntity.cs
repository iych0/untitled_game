using Something.Managers;

namespace Something.Interfaces;

public interface IEntity
{
    private void SelfDestruct(IEntity entity) =>
        GameManager.AnnihilateEntity(entity);
}