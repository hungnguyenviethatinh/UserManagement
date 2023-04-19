namespace UserManagement.DAL
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
