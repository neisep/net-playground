namespace DefensiveProgrammingTests.Domain
{
    /// <summary>
    /// This class makes sure the data is valid, should make it easier too understand how complex code can be much more readable and understandable i think.
    /// So probably a good way too actually create and use objects in a complex code or it doesn't have to be just a complex code it could be applied on anykind of code to make it better.
    /// </summary>
    public class CustomerBuilder
    {
        public string Name { get; set; }
        public string StreetAdress { get; set; }
        public string NameInitial => this.Name.Substring(0, char.IsHighSurrogate(this.Name[0]) ? 2 : 1); //This actually require some kind of defense, what if name is empty or there is no High

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (string.IsNullOrEmpty(StreetAdress))
                return false;

            return true;
        }
    }
}