namespace Valenia.Verity.Contexts
{
    public interface IContextRepository
    {
        Context Load();
        void Add(Context entity);
    }
}
