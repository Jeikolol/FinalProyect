namespace BankingProject.Helpers
{
    public class ValidarPassword
    {
        public static bool Validar(string password, string loginPassword)
        {
            if (password == loginPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
