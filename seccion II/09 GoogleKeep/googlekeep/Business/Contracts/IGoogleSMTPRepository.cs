using googlekeep.Entity;

namespace googlekeep.Business.Contracts
{
    public interface IGoogleSMTPRepository: IGenericRepository<GoogleSMTP>
    {
        bool isValidCode(string email, int code);
    }
}
