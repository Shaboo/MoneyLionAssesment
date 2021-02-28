using MoneyLionAssesment.Models;
using System.Collections.Generic;

namespace MoneyLionAssesment.Repository
{
    public interface IFeatureRepository
    {
        bool SaveChanges();

        void CreateFeature(Feature feature);

        Feature GetFeatureByEmailAndName(string email, string name);

        bool UpdateFeatureAccess(string email, string featureName, bool enable);
    }
}
