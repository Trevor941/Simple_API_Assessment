using Simple_API_Assessment.Models;
using System.Threading.Tasks;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        Task<List<Applicant>> GetApplicants();
        Task<Applicant> AddApplicant(Applicant applicant);
        Task<Applicant> GetSingleApplicant(int Id);
        Task<Applicant> EditApplicant(Applicant applicant, int Id);
        Task<string> DeleteApplicant(int Id);

    }
}
