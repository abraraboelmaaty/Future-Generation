namespace FutureGeneration.Repository
{
    public interface IRepositoryAssignStudent<T>
    {
        public int Create(T obj);
    }
}
