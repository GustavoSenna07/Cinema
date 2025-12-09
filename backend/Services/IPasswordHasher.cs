namespace backend.Services
{
    public interface IPasswordHasher
    {
        string HashSenha(string senha);
    }
}
