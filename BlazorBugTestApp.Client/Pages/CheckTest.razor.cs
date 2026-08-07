using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorBugTestApp.Client.Pages
{
    [Route("checkTest")]
    [Route("/")]
    public partial class CheckTest
    {
        //Check variables
        private static readonly string[] Items =
        [
            "Documentation",
            "Examples",
            "Tests"
        ];

        private readonly HashSet<string> selectedItems = new() { "Documentation" };

        private bool AreAllSelected => selectedItems.Count == Items.Length;

        private bool AreSomeSelected => selectedItems.Count > 0 && !AreAllSelected;

        //Functions
        public void OnSelecetAllChanged(bool value)
        {
            selectedItems.Clear();

            if ( value )
            {
                foreach (string item in Items)
                {
                    selectedItems.Add( item );
                }
            }
        }

        public void OnItemCheckedChanged(string item, bool value)
        {
            if (value)
            {
                selectedItems.Add(item);
            }
            else
            {
                selectedItems.Remove(item);
            }
        }      
    }
}
