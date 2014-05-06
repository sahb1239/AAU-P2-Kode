namespace ARK.Model.Extensions
{
    public static class LongDistanceFormExtention
    {
        public static bool Filter(this LongDistanceForm longDistanceForm, string searchText)
        {
            return longDistanceForm.Boat.Filter(searchText) ||
                   longDistanceForm.Text.ContainsCaseInsensitive(searchText);
        }
    }
}