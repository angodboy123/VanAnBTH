namespace BTH1303.Models
{
    public class StringProcess
    {
        public string LowerToUpper(string FullName)
        {
            return (FullName.ToUpper());
        }
        public string UpperToLower(string FullName)
        {
            return (FullName.ToLower());
        }
        // public string CapitalizeFirstLetter(string FullName)
        // {
        //     return (FullName.ToTitleCase(str.ToLower()));
        // }
    }
}