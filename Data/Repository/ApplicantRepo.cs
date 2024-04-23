using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;
using System;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {

        public readonly DataContext _dbContext;

        public ApplicantRepo(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Applicant>> GetApplicants()
        {

            List<Applicant> applicants = new List<Applicant>();
            applicants = await _dbContext.Applicants.Include(x => x.Skills).ToListAsync();
            return applicants;


        }

        public async Task<Applicant> AddApplicant(Applicant applicant)
        {
                 _dbContext.Add(applicant);
                 await _dbContext.SaveChangesAsync();
                 return applicant;
            
        }

        public async Task<Applicant> GetSingleApplicant(int Id)
        {
            var applicant = await _dbContext.Applicants.Include(x => x.Skills).Where(x => x.Id == Id).FirstOrDefaultAsync();
            return applicant;

        }


        public async Task<Applicant> EditApplicant(Applicant applicant, int Id)
        {
            //var applicant = await GetSingleApplicant(Id);
            _dbContext.Update(applicant);
            await _dbContext.SaveChangesAsync();
           var updatedrow = await GetSingleApplicant(Id);
            return updatedrow;

        }

        public async Task<string> DeleteApplicant(int Id)
        {

            var applicant = await GetSingleApplicant(Id);
            if(applicant == null)
            {
                return "not found";
            }
            _dbContext.Remove(applicant);
            await _dbContext.SaveChangesAsync();
            return "item deleted successfully";
        }

    }
}
