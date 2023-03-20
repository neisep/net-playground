using PriorityList.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PriorityList.Extensions
{
    public static class PriortityList
    {
        public static Supplier GetSupplier(this List<Supplier> entity, string searchString1, string searchString2, string searchString3)
        {
            if (entity.Count() == 1)
                return entity.FirstOrDefault();

            //More then one match

            //First search
            var matchSupplier = entity.Where(x => x.Number == searchString1 && x.Account1 == searchString2);
            if (matchSupplier.Count() == 1)
                return matchSupplier.First();

            //Second search
            matchSupplier = entity.Where(x => x.Number == searchString1 && x.Account2 == searchString3);
            if (matchSupplier.Count() == 1)
                return matchSupplier.First();

            //Could not determine a unique supplier

            return null;
        }
    }
}
