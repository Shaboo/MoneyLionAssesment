using Microsoft.AspNetCore.Http;
using MoneyLionAssesment.Models;
using MoneyLionAssesment.Repository;
using System.Linq;

namespace MoneyLionAssesment.Data
{
    public class SqlFeatureRepo : IFeatureRepository
    {
        private readonly DatabaseContext dbContext;

        public SqlFeatureRepo(DatabaseContext databaseContext)
        {
            dbContext = databaseContext;
        }

        public void CreateFeature(Feature feature)
        {
            if (dbContext.Features.Any(f => f.Name == feature.Name))
            {
                throw new BadHttpRequestException("Feature already exists");
            }

            dbContext.Features.Add(feature);
        }

        public Feature GetFeatureByEmailAndName(string email, string name)
        {
            return dbContext.Features.FirstOrDefault(f => f.Name == name && f.Users.Any(u => u.Email == email));
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }

        public bool UpdateFeatureAccess(string email, string featureName, bool enable)
        {
            try
            {
                Feature feature = dbContext.Features.FirstOrDefault(f => f.Name == featureName);
                User user = dbContext.Users.FirstOrDefault(u => u.Email == email);

                if (feature != null && user != null)
                {
                    if (enable)
                    {
                        feature.Users.Add(user);
                        user.Features.Add(feature);
                    }
                    else
                    {
                        if (dbContext.Features.Any(f => f.Name == featureName && f.Users.Any(u => u.Email == email)))
                        {
                            feature.Users.Remove(user);
                            user.Features.Remove(feature);
                        }
                        else
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }
}
