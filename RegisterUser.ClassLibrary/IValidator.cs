namespace RegisterUser.ClassLibrary
{
    public interface IValidator<T> where T : class
    {
        void Validate(T entity);
    }
}