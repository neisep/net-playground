using PriorityList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityList.Extensions
{
    public static class PriorityListExtention
    {
        public static Supplier GetSupplier(this List<Supplier> entity, string searchString1, string searchString2, string searchString3)
        {
            if (entity.Count() == 1)
                return entity.FirstOrDefault();

            //More then one match

            //First search
            var matchSupplier = entity.Where(x => x.OrganizationNumber == searchString1 && x.AccountNumber == searchString2);
            if (matchSupplier.Count() == 1)
                return matchSupplier.First();

            //Second search
            matchSupplier = entity.Where(x => x.OrganizationNumber == searchString1 && x.AccountNumber2 == searchString3);
            if (matchSupplier.Count() == 1)
                return matchSupplier.First();

            //Could not determine a unique supplier

            return null;
        }

        public static IList<Supplier> GetSupplier(this List<Supplier> entity, string orgNummer, string bankgiro, string pgnummer, bool test = true)
        {
            //entity comes from database, tries to sort it by conditionals from parameters
            return entity.OrderByDescending(x => x.OrganizationNumber == orgNummer)
                .ThenByDescending(x => x.AccountNumber == bankgiro)
                .ThenByDescending(x => x.AccountNumber2 == pgnummer).ToList();
        }
    }
}
