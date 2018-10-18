namespace RegisterUser
{
    internal interface IValidator<T> where T : class
    {
        void Validate(T entity);
    }
}