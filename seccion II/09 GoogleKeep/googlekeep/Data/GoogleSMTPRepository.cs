using googlekeep.Business.Contracts;
using googlekeep.Entity;

namespace googlekeep.Data
{
    public class GoogleSMTPRepository : GenericRepository<GoogleSMTP>, IGoogleSMTPRepository
    {
        public bool isValidCode(string email, int code)
        {
            var result = Session.QueryOver<GoogleSMTP>()
                .Where(src => src.code == code && src.email == email && src.isactive).List().FirstOrDefault();
            // verificamos si el lapso de tiempo es mayor a 5 minutos, si es asi el codigo no es valido
            if (result != null)
            {
                var timeDiff = DateTime.Now - result.created_at;
                if (timeDiff.TotalMinutes > 5)
                    return false;
                else
                {
                    result.isactive = false;
                    Update(result);
                    return true;
                }
            } else
                return false;
        }
    }
}
